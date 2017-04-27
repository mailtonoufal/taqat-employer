using System;
using Newtonsoft.Json;

namespace ArabWaha
{
	public class WatchListEntryIdResponse
	{
		public object watchListId { get; set; }
	}

	public class ListOfJobPostId
	{
		public object JobPostId { get; set; }
    }

    public class DeleteWatchList
	{
		public int nesIndividualId { get; set; }
		[JsonProperty("watchListEntryId")]
		public WatchListEntryIdResponse watchListEntryId { get; set; }
		public int code { get; set; }
		public string message { get; set; }
		public ListOfJobPostId ListOfJobPostId { get; set; }
	}

	public class DeleteWatchListResponse
	{
		[JsonProperty("d")]
		public DeleteWatchList deleteWatchList { get; set; }
	}
}
