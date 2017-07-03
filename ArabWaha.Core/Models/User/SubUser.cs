using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.SubUser
{
  	public class SubUser
	{
		public string eyrUserCredentialId { get; set; }
		public string email { get; set; }
		public string role { get; set; }
		public string username { get; set; }
		public string userType { get; set; }
		public object establishmentId { get; set; }
		public object employerIdentifier { get; set; }
	}

	public class SubUsersList
	{
		[JsonProperty("results")]
		public List<SubUser> subUsersList { get; set; }
	}

	public class SubUsersListObject
	{
		[JsonProperty("d")]
		public SubUsersList subUsersListObject { get; set; }
	}
}
