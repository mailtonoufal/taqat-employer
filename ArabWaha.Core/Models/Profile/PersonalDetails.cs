using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha.Core.Models.Profile
{
    public class PersonalDetails
    {
        public string employerId { get; set; }
        public string fullName { get; set; }
        public string position { get; set; }
        public string ninIqama { get; set; }
        public string mobileNumber { get; set; }
        public string emailId { get; set; }
        public string assignedUserRole { get; set; }
        public object userName { get; set; }
        public string userType { get; set; }
        public string preferChannel { get; set; }
        public string molAccountStatus { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
        public string cityCode { get; set; }
        public string postalCode { get; set; }
        public object additionalNumber { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public object language { get; set; }
    }

    public class PersonalDetailsList
    {
        [JsonProperty("results")]
        public List<PersonalDetails> personalDetailsList { get; set; }
    }

    public class PersonalDetailsObject
    {
        [JsonProperty("d")]
        public PersonalDetailsList personalDetailsObject { get; set; }
    }
}
