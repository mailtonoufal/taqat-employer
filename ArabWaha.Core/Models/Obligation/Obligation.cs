using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class Obligation
    {
        [JsonProperty("obligationApplicationId")]
        public string ObligationApplicationId { get; set; }

        [JsonProperty("userId")]
        public object UserId { get; set; }

        [JsonProperty("dueDate")]
        public string DueDate { get; set; }

        [JsonProperty("obligationCategory")]
        public string ObligationCategory { get; set; }

        [JsonProperty("obligationIcon")]
        public string ObligationIcon { get; set; }

        [JsonProperty("obligationName")]
        public string ObligationName { get; set; }

        [JsonProperty("obligationStatus")]
        public string ObligationStatus { get; set; }

        [JsonProperty("programId")]
        public string ProgramId { get; set; }

        [JsonProperty("surveyId")]
        public string SurveyId { get; set; }

        [JsonProperty("obligationToken")]
        public object ObligationToken { get; set; }

        [JsonProperty("locale")]
        public object Locale { get; set; }
    }
}
