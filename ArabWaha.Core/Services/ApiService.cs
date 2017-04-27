using ArabWaha.Core.DBAccess;
using ArabWaha.Core.DBAccess.Employer;
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

        // simulate db with a static set of data for jobs
        static ObservableCollection<EmployerJobDetail> EmployerJobsLocalDb;

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


        public async Task<ObservableCollection<ApplicationProfile>> GetSearchApplicationsAsync(string keyword, string location)
        {
            DbAccessor db = new DbAccessor();
            var source = new ObservableCollection<ApplicationProfile>();

            var dbsource = db.GetTableItemsObservable<JobApplicant>();
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
                Jobs = new ObservableCollection<ApplicationsForJob>()                
            };

            for(int i=0; i< 10; i++)
            {
                companyJobs.Jobs.Add(await GetCompanyJobApplicationsByJobIdAsync(0, 0));
            }
            return companyJobs;
        }

        public async Task<ApplicationsForJob> GetCompanyJobApplicationsByJobIdAsync(int companyId = 0, int jobPostId = 0)
        {

            DbAccessor db = new DbAccessor();
            ApplicationsForJob retVal = new ApplicationsForJob();

            var jb = db.GetTableItems<EmployerJobs>().Where(x => x.JobPostId == jobPostId.ToString()).FirstOrDefault();

            if (jb == null) return retVal; // no job so just return empty object

            retVal.JobDetails = JsonConvert.DeserializeObject<EmployerJobDetail>(jb.JSON);
            retVal.Applications = new ObservableCollection<ApplicationProfile>();

            var dbsource = db.GetTableItemsObservable<JobApplicant>().Where(x=>x.JobPostId==jobPostId.ToString());
            foreach (var item in dbsource)
            {
                retVal.Applications.Add(JsonConvert.DeserializeObject<ApplicationProfile>(item.JSON));
            }

            return retVal;
        }

        // Add Applicaiton/Candidate to Watch list what do we need to pass in - JobPostId, ProfileId??
        public async Task<bool> AddApplicantToWatchList(int JobPostId, int profileId)
        {
            // pull profile and add to watched list
            DbAccessor db = new DbAccessor();

            var client = db.GetTableItems<MatchedClients>().Where(x => x.ProfileId == profileId.ToString()).FirstOrDefault();
            var jb = db.GetTableItems<WatchedClients>().Where(x => x.JobPostId == JobPostId.ToString()
                                && x.ProfileId == profileId.ToString()).FirstOrDefault();

            if (jb != null) return false; // already exists

            db.InsertRecord<WatchedClients>(new WatchedClients { JobPostId=JobPostId.ToString(), ProfileId=profileId.ToString() ,
                  JSON=JsonConvert.SerializeObject(client)  });

            // TODO **** Push to api here

            // add to db table
            return true;
        }

        // DONT UNDERSTAND WHAT THIS IS ACTUALLY BEING USED FOR????? OR TRYING TO DO.. DOESNT SEEM LOGICAL AT ALL. THIS LOOKS WRONG
        // Get the Watch list for the user - returns a list of Applicaiton Profiles. do we we want all applications? 
        public async Task<ObservableCollection<JobPostWatchList>> GetCompanyWatchListAsync(int companyId, int userId)
        {

            DbAccessor db = new DbAccessor();
            var retVal = new ObservableCollection<JobPostWatchList>();

            var watched = db.GetTableItems<WatchedClients>().Where(x => x.AddedById == userId.ToString()); // only get for added user??

            foreach(var jbs in watched)
            {
                var currentJob = db.GetTableItems<EmployerJobs>().Where(x => x.JobPostId == jbs.JobPostId).FirstOrDefault();
                if(currentJob!=null)
                {
                    var details = JsonConvert.DeserializeObject<EmployerJobDetail>(jbs.JSON);

                    var watch = new JobPostWatchList
                    {
                        AddedBy = userId.ToString(),
                        JobPostID = currentJob.JobPostId,
                        JobPostTitle = details.JobPostTitle,
                        JobPostDate = details.PublicationDate
                    };

                    // now add applicants
                    var applicatsx = db.GetTableItems<WatchedClients>().Where(x => x.JobPostId == jbs.JobPostId); // get list of applicants
                    foreach(var appItem in applicatsx)
                    {
                        watch.Applications.Add(JsonConvert.DeserializeObject<ApplicationProfile>(appItem.JSON));
                    }

                    retVal.Add(watch);
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


        public async Task<bool> DeleteCompanyUser(int userId = 0)
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

        // basic sync for db items  
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



        }
    }
}
