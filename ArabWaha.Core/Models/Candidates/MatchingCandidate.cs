using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.Candidates
{
	public class MatchingCandidate
	{
		public string ProfileTitle { get; set; }
		public string Gender { get; set; }
		public string StartDate { get; set; }
		public string City { get; set; }
		public string MatchScore { get; set; }
		public string JobPostID { get; set; }
		public object maxResultCount { get; set; }
		public object resultOffset { get; set; }
		public object selectMatchCount { get; set; }
		public string language { get; set; }
		public string retListValuesByDescription { get; set; }
		public string AddedToWatchListFlag { get; set; }
		public string WatchListId { get; set; }
	}

	public class MatchingCandidateList
	{
		[JsonProperty("results")]
		public List<MatchingCandidate> results { get; set; }
	}

	public class MatchingCandidateListRoot
	{
		[JsonProperty("d")]
		public MatchingCandidateList matchingCandidateObject { get; set; }
	}
}
