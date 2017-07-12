using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.Appeal
{
    public class Appeal
	{
		public string ObjectId { get; set; }
		public string INDIVIDUAL_COMMENT { get; set; }
		public object language { get; set; }
	}

	public class AppealList
	{
		[JsonProperty("results")]
		public List<Appeal> appealList { get; set; }
	}

	public class AppealListObject
	{
		[JsonProperty("d")]
		public AppealList appealListObject { get; set; }
	}
}
