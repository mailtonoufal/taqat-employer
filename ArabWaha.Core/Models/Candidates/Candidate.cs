using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.Candidates
{
	public class Candidate
	{
		public string ProfileTitle { get; set; }
		public string StartDate { get; set; }
		public string Gender { get; set; }
		public string City { get; set; }
		public string MatchScore { get; set; }
		public string JobType { get; set; }
		public object NotEmployed { get; set; }
		public object maxResultCount { get; set; }
		public object resultOffset { get; set; }
		public object selectMatchCount { get; set; }
		public string language { get; set; }
		public string retListValuesByDescription { get; set; }
		public string AddedToWatchListFlag { get; set; }
		public string WatchListId { get; set; }
		public string location { get; set; }
		public string Keyword { get; set; }
		public object WorkTime { get; set; }
		public object ShiftType { get; set; }
		public object TravellingRequired { get; set; }
		public object TeleWorking { get; set; }
		public object SalaryTo { get; set; }
		public object SalaryFrom { get; set; }
		public object RequiredEducation { get; set; }
		public object Specilization { get; set; }
		public string employerId { get; set; }
		public string geoLocationLatitude { get; set; }
		public string geoLocationLongitude { get; set; }
		public string regionOrProvince { get; set; }
	}

	public class CandidateList
	{
		[JsonProperty("results")]
		public List<Candidate> candidateList { get; set; }
	}

	public class CandidateListRoot
	{
		[JsonProperty("d")]
		public CandidateList candidateObjectList { get; set; }
	}
}
