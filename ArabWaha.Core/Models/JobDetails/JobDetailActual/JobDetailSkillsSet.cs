using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	/// <summary>
	/// Job detail skills.
	/// </summary>
	public class JobDetailSkills
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>The value.</value>
		[JsonProperty("value")]
		public string Value { get; set; }
		/// <summary>
		/// Gets or sets the job post identifier.
		/// </summary>
		/// <value>The job post identifier.</value>
		[JsonProperty("JobPostId")]
		public string jobPostId { get; set; }
		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		/// <value>The language.</value>
		[JsonProperty("Language")]
		public string language { get; set; }
	}
	/// <summary>
	/// Job detail skills set.
	/// </summary>
	public class JobDetailSkillsSet
	{
		/// <summary>
		/// Gets or sets the job detail skills.
		/// </summary>
		/// <value>The job detail skills.</value>
		[JsonProperty("results")]
		public IList<JobDetailSkills> jobDetailSkills { get; set; }
	}
	/// <summary>
	/// Job detail skills set root.
	/// </summary>
	public class JobDetailSkillsSetRoot
	{
		/// <summary>
		/// Gets or sets the job detail skills set.
		/// </summary>
		/// <value>The job detail skills set.</value>
		[JsonProperty("d")]
		public JobDetailSkillsSet jobDetailSkillsSet { get; set; }
	}

}
