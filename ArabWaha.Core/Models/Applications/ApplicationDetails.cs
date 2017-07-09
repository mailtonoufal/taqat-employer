using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.Applications
{
    
	public class ApplicationDetails
	{
		public string applicationID { get; set; }
		public string jobPostTitle { get; set; }
		public string jobPostStartDate { get; set; }
		public string employerLogoId { get; set; }
		public string companyName { get; set; }
		public string salaryTo { get; set; }
		public string salaryFrom { get; set; }
		public string jobPostId { get; set; }
		public string nesIndividualID { get; set; }
        public string language { get; set; }
	}

	public class ApplicationDetailsList
	{
		[JsonProperty("results")]
		public List<ApplicationDetails> applicationDetailsList { get; set; }
	}

	public class ApplicationDetailsObject
	{
		[JsonProperty("d")]
		public ApplicationDetailsList applicationDetailsObject { get; set; }
	}
}
