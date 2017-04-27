using System;
using System.Net.Http;

namespace ArabWaha
{
	internal class HttpServiceClient : HttpClient
	{
		private static string baseUrl = "http://10.38.42.23:8080";
		internal HttpServiceClient(string type, String url) : base()
		{
			this.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			this.BaseAddress = new Uri($"{baseUrl}/odata/applications/latest/com.aec.taqat.mobile/");
		}
	}
}