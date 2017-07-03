using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.User
{
  	public class DeleteUser
	{
		public string userId { get; set; }
		public string code { get; set; }
		public string message { get; set; }
	}

	public class DeleteUserList
	{
		[JsonProperty("results")]
		public List<DeleteUser> deleteUserList { get; set; }
	}

	public class DeleteUserListObject
	{
		[JsonProperty("d")]
		public DeleteUserList deleteUserListObject { get; set; }
	}
}
