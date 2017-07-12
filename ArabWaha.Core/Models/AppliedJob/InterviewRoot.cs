using System;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.AppliedJob
{
	public class InterviewDetails
	{
		[JsonProperty("individualApplicationId")]
		public string IndividualApplicationId { get; set; }

		[JsonProperty("interviewDate")]
		public string InterviewDate { get; set; }
	}

	public class InterviewRoot
	{
		[JsonProperty("d")]
		public InterviewDetails InterviewDetails { get; set; }
	}
}
