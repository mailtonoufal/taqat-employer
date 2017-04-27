using System;
using Newtonsoft.Json;

namespace ArabWaha
{

	public class ApplicationFeedback
	{
		[JsonProperty("applicationId")]
		public string ApplicationId { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("applicantName")]
		public string ApplicantName { get; set; }

		[JsonProperty("applicantOccupation")]
		public string ApplicantOccupation { get; set; }

		[JsonProperty("d")]
		public string applicationStatus { get; set; }

		[JsonProperty("employerName")]
		public string EmployerName { get; set; }

		[JsonProperty("individualApplicationId")]
		public string IndividualApplicationId { get; set; }

		[JsonProperty("jobPostId")]
		public string JobPostId { get; set; }

		[JsonProperty("jobPostTitle")]
		public string JobPostTitle { get; set; }

		[JsonProperty("jobProfileId")]
		public string JobProfileId { get; set; }

		[JsonProperty("jobProfileTitle")]
		public string JobProfileTitle { get; set; }

		[JsonProperty("logoID")]
		public string LogoID { get; set; }

		[JsonProperty("logoURL")]
		public string LogoURL { get; set; }

		[JsonProperty("serviceMessage")]
		public string ServiceMessage { get; set; }
	}

	public class FeedbackRoot
	{
		[JsonProperty("d")]
		public ApplicationFeedback ApplicationFeedback { get; set; }
	}
}
