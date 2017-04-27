using System;
using System.Collections.Generic;
using ArabWaha.Helpers;
using Newtonsoft.Json;

namespace ArabWaha
{
	public class MatchedJob
	{
		
		public string JobPostId { get; set; }

		public string JobPostTitle { get; set; }

		public string PublicationStatus { get; set; }

		public string MatchScore { get; set; }

		public object NesIndividualID { get; set; }

		[JsonProperty("maxResultCount")]
		public object MaxResultCount { get; set; }

		[JsonProperty("resultOffset")]
		public object ResultOffset { get; set; }

		[JsonProperty("selectMatchCount")]
		public object SelectMatchCount { get; set; }

		[JsonProperty("language")]
		public object Language { get; set; }

		[JsonProperty("retListValuesByDescription")]
		public object RetListValuesByDescription { get; set; }

		[JsonIgnore]
		public int MatchScoreInt => ParserHelper.ParseStringToInt(MatchScore);

		public string EmployerId { get; set; }

		[JsonIgnore]
		public Company CompanyDetails { get; set; }
	}

	public class MatchedJobList
	{
		[JsonProperty("Result")]
		public IList<MatchedJob> JobMatchedList { get; set; }
	}

	public class MatchedJobListRoot
	{
		[JsonProperty("d")]
		public MatchedJobList MatchedJobList { get; set; }
	}
}
