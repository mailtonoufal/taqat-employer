using Newtonsoft.Json;

namespace ArabWaha.Models.JobDetails
{
    public class JobDetailsRoot
    {
        [JsonProperty("d")]
        public JobDetailsData Data { get; set; }
    }
}
