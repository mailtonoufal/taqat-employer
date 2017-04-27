using ArabWaha.Core.ModelsEmployer.Jobs;
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
        // Job Details
        //JobPostId  from JobDetails
        //JobPostTitle // JPV_003 from JobDetails
        //JobPostDate //JP_10 from JobDetails
        public EmployerJobDetail JobDetails { get; set; }
        public ObservableCollection<ApplicationProfile> Applications { get; set; }
    }
}
