using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Prism.Commands;

namespace ArabWaha.Core.Models.SubUser
{
  	public class SubUser
	{
		public int eyrUserCredentialId { get; set; }
		public string email { get; set; }
		public string role { get; set; }
		public string username { get; set; }
		public string userType { get; set; }
		public string establishmentId { get; set; }
		public string employerIdentifier { get; set; }
        public bool officialRep { get; set; }
		public bool existFlag { get; set; }
		public string ninIqama { get; set; }

        public DelegateCommand<SubUser> DeleteCommand { get; set; }
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
