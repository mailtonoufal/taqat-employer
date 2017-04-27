using Newtonsoft.Json;

namespace ArabWaha.Models
{
    public class AppliedJobListRoot
    {
        [JsonProperty("d")]
        public AppliedJobList AppliedJobListRootItem { get; set; }
    }

	public class JobDetailsDto
	{
		public int watchListId { get; set; }
		public string jobId { get; set; }
		public int employerId { get; set; }
		public bool publishedAnonymously { get; set; }
	}
}
