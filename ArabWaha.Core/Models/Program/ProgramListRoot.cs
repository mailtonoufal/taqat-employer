using System;
using System.Collections.Generic;
using ArabWaha.Models;
using Newtonsoft.Json;

namespace ArabWaha.Models
{
	//ODATA Model
	public class Programs
	{
		[JsonProperty("userId")]
		public string UserId { get; set; }

		[JsonProperty("programId")]
		public string ProgramId { get; set; }

		[JsonProperty("programName")]
		public string ProgramName { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }

	}
	public class ProgramList
	{
		[JsonProperty("results")]
		public List<Programs> programs { get; set; }
	}

	public class ProgramListRoot
	{
		[JsonProperty("d")]
		public ProgramList programList { get; set; }
	}
}
