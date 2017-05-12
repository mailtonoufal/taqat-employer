using ArabWaha.Core.DBAccess;
using ArabWaha.Core.DBAccess.Employer;
using ArabWaha.Core.Helpers;
using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.ModelsEmployer.Services;
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
    public class ApiService
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

        public string GetCurrentCulture()
        {
            DbAccessor db = new DbAccessor();
            var culture = db.GetTableItemsObservable<AppSettings>().Where(x => x.Key == "culture").FirstOrDefault();

            if (culture == null)
            {
                return "en";
            }
            return culture.Value;
        }

        public async Task<string> GetAppVersionAsync()
        {
            return "1.5.1";
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

        public async Task SetEventStatus(int eventid, bool Status)
        {
            DbAccessor db = new DbAccessor();
            var eventData = db.GetTableItemsObservable<EventDetails>().Where(x => x.EventId == eventid).FirstOrDefault();

            if (eventData != null)
            {
                eventData.Status = Status == true ? "Accepted" : "Declined";
                db.UpdateRecord<EventDetails>(eventData);
            }

            // push info to api here
        }

        public async Task<ObservableCollection<EventDetails>> GetEventsAsync()
        {
            // grab data from database
            DbAccessor db = new DbAccessor();
            var Source = db.GetTableItemsObservable<EventDetails>();
            return Source;
        }

        public async Task<EventDetails> GetEventSingleAsync(string eventId)
        {
            // grab data from database
            DbAccessor db = new DbAccessor();
            var Source = db.GetTableItemsObservable<EventDetails>().Where(x => x.EventId.ToString() == eventId).FirstOrDefault();
            return Source;
        }

        public async Task SetCurrentCultureAsync(string culture)
        {
            DbAccessor db = new DbAccessor();
            var Currentculture = db.GetTableItemsObservable<AppSettings>().Where(x => x.Key == "culture").FirstOrDefault();

            if (Currentculture == null)
            {
                db.InsertRecord<AppSettings>(new AppSettings { Key = "culture", Value = "en", TextValue = "english" });
            }
            else
            {
                Currentculture.Value = culture.Trim().ToLower();
                db.UpdateRecord<AppSettings>(Currentculture);
            }
        }

        public async Task<ObservableCollection<Announcement>> GetAnnouncementsAsync()
        {
            DbAccessor db = new DbAccessor();
            var source = db.GetTableItemsObservable<Announcement>();
            return source;
        }

        public async Task<bool> DeleteEmployerJobasync(string jobId)
        {
            // do api delete here using await
            return true; 
        }      

        public async Task<ObservableCollection<EmployerService>> GetEmployerServicesAsync(int employerId = 0 )
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<EmployerService>();

            var dbsource = db.GetTableItemsObservable<MyServices>();
            foreach (var item in dbsource)
            {
                source.Add(JsonConvert.DeserializeObject<EmployerService>(item.JSON));
            }
            return source;
        }

        public async Task<ObservableCollection<EmployerService>> GetAllServicesAsync()
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<EmployerService>();

            var dbsource = db.GetTableItemsObservable<AllServices>();
            foreach (var item in dbsource)
            {
                source.Add(JsonConvert.DeserializeObject<EmployerService>(item.JSON));
            }
            return source;
        }

        public async Task<ObservableCollection<EmployerProgram>> GetCurrentProgramsAsync()
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<EmployerProgram>();

            var dbsource = db.GetTableItemsObservable<MyPrograms>();
            foreach (var item in dbsource)
            {
                source.Add(JsonConvert.DeserializeObject<EmployerProgram>(item.JSON));
            }
            return source;
        }

        // Programs
        public async Task<ObservableCollection<EmployerProgram>> GetAllProgramsAsync()
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<EmployerProgram>();

            var dbsource = db.GetTableItemsObservable<DBAccess.Programs>();
            foreach (var item in dbsource)
            {
                source.Add(JsonConvert.DeserializeObject<EmployerProgram>(item.JSON));
            }
            return source;
        }

        public async Task<bool> UpdateEmployerJob(EmployerJobDetail job) // add new or existing job
        {
            DbAccessor db = new DbAccessor();

            // update job in both database and api to server if connection. 
            var vjob = db.GetTableItems<EmployerJobs>().Where(x => x.JobPostId == job.JobPostId).FirstOrDefault();
            if (vjob != null)
            {
                vjob.JSON = JsonConvert.SerializeObject(job);
                // update here for db 
                db.UpdateRecord<EmployerJobs>(vjob);

                // push update to api here 
                // ***************** TODO ***************
            }
            else
            {
                var jb = new EmployerJobs { JSON = JsonConvert.SerializeObject(job), JobPostId = job.JobPostId};
                db.InsertRecord<EmployerJobs>(jb);
            }
        
            // temp return 
            return true;
        }

        public async Task<EmployerJobDetail> GetEmployerPostedJobsSingleAsync(string JobPostId)
        {
            DbAccessor db = new DbAccessor();

            var jb = db.GetTableItems<EmployerJobs>().Where(x => x.JobPostId == JobPostId).FirstOrDefault();

            if(jb!=null)
                return JsonConvert.DeserializeObject<EmployerJobDetail>(jb.JSON);

            return null;
        }

        public async Task<ObservableCollection<EmployerJobDetail>> GetEmployerPostedJobsAsync(int employerId)
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<EmployerJobDetail>();

            var dbsource = db.GetTableItemsObservable<EmployerJobs>();
            foreach(var item in dbsource)
            {
                source.Add(JsonConvert.DeserializeObject<EmployerJobDetail>(item.JSON));
            }

            return source;
        }

        public async Task<ApplicationProfile> GetApplicationProfileAsync(string profileId)
        {
            DbAccessor db = new DbAccessor();
            var source = new ApplicationProfile();

            var dbsource = db.GetTableItemsObservable<JobApplicant>().Where( x=> x.ApplicantId == profileId).FirstOrDefault();
            if (dbsource != null)
            {
                source = JsonConvert.DeserializeObject<ApplicationProfile>(dbsource.JSON);
            }

            return source;
        }
        public async Task<ObservableCollection<ApplicationProfile>> GetSearchApplicationsAsync(string keyword, string location)
        {
            // Test no results.
            if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(location))
                return new ObservableCollection<ApplicationProfile>();

            // *************** TODO ************************
            // call api to return the dynamic search data for candidates
            
            // DB is storing the static candidates, we need to call api for dynamic search results..
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<ApplicationProfile>();

            var dbsource = db.GetTableItemsObservable<JobApplicant>();
            foreach (var item in dbsource)
            {
                var client = JsonConvert.DeserializeObject<ApplicationProfile>(item.JSON);

                // 4 possible checks
                // 1 - no search words so grab all
                // 2 - keyword search 
                // 3 - location search
                // 4 - keyword search AND location search
                // we need to check client keyword actually matches here.
                if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(location)) // add all
                        source.Add(client);
                // just keyword
                else if (!string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(location) && client.Occupation.ToLower().Contains(keyword.Trim().ToLower()))
                    source.Add(client);
                // just location
                else if (string.IsNullOrEmpty(keyword) && !string.IsNullOrEmpty(location) && client.Location.ToLower().Contains(location.Trim().ToLower()))
                    source.Add(client);
                // we have to have keyword and location so check both
                else if (client.Occupation.ToLower().Contains(keyword.Trim().ToLower()) && client.Location.ToLower().Contains(location.Trim().ToLower()))
                    source.Add(client);



            }
            return source;
        }

        public async Task<ObservableCollection<ApplicationProfile>> GetMatchingCandidatesForJobPost(string jobPostId)
        {

            // *************** TODO ************************
            // call api to return the dynamic search data for matching candidates

            // DB is storing the static candidates, we need to call api for dynamic search results..
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<ApplicationProfile>();

            var dbsource = db.GetTableItemsObservable<JobApplicant>().Where(x => x.JobPostId == jobPostId.ToString());
            foreach (var item in dbsource)
            {
                source.Add(JsonConvert.DeserializeObject<ApplicationProfile>(item.JSON));
            }
            return source;
        }

        public async Task<ApplicationsForCompanyJobs> GetCompanyJobApplicationsAsync(int companyId = 0)
        {
            // *************** TODO ************************
            // call api to return the jobs and Applications.
            ApplicationsForCompanyJobs companyJobs = new ApplicationsForCompanyJobs()
            {
                CompanyId = companyId,
                Jobs = new ObservableCollection<ApplicationsForJob>()                
            };

            for(int i=1; i< 7; i++)
            {
                companyJobs.Jobs.Add(await GetCompanyJobApplicationsByJobIdAsync(companyId, i));
            }
            return companyJobs;
        }

        public async Task<ApplicationsForJob> GetCompanyJobApplicationsByJobIdAsync(int companyId = 0, int jobPostId = 0)
        {

            DbAccessor db = new DbAccessor();
            ApplicationsForJob retVal = new ApplicationsForJob();

            var jb = db.GetTableItems<EmployerJobs>().Where(x => x.JobPostId == jobPostId.ToString()).FirstOrDefault();

            if (jb == null)
                return retVal; // no job so just return empty object

            retVal.JobDetails = JsonConvert.DeserializeObject<EmployerJobDetail>(jb.JSON);
            retVal.Applications = new ObservableCollection<ApplicationProfile>();

            var dbsource = db.GetTableItemsObservable<JobApplicant>().Where(x=>x.JobPostId==jobPostId.ToString());
            foreach (var item in dbsource)
            {
                retVal.Applications.Add(JsonConvert.DeserializeObject<ApplicationProfile>(item.JSON));
            }

            return retVal;
        }

        public async Task<bool> IsJobPostInWatchListAsync(string jobPostId, string companyId = null, string userId = null)
        {
            DbAccessor db = new DbAccessor();

            var jb = db.GetTableItems<WatchedJobs>().Where(x => x.JobPostId == jobPostId).FirstOrDefault();
            if (jb != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> AddJobPostToWatchListAsync(string jobPostId, string companyId = null, string userId = null)
        {
            
            bool added = false;
            // add the job to watch list
            DbAccessor db = new DbAccessor();

            var jb = db.GetTableItems<WatchedJobs>().Where(x => x.JobPostId == jobPostId).FirstOrDefault();
            if (jb == null)
            {
                // isn't in the list add it
                db.InsertRecord<WatchedJobs>(new WatchedJobs { JobPostId = jobPostId });
                // TODO **** Push to api here - will need the postid/userid and company to uniquely identify for API
                added = true;
            }        
            return added;
        }

        public async Task<bool> DeleteJobPostFromWatchListAsync(string jobPostId, string companyId = null, string userId = null)
        {

            bool removed = false;
            // add the job to watch list
            DbAccessor db = new DbAccessor();

            var jb = db.GetTableItems<WatchedJobs>().Where(x => x.JobPostId == jobPostId).FirstOrDefault();
            if (jb != null)
            {
                // isn't in the list add it
                db.DeleteRecord<WatchedJobs>(jb);
                // TODO **** Push to api here - will need the postid/userid and company to uniquely identify for API
                removed = true;
            }
            return removed;
        }

        // Add Applicaiton/Candidate to Watch list what do we need to pass in - JobPostId, ProfileId??
        //public async Task<bool> AddApplicantToWatchList(int JobPostId, int profileId)
        //{
        //    // pull profile and add to watched list
        //    DbAccessor db = new DbAccessor();

        //    var client = db.GetTableItems<MatchedClients>().Where(x => x.ProfileId == profileId.ToString()).FirstOrDefault();
        //    var jb = db.GetTableItems<WatchedClients>().Where(x => x.JobPostId == JobPostId.ToString()
        //                        && x.ProfileId == profileId.ToString()).FirstOrDefault();

        //    if (jb != null) return false; // already exists

        //    db.InsertRecord<WatchedClients>(new WatchedClients { JobPostId=JobPostId.ToString(), ProfileId=profileId.ToString() ,
        //          JSON=JsonConvert.SerializeObject(client)  });

        //    // TODO **** Push to api here

        //    // add to db table
        //    return true;
        //}

        // Get the Jobs Watch list for the user - returns a list of Applicaiton Profiles associated with the Job Post 
        public async Task<ObservableCollection<ApplicationsForJob>> GetCompanyWatchListAsync(int companyId, int userId)
        {

            DbAccessor db = new DbAccessor();
            var retVal = new ObservableCollection<ApplicationsForJob>();
            var watched = db.GetTableItems<WatchedJobs>(); // .Where(x => x.AddedById == userId.ToString()); // only get for added user??

            foreach(var jbs in watched)
            {
                var currentJob = await GetCompanyJobApplicationsByJobIdAsync(0, Convert.ToInt32(jbs.JobPostId));
                if(currentJob!=null)
                {
                    retVal.Add(currentJob);
                }
            }
            return retVal;
        }

        public async Task<CompanyDetails> GetCompanyDetailsAsync(int companyId)
        {
            // *************** TODO ************************
            // call api to return the company details.

            DbAccessor db = new DbAccessor();

            var jb = db.GetTableItems<CompanyProfile>().FirstOrDefault();

            if (jb != null)
                return JsonConvert.DeserializeObject<CompanyDetails>(jb.JSON);

            return null;

        }


        public async Task<bool> DeleteCompanyUserAsync(int userId = 0)
        {
            // call api service to delete user
            // **************** TODO *********************

            // now delete from local data store
            DbAccessor db = new DbAccessor();
            var item = db.GetTableItems<CompanyUser>().Where(x => x.UserId == userId).FirstOrDefault();

            if(item!=null)
            {
                db.DeleteRecord<CompanyUser>(item);
            }

            return true;
        }

        int dummyUserId
        {
            get {

                DbAccessor db = new DbAccessor();
                var item = db.Query<CompanyUser>("select * from CompanyUser order by id desc limit 1", new object[] { }).FirstOrDefault();
                return item.id+1;
                }
        }
        public async Task<int> AddCompanyUser(CompanyUserDetails newUser)
        {
            int newUserId = 0;
            // ****** TODO *******
            // call api service to add user

            DbAccessor db = new DbAccessor();
            var item = db.GetTableItems<CompanyUser>().Where(x => x.UserId == newUser.UserId).FirstOrDefault();

            if(item!=null)
            {
                item.JSON = JsonConvert.SerializeObject(newUser);
                db.UpdateRecord<CompanyUser>(item);
                newUserId = item.UserId;
            }
            else
            {
                // ****** TODO *******
                // GET new user id from API and populate the new user with it 
                newUser.UserId = newUserId = dummyUserId;
                // now save it
                db.InsertRecord<CompanyUser>(new CompanyUser { UserId=newUser.UserId, UserRole=newUser.AssignedRole, JSON=JsonConvert.SerializeObject(newUser)});
            }


            return newUserId;
        }

        public async Task<CompanyUserDetails> GetCompanyUserDetailsAsync(int userId)
        {
            DbAccessor db = new DbAccessor();
            var item = db.GetTableItems<CompanyUser>().Where(x => x.UserId == userId).FirstOrDefault();

            if(item!=null)
                return JsonConvert.DeserializeObject<CompanyUserDetails>(item.JSON);

            return null;
        }

        public async Task<ObservableCollection<CompanyUserDetails>> GetCompanyRepresentativeUsersAsync(int companyId)
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<CompanyUserDetails>();
            var items = db.GetTableItems<CompanyUser>().Where(x => x.UserRole == "Representative");

            foreach(var it in items)
            {
                if(it!=null) source.Add(JsonConvert.DeserializeObject<CompanyUserDetails>(it.JSON));
            }
            return source;
        }

        public async Task<ObservableCollection<CompanyUserDetails>> GetCompanyRecruiterUserssAsync(int companyId)
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<CompanyUserDetails>();
            var items = db.GetTableItems<CompanyUser>().Where(x => x.UserRole == "Recruiter"); ;

            foreach (var it in items)
            {
                if (it != null) source.Add(JsonConvert.DeserializeObject<CompanyUserDetails>(it.JSON));
            }
            return source;
        }

        // basic sync for db items  .. NOTE uses dummy items at the moment for debugging
        public async void SyncAPiToDB()
        {
            // get db connection
            DbAccessor db = new DbAccessor();

            // company users 
            var usersdb = db.GetTableItems<CompanyUser>();
            if (usersdb != null && usersdb.Count == 0)
            {
                var prgApi = DummyEmpData.GetCompanyUsers(); // store in db as CompanyUserDetails in json
                foreach (var pg in prgApi)
                {
                        CompanyUser item = new CompanyUser { UserId = pg.UserId, UserRole = pg.AssignedRole, JSON = JsonConvert.SerializeObject(pg) };
                        db.InsertRecord<CompanyUser>(item);
                }
            }

            // company details
            var companydb = db.GetTableItems<CompanyProfile>();
            if (companydb != null && companydb.Count == 0)
            {
                var comp = DummyEmpData.GetCompanyDetails(); // store in db as CompanyProfile in json
                CompanyProfile item = new CompanyProfile { ProfileId = comp.CompanyId, JSON = JsonConvert.SerializeObject(comp) };
                db.InsertRecord<CompanyProfile>(item);
            }

            // employer posted jobs
            var empdb = db.GetTableItems<EmployerJobs>();
            if (empdb != null && empdb.Count == 0)
            {
                var prgApi = DummyEmpData.GetEmployerPostedJobs(); // store in db as EmployerJobs in json
                foreach (var pg in prgApi)
                {
                        var item = new EmployerJobs  { JobPostId = pg.JobPostId,Status=pg.Status, JSON = JsonConvert.SerializeObject(pg) };
                        db.InsertRecord<EmployerJobs>(item);
                }
            }

            // current assigned programs for company
            var myProgdb = db.GetTableItems<MyPrograms>();
            if (myProgdb != null && myProgdb.Count == 0)
            {
                var prgApi = DummyEmpData.GetCurrentPrograms(); // store in db as EmployerProgram in json
                foreach (var pg in prgApi)
                {
                        var item = new MyPrograms { ProgramId = pg.ProgramId, JSON = JsonConvert.SerializeObject(pg) };
                        db.InsertRecord<MyPrograms>(item);
                }
            }

            // add all programs
            var allProgdb = db.GetTableItems<DBAccess.Programs>();
            if (allProgdb != null && allProgdb.Count == 0)
            {
                var prgApi = DummyEmpData.GetAllPrograms(); // store in db as EmployerProgram in json
                foreach (var pg in prgApi)
                {
                    var item = new DBAccess.Programs { ProgramId = pg.ProgramId, JSON = JsonConvert.SerializeObject(pg) };
                    db.InsertRecord<DBAccess.Programs>(item);
                }
            }

            // current assigned employer services // save as EmployerService
            var servdb = db.GetTableItems<MyServices>();
            if (servdb != null && servdb.Count == 0)
            {
                var prgApi = DummyEmpData.GetEmployerServices(); // store in db as MyServices in json
                foreach (var pg in prgApi)
                {
                    var item = new MyServices { ServiceId = pg.ServiceId, JSON = JsonConvert.SerializeObject(pg) };
                    db.InsertRecord<MyServices>(item);
                }
            }

            // all services
            var allservdb = db.GetTableItems<AllServices>();
            if (allservdb != null && allservdb.Count == 0)
            {
                var prgApi = DummyEmpData.GetALLServices(); // store in db as AllServices in json
                foreach (var pg in prgApi)
                {
                    var item = new AllServices { ServiceId = pg.ServiceId, JSON = JsonConvert.SerializeObject(pg) };
                    db.InsertRecord<AllServices>(item);
                }
            }

            // announcements
            var anndb = db.GetTableItems<Announcement>();
            if (anndb != null && anndb.Count == 0)
            {
                var prgApi = DummyEmpData.GetAnnouncements();
                foreach (var pg in prgApi)
                {
                    try
                    {
                        db.InsertRecord<Announcement>(new Announcement
                        {
                            CompanyName = pg.CompanyName,
                            Description = pg.Description,
                            Featured = false,
                            Image = "",
                            Ttle = pg.Ttle,
                            Url = pg.Url
                        });
                    }
                    catch(Exception ex)
                    {
                        var t = ex.Message;
                    }
                }
            }

            // job applicants list
            var jobappdb = db.GetTableItems<JobApplicant>();
            if (jobappdb != null && jobappdb.Count == 0)
            {
                var prgApi = DummyEmpData.GetCompanyJobApplications(); // store ApplicationProfile as json
                foreach (var pg in prgApi)
                {
                    var item = new JobApplicant
                    {
                        ApplicantId = pg.ApplicationId.ToString(), JobPostId=pg.JobPostId.ToString(), JSON = JsonConvert.SerializeObject(pg)

                    };
                    db.InsertRecord<JobApplicant>(item);
                }
            }

            // search applicants
            var matcheddb = db.GetTableItems<MatchedClients>();
            if (matcheddb != null && matcheddb.Count == 0)
            {
                var prgApi = DummyEmpData.GetCompanyJobApplications(); // store ApplicationProfile as json
                foreach (var pg in prgApi)
                {
                    var item = new MatchedClients
                    {
                        ProfileId = pg.ApplicationId.ToString(),
                        JobPostId = pg.JobPostId.ToString(),
                        JSON = JsonConvert.SerializeObject(pg)

                    };
                    db.InsertRecord<MatchedClients>(item);
                }
            }

            // event data we need
            // add in any events from dummy data
            var eventsDb = db.GetTableItems<EventDetails>();

            if (eventsDb != null && eventsDb.Count == 0)
            {
                var eventList = DummyEmpData.GetEventsList();
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
                            Email = itemEv.Email,
                            PhoneNumber = itemEv.PhoneNumber,
                            JobPostId = itemEv.JobPostId

                        };

                        db.InsertRecord<EventDetails>(item);
                }
            }

            // insert dummy compaints data
            var ComplaintsDb = db.GetTableItems<ComplaintRaised>();

            if (ComplaintsDb != null && ComplaintsDb.Count == 0)
            {
                // fill with new data
                var compaintsData = DummyEmpData.GetComplaintsList();
                foreach (var itemEv in compaintsData)
                {
                        db.InsertRecord<ComplaintRaised>(new ComplaintRaised
                        {
                            ComplaintText = itemEv.ComplaintText,
                            ComplaintId = itemEv.ComplaintId,
                            Subject = itemEv.Subject,
                            Status = itemEv.Status,
                            CreatedOn = itemEv.CreatedOn,
                            ClosedOn = itemEv.ClosedOn,
                            Category = itemEv.Category
                        });
                }
            }

        }
    }
}
