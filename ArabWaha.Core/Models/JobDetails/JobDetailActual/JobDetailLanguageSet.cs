using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	/// <summary>
	/// Job detail language.
	/// </summary>
	public class JobDetailLanguage
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[JsonProperty("name")]
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets the proficiency level.
		/// </summary>
		/// <value>The proficiency level.</value>
		[JsonProperty("proficiencyLevel")]
		public string ProficiencyLevel { get; set; }
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



        [JsonIgnore]
        public double ProficiencyValue
        {
            get
            {
                double level;
                if(double.TryParse(ProficiencyLevel, out level))
                {
                    return level/100;
                }

                return 0;
            }

        }
	}
	/// <summary>
	/// Job detail language set.
	/// </summary>
	public class JobDetailLanguageSet
	{
		/// <summary>
		/// Gets or sets the results.
		/// </summary>
		/// <value>The results.</value>
		[JsonProperty("results")]
		public IList<JobDetailLanguage> results { get; set; }
	}
	/// <summary>
	/// Job detail language set root.
	/// </summary>
	public class JobDetailLanguageSetRoot
	{
		/// <summary>
		/// Gets or sets the job detail language set.
		/// </summary>
		/// <value>The job detail language set.</value>
		[JsonProperty("d")]
		public JobDetailLanguageSet jobDetailLanguageSet { get; set; }
	}
}
