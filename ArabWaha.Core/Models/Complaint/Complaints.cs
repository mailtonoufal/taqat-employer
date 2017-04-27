using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	/// <summary>
	/// Complaints.
	/// </summary>
	public class Complaints
	{
		/// <summary>
		/// Gets or sets the ip partner no.
		/// </summary>
		/// <value>The ip partner no.</value>
		public string IpPartnerNo { get; set; }
		/// <summary>
		/// Gets or sets the appeal identifier.
		/// </summary>
		/// <value>The appeal identifier.</value>
		public string AppealId { get; set; }
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string Status { get; set; }
		/// <summary>
		/// Gets or sets the complaint identifier.
		/// </summary>
		/// <value>The complaint identifier.</value>
		[JsonProperty("complaint_id")]
		public string Complaint_Id { get; set; }
		/// <summary>
		/// Gets or sets the created on.
		/// </summary>
		/// <value>The created on.</value>
		public string CreatedOn { get; set; }
		/// <summary>
		/// Gets or sets the closed on.
		/// </summary>
		/// <value>The closed on.</value>
		public string ClosedOn { get; set; }
		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		/// <value>The language.</value>
		[JsonProperty("language")]
		public object Language { get; set; }
	}
	/// <summary>
	/// Complaints list.
	/// </summary>
	public class ComplaintsList
	{
		[JsonProperty("results")]
		public IList<Complaints> complaints { get; set; }
	}
	/// <summary>
	/// Complaints list root.
	/// </summary>
	public class ComplaintsListRoot
	{
		[JsonProperty("d")]
		public ComplaintsList complaintsList { get; set; }
	}
}
