using ArabWaha.Helpers;
using Newtonsoft.Json;

namespace ArabWaha.Models.Search
{
    public class SearchResults
    {
        [JsonProperty("__metadata")]
        public Metadata __metadata { get; set; }

        [JsonProperty("JobPostId")]
        public string JobPostId { get; set; }

        [JsonProperty("JobType")]
        public string JobType { get; set; }

        [JsonProperty("JobPostTitle")]
        public string JobPostTitle { get; set; }

        [JsonProperty("PublicationStatus")]
        public string PublicationStatus { get; set; }

        [JsonProperty("match_score")]
        public string MatchScore { get; set; }

        [JsonIgnore]
        public int MatchScoreInt => ParserHelper.ParseStringToInt(MatchScore);

        [JsonIgnore]
        public string MatchScoreString => $"{MatchScoreInt}%";

        [JsonProperty("nesIndividualID")]
        public object NesIndividualID { get; set; }

        [JsonProperty("location")]
        public object Location { get; set; }

        [JsonProperty("Keyword")]
        public object Keyword { get; set; }

        [JsonProperty("WorkTime")]
        public object WorkTime { get; set; }

        [JsonProperty("ShiftType")]
        public object ShiftType { get; set; }

        [JsonProperty("TravellingRequired")]
        public object TravellingRequired { get; set; }

        [JsonProperty("TeleWorking")]
        public object TeleWorking { get; set; }

        [JsonProperty("SalaryTo")]
        public object SalaryTo { get; set; }

        [JsonProperty("SalaryFrom")]
        public object SalaryFrom { get; set; }

        [JsonProperty("RequiredEducation")]
        public object RequiredEducation { get; set; }

        [JsonProperty("Specilization")]
        public object Specilization { get; set; }

        [JsonProperty("employerId")]
        public string EmployerId { get; set; }

        [JsonProperty("Gender")]
        public object Gender { get; set; }

        [JsonProperty("StartDate")]
        public object StartDate { get; set; }
    }

}
