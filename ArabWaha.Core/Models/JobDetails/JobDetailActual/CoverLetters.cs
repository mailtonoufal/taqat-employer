using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	public class CoverLetters
	{
		/// <summary>
		/// Gets or sets the cover letter identifier.
		/// </summary>
		/// <value>The cover letter identifier.</value>
		[JsonProperty("CoverLetterId")]
		public string CoverLetterId { get; set; }
		/// <summary>
		/// Gets or sets the cover letter title.
		/// </summary>
		/// <value>The cover letter title.</value>
		[JsonProperty("coverLetterTitle")]
		public object CoverLetterTitle { get; set; }
		/// <summary>
		/// Gets or sets the cover letter field.
		/// </summary>
		/// <value>The cover letter field.</value>
		[JsonProperty("coverLetterField")]
		public object CoverLetterField { get; set; }
		/// <summary>
		/// Gets or sets the nes individual identifier.
		/// </summary>
		/// <value>The nes individual identifier.</value>
		[JsonProperty("nesIndividualId")]
		public object NesIndividualId { get; set; }
	}

	public class CoverLettersList
	{
		/// <summary>
		/// Gets or sets the cover letter.
		/// </summary>
		/// <value>The cover letter.</value>
		[JsonProperty("results")]
		public IList<CoverLetters> coverLetter { get; set; }
	}

	public class CoverLettersRoot
	{
		/// <summary>
		/// Gets or sets the cover letters list.
		/// </summary>
		/// <value>The cover letters list.</value>
		[JsonProperty("d")]
		public CoverLettersList coverLettersList { get; set; }
	}
}
