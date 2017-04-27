using Newtonsoft.Json;
using System.Collections.Generic;

namespace ArabWaha.Models
{
    public class Program
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty("howToRegister")]
        public string HowToRegister { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("programRequirements")]
        public string ProgramRequirements { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("whoCanBenefit")]
        public string WhoCanBenefit { get; set; }

        [JsonProperty("whyThisProgram")]
        public string WhyThisProgram { get; set; }

		//new fields added  getAllProgramDetailsSet API 
		[JsonProperty("programId")]
		public int ProgramId { get; set; }

		[JsonProperty("programName")]
		public string ProgramName { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("programLogo")]
		public string ProgramLogo { get; set; }

		[JsonProperty("locale")]
		public string Locale { get; set; }

		[JsonProperty("image")]
		public string Image { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }
    }
}
