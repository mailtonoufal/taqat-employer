using System;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.User
{
    public class ForgotUser
    {
        public string email { get; set; }
		public string userName { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object errorDetails { get; set; }
    }

    public class ForgotUserObject
    {
		[JsonProperty("d")]
		public ForgotUser forgotUserObject { get; set; }
    }
}
