using ArabWaha.Models.JobDetails;

namespace ArabWaha.Models.Dummy
{
    public static class DummyJobList
    {
        public static AppliedJobListRoot appliedJobStaticList => new AppliedJobListRoot
        {
            AppliedJobListRootItem = new AppliedJobList
            {
                Results = new System.Collections.Generic.List<AppliedJob>
                {
                    new AppliedJob
                    {
                        applicationDate ="_Posted 2 Months ago",
                        applicationStatus="_Interview Scheduled: Application Status",
                        employerId="Xamarin",
                        jobPostId="2",
                        jobPostTitle="_Software Developer",
                        language="",
                        nesIndividualID=""
                    },
                    new AppliedJob
                    {
                        applicationDate ="_Posted 2 Months ago",
                        applicationStatus="_Interview Scheduled: Application Status",
                        employerId="Xamarin",
                        jobPostId="2",
                        jobPostTitle="_Software Developer",
                        language="",
                        nesIndividualID=""
                    }
                }
            }
        };

        public static JobDetailsRoot jobDetailsStaticList => new JobDetailsRoot
        {
            Data = new JobDetailsData
            {
                Result =  new System.Collections.Generic.List<JobDetailsResult>
                {
                    new JobDetailsResult
                    {
                        JobpostId = "1",
                        JobPostTitle = "Software Developer",
                        JobDescription = "_Interview Scheduled: Application Status",
                        StartDate = "_Posted 2 Months ago",
                        CompanyName = "Xamarin",
                    }
                }
            }
        };

        //new Job {
        //        Title = "_Software Developer",
        //        SubTitle = "_Posted 2 Months ago",
        //        SubTitle2 = "_Interview Scheduled: Application Status",
        //        JobLocationTitle = "_Location",
        //        JobLocation = "_Riyadh, KSA",
        //        JobDeatilsTitle = "Xamarin",
        //        JobDetails = "_Advance Eletronics"
        //    },
    }
}