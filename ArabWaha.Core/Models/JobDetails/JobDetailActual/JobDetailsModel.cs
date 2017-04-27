using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	/// <summary>
	/// Company location.
	/// </summary>
	public class CompanyLocation
	{
		/// <summary>
		/// Gets or sets the location identifier.
		/// </summary>
		/// <value>The location identifier.</value>
		[JsonProperty("locationId")]
		public string LocationId { get; set; }
		/// <summary>
		/// Gets or sets the latitude.
		/// </summary>
		/// <value>The latitude.</value>
		[JsonProperty("latitude")]
		public string Latitude { get; set; }
		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		[JsonProperty("longitude")]
		public string Longitude { get; set; }
	}

	/// <summary>
	/// Contact person ind.
	/// </summary>
	public class ContactPersonInd
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty("name")]
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		[JsonProperty("email")]
		public string Email { get; set; }
    }

	/// <summary>
	/// Job detail.
	/// </summary>
    public class JobDetail
	{
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
		/// Gets or sets the job description.
		/// </summary>
		/// <value>The job description.</value>
		[JsonProperty("jobDescription")]
		public string JobDescription { get; set; }
		/// <summary>
		/// Gets or sets the type of the job.
		/// </summary>
		/// <value>The type of the job.</value>
		[JsonProperty("jobType")]
		public string JobType { get; set; }
		/// <summary>
		/// Gets or sets the occupations.
		/// </summary>
		/// <value>The occupations.</value>
		[JsonProperty("occupations")]
		public string Occupations { get; set; }
		/// <summary>
		/// Gets or sets the filled position.
		/// </summary>
		/// <value>The filled position.</value>
		[JsonProperty("filledPosition")]
		public string FilledPosition { get; set; }
		/// <summary>
		/// Gets or sets the open positions.
		/// </summary>
		/// <value>The open positions.</value>
		[JsonProperty("openPositions")]
		public string OpenPositions { get; set; }
		/// <summary>
		/// Gets or sets the company industry.
		/// </summary>
		/// <value>The company industry.</value>
		[JsonProperty("companyIndustry")]
		public string CompanyIndustry { get; set; }
		/// <summary>
		/// Gets or sets the experience.
		/// </summary>
		/// <value>The experience.</value>
		[JsonProperty("experience")]
		public string Experience { get; set; }
		/// <summary>
		/// Gets or sets the start date.
		/// </summary>
		/// <value>The start date.</value>
		[JsonProperty("startDate")]
		public string StartDate { get; set; }
		/// <summary>
		/// Gets or sets the education.
		/// </summary>
		/// <value>The education.</value>
		[JsonProperty("education")]
		public string Education { get; set; }
		/// <summary>
		/// Gets or sets the type of the specialization major first level.
		/// </summary>
		/// <value>The type of the specialization major first level.</value>
		[JsonProperty("specializationMajorFirstLevelType")]
		public string SpecializationMajorFirstLevelType { get; set; }
		/// <summary>
		/// Gets or sets the salary from.
		/// </summary>
		/// <value>The salary from.</value>
		[JsonProperty("salaryFrom")]
		public string SalaryFrom { get; set; }
		/// <summary>
		/// Gets or sets the watch list flag.
		/// </summary>
		/// <value>The watch list flag.</value>
		[JsonProperty("watchListFlag")]
		public string WatchListFlag { get; set; }
		/// <summary>
		/// Gets or sets the publication end date.
		/// </summary>
		/// <value>The publication end date.</value>
		[JsonProperty("publicationEndDate")]
		public string PublicationEndDate { get; set; }
		/// <summary>
		/// Gets or sets the name of the company.
		/// </summary>
		/// <value>The name of the company.</value>
		[JsonProperty("companyName")]
		public string CompanyName { get; set; }
		/// <summary>
		/// Gets or sets the company location.
		/// </summary>
		/// <value>The company location.</value>
		[JsonProperty("companyLocation")]
		public CompanyLocation CompanyLocation { get; set; }
		/// <summary>
		/// Gets or sets the contact person ind.
		/// </summary>
		/// <value>The contact person ind.</value>
		[JsonProperty("contactPersonInd")]
		public ContactPersonInd ContactPersonInd { get; set; }
		/// <summary>
		/// Gets or sets the work time.
		/// </summary>
		/// <value>The work time.</value>
		[JsonProperty("workTime")]
		public string WorkTime { get; set; }
		/// <summary>
		/// Gets or sets the teleworking.
		/// </summary>
		/// <value>The teleworking.</value>
		[JsonProperty("teleworking")]
		public string Teleworking { get; set; }
		/// <summary>
		/// Gets or sets the salary to.
		/// </summary>
		/// <value>The salary to.</value>
		[JsonProperty("salaryTo")]
		public string SalaryTo { get; set; }
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		[JsonProperty("status")]
		public string Status { get; set; }
		/// <summary>
		/// Gets or sets the shifttype.
		/// </summary>
		/// <value>The shifttype.</value>
		[JsonProperty("shifttype")]
		public string Shifttype { get; set; }
		/// <summary>
		/// Gets or sets the mobility.
		/// </summary>
		/// <value>The mobility.</value>
		[JsonProperty("mobility")]
		public string Mobility { get; set; }
		/// <summary>
		/// Gets or sets the salaryfrom.
		/// </summary>
		/// <value>The salaryfrom.</value>
		[JsonProperty("salaryfrom")]
		public string Salaryfrom { get; set; }
		/// <summary>
		/// Gets or sets the other benefits.
		/// </summary>
		/// <value>The other benefits.</value>
		[JsonProperty("otherBenefits")]
		public string OtherBenefits { get; set; }
		/// <summary>
		/// Gets or sets the benefits.
		/// </summary>
		/// <value>The benefits.</value>
		[JsonProperty("benefits")]
		public string Benefits { get; set; }
		/// <summary>
		/// Gets or sets the survey URL.
		/// </summary>
		/// <value>The survey URL.</value>
		[JsonProperty("surveyUrl")]
		public string SurveyUrl { get; set; }
		/// <summary>
		/// Gets or sets the application requirement.
		/// </summary>
		/// <value>The application requirement.</value>
		[JsonProperty("applicationRequirement")]
		public string ApplicationRequirement { get; set; }
		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		/// <value>The language.</value>
		[JsonProperty("language")]
		public string Language { get; set; }
		/// <summary>
		/// Gets or sets the benefit2.
		/// </summary>
		/// <value>The benefit2.</value>
		[JsonProperty("benefit2")]
		public string Benefit2 { get; set; }
		/// <summary>
		/// Gets or sets the benefit3.
		/// </summary>
		/// <value>The benefit3.</value>
		[JsonProperty("benefit3")]
		public string Benefit3 { get; set; }
		/// <summary>
		/// Gets or sets the application requirement2.
		/// </summary>
		/// <value>The application requirement2.</value>
		[JsonProperty("applicationRequirement2")]
		public string ApplicationRequirement2 { get; set; }
		/// <summary>
		/// Gets or sets the application requirement3.
		/// </summary>
		/// <value>The application requirement3.</value>
		[JsonProperty("applicationRequirement3")]
		public string ApplicationRequirement3 { get; set; }
		/// <summary>
		/// Gets or sets the application requirement4.
		/// </summary>
		/// <value>The application requirement4.</value>
		[JsonProperty("applicationRequirement4")]
		public string ApplicationRequirement4 { get; set; }
	}

	/// <summary>
	/// Job detail set.
	/// </summary>
	public class JobDetailSet
	{
		/// <summary>
		/// Gets or sets the job detail list.
		/// </summary>
		/// <value>The job detail list.</value>
		[JsonProperty("results")]
		public IList<JobDetail> JobDetailList { get; set; }
	}

	/// <summary>
	/// Job detail set root.
	/// </summary>
	public class JobDetailSetRoot
	{
		/// <summary>
		/// Gets or sets the job detail set.
		/// </summary>
		/// <value>The job detail set.</value>
		[JsonProperty("d")]
		public JobDetailSet jobDetailSet { get; set; }
	}
}
