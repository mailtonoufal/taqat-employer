using ArabWaha.Core.BaseClasses;
using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer.Company
{
    public class CompanyUserDetails 
    {

        [JsonProperty("companyId")]
        public string CompanyId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("secondName")]
        public string SecondName { get; set; }

        [JsonProperty("thirdName")]
        public string ThirdName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("assignedRole")]
        public string AssignedRole { get; set; }

        [JsonProperty("accountStatus")]
        public string AccountStatus { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("preferredCommunication")]
        public string PreferredCommunication { get; set; }

        [JsonProperty("nin")]
        public string NIN { get; set; }

        [JsonProperty("userType")]
        public string UserType { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get { return $"{FirstName} {SecondName} {ThirdName} {LastName}"; }
        }
    }
}
