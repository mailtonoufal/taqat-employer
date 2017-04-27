using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	/// <summary>
	/// Company.
	/// </summary>
	public class Company
	{
		/// <summary>
		/// Gets or sets the employer identifier.
		/// </summary>
		/// <value>The employer identifier.</value>
		[JsonProperty("employerId")]
		public int EmployerId { get; set; }
		/// <summary>
		/// Gets or sets the image URL.
		/// </summary>
		/// <value>The image URL.</value>
		[JsonProperty("imageurl")]
		public object ImageUrl { get; set; }
		/// <summary>
		/// Gets or sets the name of the establishment.
		/// </summary>
		/// <value>The name of the establishment.</value>
		[JsonProperty("establishmentName")]
		public string EstablishmentName { get; set; }
		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>The country.</value>
		[JsonProperty("country")]
		public string Country { get; set; }
	}

	/// <summary>
	/// Company object list.
	/// </summary>
	public class CompanyObjectList
	{
		[JsonProperty("results")]
		public IList<Company> companyList { get; set; }
	}

	/// <summary>
	/// Company object root.
	/// </summary>
	public class CompanyObjectRoot
	{
		[JsonProperty("d")]
		public CompanyObjectList companyObjectList { get; set; }
	}
}
