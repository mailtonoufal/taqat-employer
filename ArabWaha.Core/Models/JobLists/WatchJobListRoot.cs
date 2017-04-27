using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	public class WatchJob
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

		public string EmployerId { get; set; }
	}

	public class WatchJobList
	{
		[JsonProperty("Result")]
		public IList<WatchJob> JobWatchList { get; set; }
	}

	public class WatchJobListRoot
	{
		[JsonProperty("d")]
		public WatchJobList WatchJobList { get; set; }
	}


	//Entities for AddJobToWatchList
	public class JobDetailsDto
	{
		public int watchListId { get; set; }
		public string jobId { get; set; }
		public int employerId { get; set; }
		public bool publishedAnonymously { get; set; }
	}

	public class IndividualWatchListEntryDto
	{
		public JobDetailsDto jobDetailsDto { get; set; }
		public int nesIndividualId { get; set; }
		public IndividualWatchListEntryDto() {
			jobDetailsDto = new JobDetailsDto();
		
		}
	}

	public class AddToWatchList
	{
		public int nesIndividualId { get; set; }
		public IndividualWatchListEntryDto individualWatchListEntryDto { get; set; }
		public string modifiedBy { get; set; }
		public AddToWatchList() {
			individualWatchListEntryDto = new IndividualWatchListEntryDto();
		
		}

	}


	//Entities for RemoveJobFromWatchList
	public class WatchListEntryId
	{
		public string watchListId { get; set; }
	}

	public class RemoveFromWatchList
	{
		public long nesIndividualId { get; set; }
		public WatchListEntryId watchListEntryId { get; set; }
	}


	public class JobDetailsDtoWatch
	{
		public string watchListId { get; set; }
		public string jobTitle { get; set; }
		public DateTime insertedDate { get; set; }
		public string employerId { get; set; }
		public string jobPostId { get; set; }
		public string matchScore { get; set; }
        public string ApplicationID { get; set; }

        [JsonIgnore]
		public Company CompanyDetails { get; set; }
	}

	public class JobDetailsDtoItem
	{
		public int nesIndividualId { get; set; }
		public JobDetailsDtoWatch jobDetailsDto { get; set; }
	}

	public class JobDetailsDtoWatchList
	{
		[JsonProperty("results")]
		public IList<JobDetailsDtoItem> JobDetailsDtoList { get; set; }
	}

	public class JobDetailsDtoWatchRoot
	{
		[JsonProperty("d")]
		public JobDetailsDtoWatchList jobDetailsDtoWatchRoot { get; set; }
	}


}
