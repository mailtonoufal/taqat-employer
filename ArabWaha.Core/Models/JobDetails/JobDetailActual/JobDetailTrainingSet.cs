using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	/// <summary>
	/// Job detail training.
	/// </summary>
	public class JobDetailTraining
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty("name")]
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
		[JsonProperty("jobPostId")]
		public string JobPostId { get; set; }
		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		/// <value>The language.</value>
		[JsonProperty("language")]
		public string Language { get; set; }
	}

	/// <summary>
	/// Job detail training set.
	/// </summary>
	public class JobDetailTrainingSet
	{
		/// <summary>
		/// Gets or sets the job detail training.
		/// </summary>
		/// <value>The job detail training.</value>
		[JsonProperty("results")]
		public IList<JobDetailTraining> jobDetailTraining { get; set; }
	}

	/// <summary>
	/// Job detail training set root.
	/// </summary>
	public class JobDetailTrainingSetRoot
	{
		/// <summary>
		/// Gets or sets the job detail training set.
		/// </summary>
		/// <value>The job detail training set.</value>
		[JsonProperty("d")]
		public JobDetailTrainingSet jobDetailTrainingSet { get; set; }
	}
}
