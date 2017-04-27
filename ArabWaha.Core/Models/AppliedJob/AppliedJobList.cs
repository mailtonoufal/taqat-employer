using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArabWaha.Models
{
    public class AppliedJobList
    {
        [JsonProperty("results")]
        public List<AppliedJob> Results { get; set; }
    }    
}
