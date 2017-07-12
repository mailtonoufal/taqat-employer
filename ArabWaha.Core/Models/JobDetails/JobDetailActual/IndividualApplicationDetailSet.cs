using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	public class IndividualApplicationDetail
	{
		/// <summary>
		/// Gets or sets the nes individual identifier.
		/// </summary>
		/// <value>The nes individual identifier.</value>
		[JsonProperty("nesIndividualID")]
		public int NesIndividualID { get; set; }
		/// <summary>
		/// Gets or sets the application identifier.
		/// </summary>
		/// <value>The application identifier.</value>
		[JsonProperty("applicationID")]
		public int ApplicationID { get; set; }
		/// <summary>
		/// Gets or sets the locale.
		/// </summary>
		/// <value>The locale.</value>
		[JsonProperty("locale")]
		public string Locale { get; set; }
		/// <summary>
		/// Gets or sets the job post identifier.
		/// </summary>
		/// <value>The job post identifier.</value>
		[JsonProperty("jobPostId")]
		public string JobPostId { get; set; }
		/// <summary>
		/// Gets or sets the job post title.
		/// </summary>
		/// <value>The job post title.</value>
		[JsonProperty("jobPostTitle")]
		public string JobPostTitle { get; set; }
		/// <summary>
		/// Gets or sets the application date.
		/// </summary>
		/// <value>The application date.</value>
		[JsonProperty("applicationDate")]
		public DateTime ApplicationDate { get; set; }

		private string applicationStatusLocal = string.Empty;
		/// <summary>
		/// Gets or sets the application status.
		/// </summary>
		/// <value>The application status.</value>
		[JsonProperty("applicationStatus")]
		public string ApplicationStatus { get; set; }

		//public string ApplicationStatus
		//{
		//	get
		//	{
		//		var dictionoryValue = LocalizationHelper.GetString(applicationStatusLocal);
		//		if (string.IsNullOrEmpty(dictionoryValue)) dictionoryValue = applicationStatusLocal;
		//		return dictionoryValue;
		//	}
		//	set
		//	{
		//		applicationStatusLocal = value;
		//	}
		//}

		[JsonProperty("coverletterId")]
		public string CoverletterId { get; set; }

		//[JsonProperty("applicationStatus")]
		public string ApplicationStatusCode { get { return applicationStatusLocal; } }

	}

	public class IndividualApplicationDetailList
	{
		[JsonProperty("results")]
		public List<IndividualApplicationDetail> IndividualApplicationDetail { get; set; }
	}

	public class IndividualApplicationDetailRoot
	{
		/// <summary>
		/// Gets or sets the individual application detail.
		/// </summary>
		/// <value>The individual application detail.</value>
		[JsonProperty("d")]
		public IndividualApplicationDetailList IndividualApplicationDetailList { get; set; }
	}

}
