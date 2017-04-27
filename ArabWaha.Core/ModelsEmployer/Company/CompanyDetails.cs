using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer.Company
{
    public class CompanyDetails
    {
        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("companyLogo")]
        public string CompanyLogo { get; set; }

        [JsonProperty("companyURL")]
        public string CompanyURL { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("companyDescription")]
        public string CompanyDescription { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("companySize")]
        public string CompanySize { get; set; }

        [JsonProperty("profileID")]
        public string ProfileID { get; set; }

        [JsonProperty("preferredLanguage")]
        public string PreferredLanguage { get; set; }

        [JsonProperty("contactName")]
        public string ContactName { get; set; }

        [JsonProperty("contactPosition")]
        public string ContactPosition { get; set; }

        [JsonProperty("contactMobile")]
        public string ContactMobile { get; set; }

        [JsonProperty("contactPhone")]
        public string ContactPhone { get; set; }

        [JsonProperty("contactEmail")]
        public string ContactEmail { get; set; }

    }
}
