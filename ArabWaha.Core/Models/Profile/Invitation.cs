using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.Profile
{
    public class Invitation
    {
        public string indivisualId { get; set; }
        public object jobPostId { get; set; }
        public object inviteMessage { get; set; }
        public object jobPostTitle { get; set; }
        public object lastUpdatedBy { get; set; }
        public object modifiedByRole { get; set; }
        public string code { get; set; }
        public string mesage { get; set; }
    }


	public class InvitationsList
	{
		[JsonProperty("results")]
		public List<Invitation> invitationsList { get; set; }
	}

	public class InvitationsListObject
	{
		[JsonProperty("d")]
		public InvitationsList invitationsListObject { get; set; }
	}
}
