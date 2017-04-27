using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class Group
    {
        [JsonProperty("averageSalary")]
        public string AverageSalary { get; set; }

        [JsonProperty("group")]
        public string GroupString { get; set; }

        [JsonProperty("program_id")]
        public int Program_id { get; set; }

        [JsonProperty("totalSalary")]
        public string TotalSalary { get; set; }
    }
}
