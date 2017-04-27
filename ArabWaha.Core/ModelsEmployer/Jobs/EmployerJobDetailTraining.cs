using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer.Jobs
{
    public class EmployerJobDetailTraining: JobDetailTraining
    {
        [JsonProperty("InstituteName")]
        public string InstituteName { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Validity")]
        public string Validity { get; set; }
    }
}
