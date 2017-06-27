using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;

namespace ArabWaha.Core.Models.Company
{
    public class MyCompany
    {
        [PrimaryKey]
        public string establishmentName { get; set; }
        public string logoURL { get; set; }
        public string website { get; set; }
        public string companyDescription { get; set; }
        public string industryTypeId { get; set; }
        public string companySizeListId { get; set; }
        public string languageListId { get; set; }
        public string contactPersonPosition { get; set; }
        public string contactPersonMobile { get; set; }
        public string contactPersonTelephone { get; set; }
        public string contactPersonEmailId { get; set; }
        public string contactPersonGeocodeLattitude { get; set; }
        public string contactPersonGeocodeLongitude { get; set; }
        public string contactPersonStreetName { get; set; }
        public string contactPersonRegion { get; set; }
        public string language { get; set; }
    }

    public class MyCompanyObjectList
    {
		[JsonProperty("results")]
		public List<MyCompany> myCompanyList { get; set; }
    }

    public class MyCompanyObjectRoot
    {
        [JsonProperty("d")]
        public MyCompanyObjectList myCompanyObjectList { get; set; }
    }
}
