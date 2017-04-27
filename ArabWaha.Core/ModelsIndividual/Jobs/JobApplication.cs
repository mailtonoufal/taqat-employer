using ArabWaha.Core.ModelsEmployer.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsIndividual.Jobs
{
    public class JobApplication
    {
        public EmployerJobDetail JobDetails {get;set;}

        public int NesIndividualID { get; set; }
        public int ApplicationID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicationStatus { get; set; }
        public string CoverletterId { get; set; }

    }
}
