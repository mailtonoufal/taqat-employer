using System;
using System.Collections.Generic;
using ArabWaha.Helpers;
using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class AppliedJob
    {
		
		 [JsonProperty("applicationID")]
		public string ApplicationID { get; set; }

        [JsonProperty("jobPostId")]
        public string jobPostId { get; set; }

        [JsonProperty("jobPostTitle")]
        public string jobPostTitle { get; set; }

        [JsonProperty("applicationDate")]
        public string applicationDate { get; set; }

        [JsonProperty("applicationStatus")]
        public string applicationStatus { get; set; }

        [JsonProperty("nesIndividualID")]
        public object nesIndividualID { get; set; }

        [JsonProperty("language")]
        public object language { get; set; }

        [JsonProperty("employerId")]
        public string employerId { get; set; }

		//Matched Jobs
		public string PublicationStatus { get; set; }

		public string MatchScore { get; set; }

		[JsonProperty("maxResultCount")]
		public object MaxResultCount { get; set; }

		[JsonProperty("resultOffset")]
		public object ResultOffset { get; set; }

		[JsonProperty("selectMatchCount")]
		public object SelectMatchCount { get; set; }

		[JsonIgnore]
		public string MatchScoreString
		{
			get
			{
				return "76";
				//return Convert.ToString(MatchScoreInt);
			}
		}
		public string EmployerIdMatched { get; set; }

		[JsonIgnore]
		public int MatchScoreInt
		{
			get
			{
				return 76;
				//return ParserHelper.ParseStringToInt(MatchScore);
			}
		}
		[JsonIgnore]
		public Company CompanyDetails { get; set; }


		//WatchedJob List
		[JsonProperty("watchListId")]
		public string WatchListId { get; set; }

		[JsonProperty("jobTitle")]
		public string JobTitle { get; set; }

		[JsonProperty("insertedDate")]
		public string InsertedDate { get; set; }

		[JsonProperty("matchScore")]
		public string matchScore { get; set; }

    }
}
