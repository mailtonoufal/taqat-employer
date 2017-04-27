using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	/// <summary>
	/// Job detail licenses.
	/// </summary>
	public class JobDetailLicenses
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty("name")]
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the havelicense.
		/// </summary>
		/// <value>The havelicense.</value>
		[JsonProperty("havelicense")]
		public string Havelicense { get; set; }
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

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("Expiry")]
        public string Expiry { get; set; }

        [JsonProperty("expiryvalue")]
        public string ExpiryValue { get; set; }


    }

    /// <summary>
    /// Job detail licenses set.
    /// </summary>
    public class JobDetailLicensesSet
	{
		/// <summary>
		/// Gets or sets the job detail licenses.
		/// </summary>
		/// <value>The job detail licenses.</value>
		[JsonProperty("results")]
		public IList<JobDetailLicenses> jobDetailLicenses { get; set; }
	}
	/// <summary>
	/// Job detail licenses set root.
	/// </summary>
	public class JobDetailLicensesSetRoot
	{
		[JsonProperty("d")]
		public JobDetailLicensesSet jobDetailLicensesSet { get; set; }
	}
}
