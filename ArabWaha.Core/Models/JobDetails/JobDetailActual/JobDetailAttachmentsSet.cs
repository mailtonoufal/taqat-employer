using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	public class JobDetailAttachments
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty("name")]
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the link.
		/// </summary>
		/// <value>The link.</value>
		[JsonProperty("link")]
		public object Link { get; set; }
		/// <summary>
		/// Gets or sets the job post identifier.
		/// </summary>
		/// <value>The job post identifier.</value>
		[JsonProperty("jobPostId")]
		public object JobPostId { get; set; }
		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		/// <value>The language.</value>
		[JsonProperty("language")]
		public object Language { get; set; }
	}

	public class JobDetailAttachmentsSet
	{
		/// <summary>
		/// Gets or sets the job detail attachments.
		/// </summary>
		/// <value>The job detail attachments.</value>
		[JsonProperty("results")]
		public IList<JobDetailAttachments> jobDetailAttachments { get; set; }
	}

	public class JobDetailAttachmentsSetRoot
	{
		/// <summary>
		/// Gets or sets the job detail attachments set.
		/// </summary>
		/// <value>The job detail attachments set.</value>
		[JsonProperty("d")]
		public JobDetailAttachmentsSet jobDetailAttachmentsSet { get; set; }
	}
}
