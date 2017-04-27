using System;
using ArabWaha.Models;
using Newtonsoft.Json;

namespace ArabWaha
{
	public class NesDetails
	{
		[JsonProperty("d")]
		public NesObject NesIndividualItem { get; set; }
	}

	public class NesObject
	{
		[JsonProperty("nesIndividualId")]
		public string NesIndividualId { get; set; }

		[JsonProperty("userid")]
		public string UserId { get; set; }
	}

	public class SapBpDetails
	{
		[JsonProperty("d")]
		public SapBpObject SapBpIndividualItem { get; set; }
	}

	public class SapBpObject
	{
		[JsonProperty("individualBpId")]
		public string SapBpIndividualId { get; set; }

		[JsonProperty("userid")]
		public string UserId { get; set; }
	}
}
