using Newtonsoft.Json;

namespace ArabWaha.Models.JobDetails
{
    public class Contactpersonind
    {
        [JsonProperty("__metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
