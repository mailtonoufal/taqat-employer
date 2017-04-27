using ArabWaha.Models.JobDetails;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer.Jobs
{
    public class EmployerCompanyLocation : Companylocation
    {
        [JsonProperty("address")]
        public string Address{ get; set; }

        [JsonProperty("locationNotes")]
        public string LocationNotes { get; set; }


    }
}
