using System;
using System.Net.Http;

namespace ArabWaha
{
    internal class HttpServiceClient : HttpClient
    {
        private static string baseUrl = "http://10.37.37.22:8080";
        internal HttpServiceClient(string type, String url) : base()
        {
            this.Timeout = new TimeSpan(0, 0, 90);
            this.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            this.BaseAddress = new Uri($"{baseUrl}/odata/applications/latest/com.aec.taqat.emp/");
        }
    }
}