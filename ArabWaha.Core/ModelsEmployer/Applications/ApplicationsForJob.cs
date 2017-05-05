using ArabWaha.Core.ModelsEmployer.Jobs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer
{
    public class ApplicationsForJob
    {
        public string JobPostID { get; set; }
        // Job Details
        //JobPostId  from JobDetails
        //JobPostTitle // JPV_003 from JobDetails
        //JobPostDate //JP_10 from JobDetails
        public EmployerJobDetail JobDetails { get; set; }
        public ObservableCollection<ApplicationProfile> Applications { get; set; }

        // utility
        [JsonIgnore]
        public string JobPostInfo
        {
            get { return $"Added {JobDetails.Posted} by {AddedBy}"; }
        }

        [JsonIgnore]
        public string AddedBy
        {
            get { return $"Username"; }
        }
    }
}
