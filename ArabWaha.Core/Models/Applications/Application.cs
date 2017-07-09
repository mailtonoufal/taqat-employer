using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.Applications
{
	public class Application
	{
		public string applicationId { get; set; }
		public string applicant { get; set; }
		public string jobPosttitle { get; set; }
		public string dateOfApplication { get; set; }
        public string language { get; set; }
		public string jobPostId { get; set; }
	}

	public class ApplicationsList
	{
		[JsonProperty("results")]
        public List<Application> applicationsList { get; set; }
	}

	public class ApplicationsListObject
	{
		[JsonProperty("d")]
		public ApplicationsList applicationsListObject { get; set; }
	}
}
