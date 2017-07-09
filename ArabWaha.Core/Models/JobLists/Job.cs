using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.JobLists
{
    public class Job
	{
		public string jobPostId { get; set; }
		public string jobPostTitleDisplay { get; set; }
		public string jobPosttitleId { get; set; }
		public string status { get; set; }
		public string startDate { get; set; }
        public string language { get; set; }
	}

	public class JobsList
	{
		[JsonProperty("results")]
		public List<Job> jobsList { get; set; }
	}

	public class JobsListObject
	{
		[JsonProperty("d")]
		public JobsList jobsListObject { get; set; }
	}

}
