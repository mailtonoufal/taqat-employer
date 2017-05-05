using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Helpers;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.ModelsIndividual.Jobs;
using ArabWaha.Core.ModelsIndividual.Programs;
using ArabWaha.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.Services
{
    public class ApiServiceIndividual
    {
        // mechanism to get default values for dropdowns
        public async Task<ObservableCollection<AppValues>> GetDefaultValuesAsync(string Category, string parentKey = "")
        {

            // grab data from database
            DbAccessor db = new DbAccessor();
            var Source = UtilHelper.ConvertToObservable<AppValues>(db.GetTableItemsObservable<AppValues>().Where(x => x.CatType == Category).ToList());

            // filter list if we just need root parent values. 
            if (!string.IsNullOrEmpty(parentKey))
                Source = UtilHelper.ConvertToObservable<AppValues>(Source.Where(x => x.ParentKey == parentKey).ToList());



            // grab the current culture here and set the value field
            var cult = this.GetCurrentCulture();

            if (cult == "ar")
                foreach (var item in Source) item.Value = item.Arabic;
            else
                foreach (var item in Source) item.Value = item.English;

            return Source;
        }


        public async Task<ObservableCollection<Announcement>> GetAnnouncementsAsync()
        {
            // would call api async here and await it..


            // grab data from database
            DbAccessor db = new DbAccessor();
            var annSource = db.GetTableItemsObservable<Announcement>();
            return annSource;
        }

        public async Task<ObservableCollection<Notifications>> GetNotificationsAsync()
        {
            // grab data from database
            DbAccessor db = new DbAccessor();
            var notifySource = db.GetTableItemsObservable<Notifications>();
            return notifySource;
        }

        public async Task<ObservableCollection<EventDetails>> GetEventsAsync()
        {
            // grab data from database
            DbAccessor db = new DbAccessor();
            var Source = db.GetTableItemsObservable<EventDetails>();
            return Source;
        }

        public async Task<ObservableCollection<EmployerProgram>> GetAllProgramsAsync(string statusText="")
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<EmployerProgram>();

            var dbsource = db.GetTableItemsObservable<DBAccess.Programs>();
            foreach (var item in dbsource)
            {
                var ix = JsonConvert.DeserializeObject<EmployerProgram>(item.JSON);
                if (!string.IsNullOrEmpty(statusText)) ix.StatusLabelText = statusText;
                source.Add(ix);
            }
            return source;
        }

        // just pull all the badges and identify the status etc 
        public async Task<ObservableCollection<Badges>> GetBadgesAsync()
        {
            DbAccessor db = new DbAccessor();
            var Source = db.GetTableItemsObservable<Badges>();
            return Source;
        }

        public async Task<ObservableCollection<ComplaintRaised>> GetComplaintsAsync()
        {
            // grab data from database
            DbAccessor db = new DbAccessor();
            var Source = db.GetTableItemsObservable<ComplaintRaised>();

            // order by date asc so we see latest first
            var newsource = UtilHelper.ConvertToObservable<ComplaintRaised>(Source.OrderByDescending(x => x.CreateDateCast).ToList());

            return newsource;
        }

        public async Task AddNewComplaint(ComplaintRaised newcompaint)
        {
            // first push to api to get a new complaint id
            int complaintid = UtilHelper.getRandomIdInt();

            // now add new complaint id to current complaint and insert into db.
            newcompaint.ComplaintId = complaintid;
            DbAccessor db = new DbAccessor();
            db.InsertRecord<ComplaintRaised>(newcompaint);
        }


        public async Task<EventDetails> GetEventSingleAsync(string eventId)
        {
            // grab data from database
            DbAccessor db = new DbAccessor();
            var Source = db.GetTableItemsObservable<EventDetails>().Where(x=>x.EventId.ToString()==eventId).FirstOrDefault();
            return Source;
        }

        public string  GetCurrentCulture()
        {
            DbAccessor db = new DbAccessor();
            var culture = db.GetTableItemsObservable<AppSettings>().Where(x=>x.Key=="culture").FirstOrDefault();

            if(culture==null)
            {
                return "en";
            }

            return culture.Value; 
        }

        public async Task SetEventStatus (int eventid, bool Status)
        {
            DbAccessor db = new DbAccessor();
            var eventData = db.GetTableItemsObservable<EventDetails>().Where(x => x.EventId == eventid).FirstOrDefault();

            if(eventData!=null)
            {
                eventData.Status = Status == true ? "Accepted" : "Declined";
                db.UpdateRecord<EventDetails>(eventData);
            }

            // push info to api here
        }

        public async Task SetCurrentCultureAsync(string culture)
        {
            DbAccessor db = new DbAccessor();
            var Currentculture = db.GetTableItemsObservable<AppSettings>().Where(x => x.Key == "culture").FirstOrDefault();

            if(Currentculture==null)
            {
                db.InsertRecord<AppSettings>(new AppSettings { Key = "culture", Value = "en", TextValue = "english" });
            }
            else
            {
                Currentculture.Value = culture.Trim().ToLower();
                db.UpdateRecord<AppSettings>(Currentculture);
            }
        }


        // get only programs that have been signed upto 
        public async Task<ObservableCollection<MyProgramItem>> GetMyProgramsAsync()
        {
            var source = new ObservableCollection<MyProgramItem>();

            DbAccessor db = new DbAccessor();
            var dbrecs = db.GetTableItems<MyPrograms>();

            if(dbrecs!=null && dbrecs.Count>0)
            {
                var dbprogrms = db.GetTableItems<DBAccess.Programs>();

                foreach(var proggy in dbrecs)
                {
                    var progitem = dbprogrms.Where(x => x.ProgramId == proggy.ProgramId).FirstOrDefault();
                    if(progitem!=null)
                    {
                        var expanded = JsonConvert.DeserializeObject<Program>(progitem.JSON);

                        // we have an item
                        source.Add(new MyProgramItem
                        {
                            Title = expanded.ProgramName,
                        //    programStatus = proggy.Status, 
                            ProgramID = proggy.ProgramId.ToString(),
                            ProgramDetails = expanded
                        });
                    }
                }

            } 


            return source;
        }

        public async Task<ObservableCollection<JobApplication>> GetAppliedJobsAsync()
        {
            var source = new ObservableCollection<JobApplication>();

            DbAccessor db = new DbAccessor();

            // sync applied jobs
            var appliedJbs = db.GetTableItems<AppliedJobs>();
            var jobsData = db.GetTableItems<JobsData>();

            if(appliedJbs!=null && appliedJbs.Count>0)
            {
                foreach (var jb in appliedJbs)
                {
                    var expanded = jobsData.Where(x => x.JobPostId.ToString() == jb.JobPostId).FirstOrDefault();
                    if (expanded != null)
                    {
                        source.Add(new JobApplication
                        {
                            JobDetails = JsonConvert.DeserializeObject<EmployerJobDetail>(expanded.JSON),
                          //  ApplicationDate = jb.ApplicationDate, // create function to do this
                            ApplicationStatus = jb.ApplicationStatus,
                            NesIndividualID = jb.NesIndividualID,
                            ApplicationID = jb.ApplicationID,
                            CoverletterId = jb.CoverletterId
                        });
                    }
                }

            }

            return source;

        }

        private void PushToDB<T>(T data)
        {


        }

        // create some initial data here and add to db if not already there
        public async Task CreateDefaultData()
        {
           
        }



        public async void SyncAPiToDB()
        {
            // get db connection
            DbAccessor db = new DbAccessor();

            var progdb = db.GetTableItems<DBAccess.Programs>();

            if (progdb != null && progdb.Count == 0)
            {
                var prgApi = DummyData.getProgramList();
                foreach (var pg in prgApi)
                {
                        // new item so add it in :) 
                        DBAccess.Programs item = new DBAccess.Programs
                        {
                            ProgramId = pg.ProgramId,
                            JSON = JsonConvert.SerializeObject(pg) // turn into a string 
                        };

                        db.InsertRecord<DBAccess.Programs>(item);
                }
            }

            // now add my programs in as well.. 
            var myprogdb = db.GetTableItems<DBAccess.MyPrograms>();

            if (myprogdb != null && myprogdb.Count == 0)
            {
                var myprogs = DummyData.getMyPrograms();
                foreach (var prg in myprogs)
                {
                        db.InsertRecord<DBAccess.MyPrograms>(new MyPrograms { ProgramId = prg.ProgramId, JSON = JsonConvert.SerializeObject(prg) });
                }
            }


            // sync new jobs
            var jobsdb = db.GetTableItems<DBAccess.JobsData>();

            if (jobsdb != null && jobsdb.Count == 0)
            {
                var allJobs = DummyData.GetJobList();

                foreach (var jb in allJobs)
                {
                        // new item so add it in :) 
                        DBAccess.JobsData item = new DBAccess.JobsData
                        {
                            JobPostId = jb.JobPostId,
                            JSON = JsonConvert.SerializeObject(jb) // turn into a string 
                        };

                        db.InsertRecord<DBAccess.JobsData>(item);
                }
            }

            // sync applied jobs
                var jobsAppdb = db.GetTableItems<DBAccess.AppliedJobs>();

                if (myprogdb != null && myprogdb.Count == 0)
                {
                var appliedJbs = DummyData.GetJobApplication();

                foreach (var jb in appliedJbs)
                    {
                            // new item so add it in :) 
                            DBAccess.AppliedJobs item = new DBAccess.AppliedJobs
                            {
                                JobPostId = jb.JobPostId,
                                ApplicationDate = jb.ApplicationDate,
                                ApplicationStatus = jb.ApplicationStatus,
                                NesIndividualID = jb.NesIndividualID,
                                ApplicationID = jb.ApplicationID,
                                CoverletterId = jb.CoverletterId
                            };

                            db.InsertRecord<DBAccess.AppliedJobs>(item);
                    }
                }
        
            // add notifications into db
            var notifyDb = db.GetTableItems<DBAccess.Notifications>();

            if (notifyDb != null && notifyDb.Count == 0)
            {
                var notifyList = DummyData.GetNotificationsList();
                foreach (var nt in notifyList)
                {
                        // new item so add it in :) 
                        Notifications item = new Notifications
                        {
                            Body = nt.Body,
                            NotificationId = nt.NotificationId,
                            Received = nt.Received,
                            Status = nt.Status,
                            Title = nt.Title
                        };

                        db.InsertRecord<Notifications>(item);
                }
            }
            // add in any events from dummy data
            var eventsDb = db.GetTableItems<EventDetails>();

            if (eventsDb != null && eventsDb.Count == 0)
            {
                var eventList = DummyData.GetEventsList();
                foreach (var itemEv in eventList)
                {
                        // new item so add it in :) 
                        EventDetails item = new EventDetails
                        {
                            EventId = itemEv.EventId,
                            EventEnd = itemEv.EventEnd,
                            EventLocation = itemEv.EventLocation,
                            EventStart = itemEv.EventStart,
                            EventTitle = itemEv.EventTitle,
                            Status = itemEv.Status,
                            AdditionalInfo = itemEv.AdditionalInfo,
                            Email= itemEv.Email,
                            PhoneNumber = itemEv.PhoneNumber,
                            JobPostId = itemEv.JobPostId

                        };

                        db.InsertRecord<EventDetails>(item);
                }
            }

            try
            {

                // insert dummy compaints data
                var ComplaintsDb = db.GetTableItems<ComplaintRaised>();

                if (ComplaintsDb != null && ComplaintsDb.Count == 0)
                {
                    // fill with new data
                    var compaintsData = DummyData.GetComplaintsList();
                    foreach (var itemEv in compaintsData)
                    {
                            db.InsertRecord<ComplaintRaised>(new ComplaintRaised
                            {
                                ComplaintText = itemEv.ComplaintText,
                                ComplaintId = itemEv.ComplaintId,
                                Subject = itemEv.Subject,
                                Status = itemEv.Status,
                                CreatedOn = itemEv.CreatedOn,
                                ClosedOn = itemEv.ClosedOn
                            });
                    }
                }
            }catch(Exception ex)
            {
                var t = ex.Message;
            }

            try
            {
                // badges demo data
                var BadgesDb = db.GetTableItems<Badges>();

                if (BadgesDb != null && BadgesDb.Count == 0)
                {
                    // fill with new data
                    var badgesData = DummyData.GetBadgesList();
                    foreach (var itemEv in badgesData)
                    {
                        Badges itexX = itemEv;
                        db.InsertRecord<Badges>(itexX);
                    }
                }
            }
            catch(Exception ex)
            {
                var t = ex.Message;
            }

        }

        // get info for job / applied / in watchlist based on jobpostid
        public JobInfo GetJobInfo(string jobpostid)
        {
            DbAccessor db = new DbAccessor();

            JobInfo jbInf = new JobInfo { JobPostId = jobpostid, IsAppliedForJob = false, IsWatched=false };

//            var item = db.GetTableItems<WatchJobs>().Where(x => x.JobPostId == jobpostid).FirstOrDefault();
            if (db.GetTableItems<WatchedJobs>().Where(x => x.JobPostId == jobpostid).FirstOrDefault() != null)
                jbInf.IsWatched = true;

            if (db.GetTableItems<AppliedJobs>().Where(x => x.JobPostId == jobpostid).FirstOrDefault() != null)
                jbInf.IsAppliedForJob = true;

            return jbInf;
        }


        public async Task<bool> DeleteAppliedJobasync(string jobId, string profileId)
        {
            // do api delete here using await
            return true;
        }

        public async Task<bool> DeleteWatchListJobasync(string jobId)
        {
            // do api delete here using await
            // 1) check auth'd or a valid user 
            // 2) push to api

            // TODO

            // now remove from the database itself so we dont hold it locally
            DbAccessor db = new DbAccessor();
            var item = db.GetTableItems<WatchedJobs>().Where(x => x.JobPostId == jobId).FirstOrDefault();

            if(item!=null)
                db.DeleteRecord<WatchedJobs>(item); 

            return true;
        }

        // add to watch list
        public async Task<bool> AddWatchListJobasync(string jobId)
        {
            // push api watch Job here using await need to grab the profile id of the use

            // 1) check auth'd or a valid user 
            // 2) push to api

            // TODO

            // now Add to database if not already existing
            DbAccessor db = new DbAccessor();
            var item = db.GetTableItems<WatchedJobs>().Where(x => x.JobPostId == jobId).FirstOrDefault();

            if (item == null)
                db.InsertRecord<WatchedJobs>(new DBAccess.WatchedJobs { JobPostId=jobId  });

            return true;
        }


        public async Task<EmployerJobDetail> GetWatchedJobsSingleAsync(string jobPostId)
        {

            // for now just pull from db
            DbAccessor db = new DbAccessor();
            var job = db.GetTableItems<JobsData>().Where(x=>x.JobPostId==jobPostId).FirstOrDefault();

            if(job!=null)
            {
                var jb = JsonConvert.DeserializeObject<EmployerJobDetail>(job.JSON);
                return jb;
            }

            return null;
        }

        public async Task<ObservableCollection<EmployerJobDetail>> GetWatchedJobsAsync()
        {
            // jobs list
            var source = new ObservableCollection<EmployerJobDetail>();

            // for now just pull from db
            DbAccessor db = new DbAccessor();
            var jobs = db.GetTableItems<JobsData>();
            var watchList = db.GetTableItems<WatchedJobs>();
            foreach (var itm in watchList)
            {
                var jobItem = jobs.Where(x => x.JobPostId == itm.JobPostId).FirstOrDefault();
                if(jobItem!=null)
                {
                    source.Add(JsonConvert.DeserializeObject<EmployerJobDetail>(jobItem.JSON));
                }
            }
            return source;
        }

        public async Task<ObservableCollection<EmployerJobDetail>> GetMatchedJobsAsync()
        {
            // do we need to get any matched jobs online????

            // jobs list
            var source = new ObservableCollection<EmployerJobDetail>();


            // for now just pull from db
            DbAccessor db = new DbAccessor();
            var jobs = db.GetTableItems<JobsData>();
            foreach (var itm in jobs)
            {
                // check for errors here 
                try
                {
                    source.Add(JsonConvert.DeserializeObject<EmployerJobDetail>(itm.JSON));
                }
                catch(Exception ex)
                {
                    var t = ex.Message;
                }
            }

            return source;
        }

        // apply for job

        // login 

        // reset password

        // 

    }

    public class DummyData
    {

        public static List<Badges> GetBadgesList()
        {
            var source = new List<Badges>
            {
                new Badges { BadgeId=123, BadgeName="Option 1", BadgeDescription="this is the description for option 1 badge", Locked=0, BadgeStatus="Locked", BadgeIcon="" },
                new Badges { BadgeId=124, BadgeName="Option 2", BadgeDescription="this is the description for option 2 badge", Locked=0, BadgeStatus="Locked", BadgeIcon="" },
                new Badges { BadgeId=125, BadgeName="Option 3", BadgeDescription="this is the description for option 3 badge", Locked=1, BadgeStatus="UnLocked", BadgeIcon="" },
                new Badges { BadgeId=126, BadgeName="Option 4", BadgeDescription="this is the description for option 4 badge", Locked=0, BadgeStatus="Locked", BadgeIcon="" },
                new Badges { BadgeId=127, BadgeName="Option 5", BadgeDescription="this is the description for option 5 badge", Locked=1, BadgeStatus="UnLocked", BadgeIcon="" },
                new Badges { BadgeId=128, BadgeName="Option 6", BadgeDescription="this is the description for option 6 badge", Locked=1, BadgeStatus="UnLocked", BadgeIcon="" },
                new Badges { BadgeId=129, BadgeName="Option 7", BadgeDescription="this is the description for option 7 badge", Locked=1, BadgeStatus="UnLocked", BadgeIcon="" },
                new Badges { BadgeId=130, BadgeName="Option 8", BadgeDescription="this is the description for option 8 badge", Locked=0, BadgeStatus="Locked", BadgeIcon="" },
                new Badges { BadgeId=131, BadgeName="Option 9", BadgeDescription="this is the description for option 9 badge", Locked=0, BadgeStatus="Locked", BadgeIcon="" },

            };

            return source;
        }

        public static List<AppliedJobs> GetJobApplication()
        {
            var source = new List<AppliedJobs>
            {
                new AppliedJobs {JobPostId="13645", ApplicationStatus="Inteview Scheduled", NesIndividualID=999, ApplicationID=100, ApplicationDate="01/01/2017", CoverletterId="12" },
                new AppliedJobs {JobPostId="5", ApplicationStatus="Rejected", NesIndividualID=899, ApplicationID=101, ApplicationDate="01/03/2017", CoverletterId="12" },

            };

            return source;

        }

        public static List<EmployerJobDetail> GetJobList()
        {
           var source = new List<EmployerJobDetail>()
                {
                        new EmployerJobDetail { JobPostId="13645", JobPostTitle="Android developer, Java",  Status="Open", JobDescription="description 1",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google", Posted="1 Months",
                        JobType="Permanent", OpenPositions="2", FilledPosition="1",
                        SalaryFrom="9000",  SalaryTo ="150000",
                        Experience="5 Years", StartDate="2/6/2017",
                        PublicationDate="16/04/2017",
                        RolesResponsibilities="Database, Management, Security Checkups",
                        MatchScore="72",


                        CompanyLocation=new EmployerCompanyLocation {
                            LocationId ="Ryyad, KSA", Address="5453 Al Olaya street, Riyah 23351 - 2609, Saudi Arabia",
                            LocationNotes="The environment is disability confident", Latitude="22.755439", Longitude="46.209155"
                        },
                        WorkTime="Full Time", Shifttype="Day", Teleworking="No", Mobility="Restricted",
                        OtherBenefits="Yearly training courses", Bonus="Yes",
                        ApplicationRequirement="CV & References", SurveyUrl="http://surveyexample.com",
                        ContactPersonInd = new ContactPersonInd
                        {
                            Name="Saud Khalid", Email="khalid@aec.com"
                        },


                        JobLanguages = new ObservableCollection<JobDetailLanguage>
                        {
                            new JobDetailLanguage {Name="English", ProficiencyLevel="40" },
                            new JobDetailLanguage {Name="Arabic", ProficiencyLevel="90" },
                            new JobDetailLanguage {Name="General Database Programming", ProficiencyLevel="7" },
                            new JobDetailLanguage {Name="IT Security", ProficiencyLevel="50" }
                        },
                        JobLicenses = new ObservableCollection<JobDetailLicenses>
                        {
                            new JobDetailLicenses {Value="Public Work-Driving",ExpiryValue="10/2005-04/2010"},
                            new JobDetailLicenses {Value="Motorcycle Driving",ExpiryValue="10/2005-04/2010"}
                        }
                        , RequiresDrivingLicence="Yes", DrivingLicenceType="Private Licence",
                        JobTraining = new ObservableCollection<EmployerJobDetailTraining>
                        {
                            new EmployerJobDetailTraining {Name="Six Segma Green belt",InstituteName ="Microsoft",
                            Location="Jeddah, Saudi Arabia",Validity="10/2005-04/2010"}
                        }
                        },

                new EmployerJobDetail { JobPostId="2", JobPostTitle="Android developer, Xamarin",  Status="Closed", JobDescription="description 2",
                        MatchScore="89",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google", Posted="2 Months",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" } },
                new EmployerJobDetail { JobPostId="3", JobPostTitle="Android developer, Java Se",  Status="Open", JobDescription="description 3",
                        MatchScore="42",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google",  Posted="1 Week",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" } },
                new EmployerJobDetail { JobPostId="4", JobPostTitle="iOS developer, X-Code",  Status="Open", JobDescription="description 4",
                        MatchScore="50",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google",  Posted="3 Months",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" }},
                new EmployerJobDetail { JobPostId="5", JobPostTitle="iOS developer, Swift",  Status="Closed", JobDescription="description 5",
                        MatchScore="21",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google",  Posted="2 Weeks",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" }},
                new EmployerJobDetail { JobPostId="6", JobPostTitle="C# developer, .Net",  Status="Open", JobDescription="description 6",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google",  Posted="1 Months",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" }},
            };

            return source;
        }

        public static List<EmployerProgram> getMyPrograms()
        {
            var source = new List<EmployerProgram>
            {
                new EmployerProgram{    ProgramId=1,Title ="Job Commitment Bonus", Status="Pending" },
                new EmployerProgram {    ProgramId=4, Title="Employment Support", Status="Applied" },
                new EmployerProgram {    ProgramId=5, Title="Saned", Status="Accepted" },
            };

            return source;

        }

        public static List<Notifications> GetNotificationsList()
        {
            DateTime timenow = DateTime.Now;

            var NotifySource = new List<Notifications>();

            timenow = DateTime.Now.AddMinutes(-10);
            NotifySource.Add(new Notifications { NotificationId = 1, Status = "Unread", Title = "two employers viewed your profile",
                Received = $"{timenow.Year}-{timenow.Month}-{timenow.Day}T{timenow.Hour}:{timenow.Minute}:00",
                Body = "This is a test message"
            });

            timenow = DateTime.Now.AddMinutes(-13);
            NotifySource.Add(new Notifications { NotificationId = 2, Status = "Unread", Title = "New jobs that match your profile are available ",
                Received = $"{timenow.Year}-{timenow.Month}-{timenow.Day}T{timenow.Hour}:{timenow.Minute}:00",
                Body = "This is a test message"
            });

            timenow = DateTime.Now.AddMinutes(-32);
            NotifySource.Add(new Notifications { NotificationId = 3, Status = "Unread", Title = "Complete your profile to get more attention",
                Received = $"{timenow.Year}-{timenow.Month}-{timenow.Day}T{timenow.Hour}:{timenow.Minute}:00",
                Body = "This is a test message"
            });

            timenow = DateTime.Now.AddMinutes(-40);
            NotifySource.Add(new Notifications { NotificationId = 4, Status = "Unread", Title = "AEC sent you a message",
                Received = $"{timenow.Year}-{timenow.Month}-{timenow.Day}T{timenow.Hour}:{timenow.Minute}:00",
                Body = "This is a test message"
            });

            timenow = DateTime.Now.AddMinutes(-60);
            NotifySource.Add(new Notifications { NotificationId = 5, Status = "Unread", Title = "New course related to your interests is ready",
                Received = $"{timenow.Year}-{timenow.Month}-{timenow.Day}T{timenow.Hour}:{timenow.Minute}:00",
                Body = "This is a test message"
            });

            timenow = DateTime.Now.AddHours(-5);
            NotifySource.Add(new Notifications { NotificationId = 6, Status = "Unread", Title = "New Taqat program just launched",
                Received = $"{timenow.Year}-{timenow.Month}-{timenow.Day}T{timenow.Hour}:{timenow.Minute}:00",
                Body = "This is a test message"
            });

            timenow = DateTime.Now.AddDays(-2);
            NotifySource.Add(new Notifications { NotificationId = 7, Status = "Unread", Title = "New jobs are available",
                Received = $"{timenow.Year}-{timenow.Month}-{timenow.Day}T{timenow.Hour}:{timenow.Minute}:00",
                Body = "This is a test message"
            });

            timenow = DateTime.Now.AddDays(-6);
            NotifySource.Add(new Notifications
            {
                NotificationId = 8,
                Status = "Read",
                Title = "Job Application status updated",
                Received = $"{timenow.Year}-{timenow.Month}-{timenow.Day}T{timenow.Hour}:{timenow.Minute}:00",
                Body = "This is a test message"
            });

            return NotifySource;
        }
        public static List<Program> getProgramList()
        {
            // programs
            var progSource = new List<Program>
            {

                new Program {ProgramId=1, Status="Open", ProgramName="Job Commitment Bonus" ,
                Description="When registered to the Job Commitment Bonus Program, newly employed Saudi nationals who have already enrolled in Hafiz Searching for Employment, in Hafiz Difficulty Finding Employment, or in Employment Support can now benefit from cash rewards.\nThe amount of the reward is calculated based on a number of criteria, with individuals belonging to one of 4 different groups - each group is eligible to receive a different level of rewards over a different amount of time. The plans vary between 3 and 4 installments, over the course of 2 years and for a full cash amount that can reach up to 24, 000 SAR.",
                WhoCanBenefit="Individuals’ portfolios are divided into 4 groups with settlement of cash reward plan detailed as per the specifics and table below. For ease of calculation, job seekers can visit the following link.",
                ProgramRequirements="Applications enrolling in Hafiz, Searching for Employment and Hafiz, Difficulty Finding Employment should in general meet the following requirements:\nShould be a Saudi national, or having a Saudi mother.\nShould be aged between 20 and 60 years.\nShould be eligible to work.\nShould not be employed neither in the public nor private sectors.\nShould not be a trainee neither at a academical nor a professional level.\nShould not be a full time student.\nShould not have any traiding or commercial activities.\nShould not be a prisoner or deceased.\nShould not be benefititng from a fixed pension or a financial support or from a social facility lodging.\nShould not have benifited from a 2, 000 SAR salary or above for the past 12 months.\nShould not be currently benefiting from a monthly income that exceeds 3, 000 SAR.\nShould have completed the latest academical enrollment succesfully, more than 6 months prior to their application to the program.\nShould have applied for the program within the set deadlines for application.\nShould not have been be previously suspended from Hafiz Searching for Employment or Hafiz Difficulty Finding Employment programs.\nShould have enrolled in their job for less than 100 days at time of application to the program.",
                HowToRegister="Click  here  and follow the easy steps to register for this program."
                },
                new Program {ProgramId=2, Status="Open", ProgramName="Hafiz, Searching For Employment" },
                new Program {ProgramId=3, Status="Open", ProgramName="Hafiz, Difficulty Finding Employment" },
                new Program {ProgramId=4, Status="Open", ProgramName="Employment Support" },
                new Program {ProgramId=5, Status="Open", ProgramName="Saned" },
                new Program {ProgramId=6, Status="Open", ProgramName="Dooroob" },
                new Program {ProgramId=7, Status="Open", ProgramName="Tamheer (On Job Training)" },

            };

            return progSource;
        }

        public static List<ComplaintRaised> GetComplaintsList()
        {
            var retSource = new List<ComplaintRaised>
            {
                new ComplaintRaised
                {
                    Subject="Website issues",
                    Status="Closed",
                    ComplaintId=12345,
                    ComplaintText="Website not displaying images",
                    Category="Website",
                    CreatedOn="2017-2-17",
                    ClosedOn="2017-2-26"
                },
                new ComplaintRaised
                {
                    Subject="Sign In Issue",
                    Status="In progress",
                    ComplaintId=13456,
                    ComplaintText="Cannot signin with current password. Invalid password error",
                    Category="Website",
                    CreatedOn ="2017-4-15",
                    ClosedOn=""
                },
                new ComplaintRaised
                {
                    Subject="Forgot Password",
                    Status="In progress",
                    ComplaintId=16543,
                    ComplaintText="How can I reset my password",
                    Category="Login",
                    CreatedOn="2017-2-21",
                    ClosedOn=""
                },
                new ComplaintRaised
                {
                    Subject="Cannot create account",
                    Status="In progress",
                    ComplaintId=12345,
                    ComplaintText="When i create an account the website rejects my information stating that it is incorrect?",
                    Category="Website",
                    CreatedOn ="2017-3-10",
                    ClosedOn=""
                },
                new ComplaintRaised
                {
                    Subject="New jobs not showing",
                    Status="Closed",
                    ComplaintId=10092,
                    Category="Website",
                    ComplaintText="I have watched 4 new jobs and they are not showing up in my watched list",
                    CreatedOn="2017-3-25",
                    ClosedOn="2017-3-29"
                },
                new ComplaintRaised
                {
                    Subject="Website crashed",
                    Status="rejected",
                    ComplaintId=23543,
                    Category="Website",
                    ComplaintText="When i navigate to the website it crashes my browser",
                    CreatedOn="2016-9-10",
                    ClosedOn="2016-10-10"
                },
            };

            return retSource;

        }

        public static List<EventDetails> GetEventsList()
        {
            DateTime eventDate = DateTime.Now.AddHours(2);

            var retSource = new List<EventDetails>
            {
                new EventDetails
                {
                    EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                    EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                    EventLocation = "AEC Offices",
                    EventTitle ="Flight to Salt Lake city",
                    EventId =1,
                    Status ="Declined",
                    PhoneNumber="01234567890",
                    Email="admin@aramco.com",
                    AdditionalInfo="Dress code is required",
                    JobPostId= "12345"
                }
            };

            eventDate = eventDate.AddHours(2);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1.5)),
                EventLocation = "HDRF - Olaya street",
                EventTitle = "Team Meeting",
                EventId = 2,
                Status = "Accepted",
                PhoneNumber="01234567890",
                Email="info@aramco.com",
                AdditionalInfo="Dress code is required", 
                JobPostId= "13645"
            });

            eventDate = eventDate.AddDays(1).AddHours(-2);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                EventLocation = "CBA Limited - Riyah, KSA",
                EventTitle = "Ford project Initialization",
                EventId = 3,
                Status = "Accepted",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId="2"
            });

            eventDate = eventDate.AddHours(3);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                EventLocation = "Google Office - Dubai",
                EventTitle = "Google Conference",
                EventId = 4,
                Status = "Accepted",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId="3"
            });

            eventDate = eventDate.AddDays(1).AddHours(3);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                EventLocation = "Excel centre - London UK",
                EventTitle = "Developers Conference",
                EventId = 5,
                Status = "Declined",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId="4"
            });


            eventDate = eventDate.AddDays(3);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                EventLocation = "office abc - Riyah, KSA",
                EventTitle = "Client meetup",
                EventId = 6,
                Status = "Accepted",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId="5"
            });

            return retSource;
        }
    }
}
