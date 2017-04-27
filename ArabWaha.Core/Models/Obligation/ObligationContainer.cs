using System;
using System.Collections.Generic;
using ArabWaha.Models;
using Newtonsoft.Json;

namespace ArabWaha
{
	//Entities for Obligation Announcements
	public class ObligationAnnouncement
	{
		[JsonProperty("announcementTitle")]
		public string AnnouncementTitle { get; set; }

		[JsonProperty("announcementDescription")]
		public string AnnouncementDescription { get; set; }

		[JsonProperty("announcementDate")]
		public string AnnouncementDate { get; set; }

		public object UserID { get; set; }

		public object Language { get; set; }

		[JsonProperty("lastLoginTime")]
		public object LastLoginTime { get; set; }

		[JsonProperty("code")]
		public object Code { get; set; }

		[JsonProperty("message")]
		public object Message { get; set; }

		[JsonProperty("errorDetails")]
		public object ErrorDetails { get; set; }
	}

	public class ObligationAnnouncementList
	{
		[JsonProperty("results")]
		public IList<ObligationAnnouncement> ObligationAnnouncements { get; set; }
	}

	public class ObligationAnnouncementRoot
	{
		[JsonProperty("d")]
		public ObligationAnnouncementList ObligationAnnouncementList { get; set; }
	}


	//Entities for Terms and Conditions
	public class TermsAndConditions
	{
		[JsonProperty("individualId")]
		public string IndividualId { get; set; }

		[JsonProperty("audienceType")]
		public string AudienceType { get; set; }

		[JsonProperty("termsAndConditionsText")]
		public string TermsAndConditionsText { get; set; }
	}

	public class TermsAndConditionsRoot
	{
		[JsonProperty("d")]
		public TermsAndConditions TermsAndConditions { get; set; }
	}

	public class ObligationContainer
	{
		public ObligationAnnouncementRoot ObligationAnnouncementRoot { get; set; }
		public ObligationsListRoot ObligationsListRoot  { get; set; }
		public TermsAndConditionsRoot TermsAndConditionsRoot { get; set; }
	}
}
