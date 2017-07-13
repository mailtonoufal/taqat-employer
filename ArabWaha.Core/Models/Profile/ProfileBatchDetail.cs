using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ArabWaha
{
    public class TrainingLocation
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class Address
    {
        [JsonProperty("buildingNumber")]
        public object BuildingNumber { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("geocodeLattitude")]
        public string GeocodeLattitude { get; set; }

        [JsonProperty("geocodeLongitude")]
        public string GeocodeLongitude { get; set; }

        [JsonProperty("postalCode")]
        public int PostalCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("streetName")]
        public string StreetName { get; set; }
    }

    public class IndividualPersonalDetails
    {
        [JsonProperty("nesIndividualId")]
        public int NesIndividualId { get; set; }

        [JsonProperty("individualFirstName")]
        public string IndividualFirstName { get; set; }

        [JsonProperty("individualLastName")]
        public string IndividualLastName { get; set; }

        [JsonProperty("individualDob")]
        public DateTime IndividualDob { get; set; }

        [JsonProperty("maritalStatus")]
        public string MaritalStatus { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("emailId")]
        public string EmailId { get; set; }
    }

    public class IndividualGeneralPreferences
    {
        [JsonProperty("aboutMe")]
        public string AboutMe { get; set; }

        [JsonProperty("shiftTypeId")]
        public string ShiftTypeId { get; set; }

        [JsonProperty("haveLicense")]
        public string HaveLicense { get; set; }

        [JsonProperty("drivingLicenseCategoryId")]
        public string DrivingLicenseCategoryId { get; set; }

        [JsonProperty("profileRefrenceNumber")]
        public int ProfileRefrenceNumber { get; set; }

        [JsonProperty("profileTitle")]
        public string ProfileTitle { get; set; }

        [JsonProperty("profilePercentage")]
        public string ProfilePercentage { get; set; }

        [JsonProperty("isActivelySearching")]
        public string IsActivelySearching { get; set; }
    }

    public class EmploymentPreference
    {
        [JsonProperty("teleworkingId")]
        public string TeleworkingId { get; set; }
    }

    public class ListOfEmploymentPreferences
    {

        public EmploymentPreference EmploymentPreference { get; set; }
    }

    public class GetIndividualProfileDetailsResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public IndividualPersonalDetails IndividualPersonalDetails { get; set; }
        public IndividualGeneralPreferences IndividualGeneralPreferences { get; set; }
        public ListOfEmploymentPreferences ListOfEmploymentPreferences { get; set; }
    }

    public class Result
    {
        //Set 2
        [JsonProperty("nesIndividualId")]
        public int NesIndividualId { get; set; }

        public string MajorAreaOfStudy { get; set; }

        [JsonProperty("collegeId")]
        public string CollegeId { get; set; }

        private DateTime _StartDate;
        [JsonProperty("startDate")]
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {

                if (value != null)
                {
                    _StartDate = value;
                }
            }
        }


        private DateTime _EndDate;
        [JsonProperty("endDate")]
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {

                if (value != null)
                {
                    _EndDate = value;
                }
            }
        }

        [JsonProperty("gpaScaleId")]
        public string GpaScaleId { get; set; }

        [JsonProperty("gpaPointValue")]
        public string GpaPointValue { get; set; }

        [JsonProperty("educationLevel")]
        public string EducationLevel { get; set; }

        [JsonProperty("universityTypeId")]
        public string UniversityTypeId { get; set; }

        //Set 3
        [JsonProperty("licenseName")]
        public string LicenseName { get; set; }


		private DateTime _ExpiryDate;
		[JsonProperty("expiryDate")]
		public DateTime ExpiryDate
		{
			get
			{
				return _ExpiryDate;
			}
			set
			{

				if (value != null)
				{
					_ExpiryDate = value;
				}
			} }

        public int ID { get; set; }

        //Set 4
        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("occupationId")]
        public string OccupationId { get; set; }

        [JsonProperty("sectorId")]
        public string SectorId { get; set; }

        [JsonProperty("salaryFromId")]
        public string SalaryFromId { get; set; }

        [JsonProperty("responsibilities")]
        public string Responsibilities { get; set; }

        //Set 5
        [JsonProperty("referenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("referenceContact")]
        public string ReferenceContact { get; set; }

        [JsonProperty("referenceRole")]
        public string ReferenceRole { get; set; }

        //Set 6
        [JsonProperty("skillId")]
        public string SkillId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("languageLevel")]
        public string LanguageLevel { get; set; }

        [JsonProperty("skillName")]
        public string SkillName { get; set; }

        [JsonProperty("skillLevel")]
        public string SkillLevel { get; set; }

        [JsonProperty("publishSkill")]
        public string PublishSkill { get; set; }

        //Set 7
        [JsonProperty("trainingName")]
        public string TrainingName { get; set; }

        [JsonProperty("instituteName")]
        public string InstituteName { get; set; }

        [JsonProperty("certificateExpiryDate")]
        public DateTime CertificateExpiryDate { get; set; }

        [JsonProperty("trainingLocation")]
        public TrainingLocation TrainingLocation { get; set; }


        //Set8

        public string EmploymentPreferencesID { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string Order { get; set; }
        public string geocodeLattitude { get; set; }
        public string geocodeLongitude { get; set; }



        //Profile Completeness
        public object ProgramCode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public object PersonalProfileCompletionPercentage { get; set; }
        public object CareerProfileCompletionPercentage { get; set; }
        public object ProfileCompletenessPercentage { get; set; }
    }

    public class ProfileBatchDetailSet
    {
        [JsonProperty("nesIndividualId")]
        public int NesIndividualId { get; set; }

        public GetIndividualProfileDetailsResponse GetIndividualProfileDetailsResponse { get; set; }
    }

    public class ProfileBatchDetail
    {
        [JsonProperty("d")]
        public ProfileBatchDetailSet ProfileBatchDetailSet { get; set; }
    }

    public class ProfileBatchDetailResultSet
    {
        public List<Result> results { get; set; }
    }

    public class ProfileBatchDetailResult
    {
        [JsonProperty("d")]
        public ProfileBatchDetailResultSet ProfileBatchDetailResultSet { get; set; }
    }

    public class ProfileBatchDetailContainer
    {
        /// <summary>
        /// IndividualProfileDetailsSet
        /// </summary>
        /// <value>IndividualProfileDetailsSet</value>
        public ProfileBatchDetail ProfileBatchDetail_1 { get; set; }

        /// <summary>
        /// EducationSet
        /// </summary>
        /// <value>EducationSet</value>
        public ProfileBatchDetailResult ProfileBatchDetail_2 { get; set; }

        /// <summary>
        /// LicenseSet
        /// </summary>
        /// <value>LicenseSet</value>
        public ProfileBatchDetailResult ProfileBatchDetail_3 { get; set; }


        /// <summary>
        /// ProfessionalExperienceSet
        /// </summary>
        /// <value>ProfessionalExperienceSet</value>
        public ProfileBatchDetailResult ProfileBatchDetail_4 { get; set; }

        /// <summary>
        /// ReferenceSet
        /// </summary>
        /// <value>ReferenceSet</value>
        public ProfileBatchDetailResult ProfileBatchDetail_5 { get; set; }

        /// <summary>
        /// CompetencySet
        /// </summary>
        /// <value>CompetencySet</value>
        public ProfileBatchDetailResult ProfileBatchDetail_6 { get; set; }

        /// <summary>
        /// TrainingandCertificateSet
        /// </summary>
        /// <value>TrainingandCertificateSet</value>
        public ProfileBatchDetailResult ProfileBatchDetail_7 { get; set; }


        /// <summary>
        /// EmploymentPreferencesSet
        /// </summary>
        /// <value>EmploymentPreferencesSet</value>
        public ProfileBatchDetailResult ProfileBatchDetail_8 { get; set; }
    }

    public class ProfileCompleteness
    {
        public IList<Result> results { get; set; }
    }

    public class ProfileCompletenessRoot
    {
        [JsonProperty("d")]
        public ProfileCompleteness ProfileCompleteness { get; set; }
    }
}
