using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArabWaha.Models.JobDetails
{
    public class JobDetailsData
    {
        [JsonProperty("results")]
        public List<JobDetailsResult> Result { get; set; }
    }
}
