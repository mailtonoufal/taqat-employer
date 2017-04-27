using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	public class AppliedJobNotes
	{
		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		[JsonProperty("message")]
		public string Message { get; set; }
		/// <summary>
		/// Gets or sets the application identifier.
		/// </summary>
		/// <value>The application identifier.</value>
		[JsonProperty("applicationId")]
		public object ApplicationId { get; set; }
		/// <summary>
		/// Gets or sets the nes individual identifier.
		/// </summary>
		/// <value>The nes individual identifier.</value>
		[JsonProperty("nesIndividualId")]
		public object NesIndividualId { get; set; }
		/// <summary>
		/// Gets or sets the locale.
		/// </summary>
		/// <value>The locale.</value>
		[JsonProperty("locale")]
		public object Locale { get; set; }
	}

	public class AppliedJobNotesList
	{
		/// <summary>
		/// Gets or sets the applied job notes.
		/// </summary>
		/// <value>The applied job notes.</value>
		[JsonProperty("results")]
		public IList<AppliedJobNotes> appliedJobNotes { get; set; }
	}

	public class AppliedJobNotesRoot
	{
		/// <summary>
		/// Gets or sets the applied job notes list.
		/// </summary>
		/// <value>The applied job notes list.</value>
		[JsonProperty("d")]
		public AppliedJobNotesList appliedJobNotesList { get; set; }
	}

}
