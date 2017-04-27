using Newtonsoft.Json;

namespace ArabWaha.Models.JobDetails
{
    public class JobDetailsResult
    {
        [JsonProperty("__metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("jobpostId")]
        public string JobpostId { get; set; }

        [JsonProperty("jobPostTitle")]
        public string JobPostTitle { get; set; }

        [JsonProperty("jobDescription")]
        public string JobDescription { get; set; }

        [JsonProperty("jobType")]
        public string JobType { get; set; }

        [JsonProperty("occupations")]
        public string Occupations { get; set; }

        [JsonProperty("filledPosition")]
        public string FilledPosition { get; set; }

        [JsonProperty("openPositions")]
        public string OpenPositions { get; set; }

        [JsonProperty("companyIndustry")]
        public string CompanyIndustry { get; set; }

        [JsonProperty("experience")]
        public string Experience { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("education")]
        public string Education { get; set; }

        [JsonProperty("specializationMajorFirstLevelType")]
        public string SpecializationMajorFirstLevelType { get; set; }

        [JsonProperty("salaryFrom")]
        public string SalaryFrom { get; set; }

        [JsonProperty("watchListFlag")]
        public string WatchListFlag { get; set; }

        [JsonProperty("publicationEndDate")]
        public string PublicationEndDate { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("companyLocation")]
        public Companylocation CompanyLocation { get; set; }

        [JsonProperty("contactPersonInd")]
        public Contactpersonind ContactPersonInd { get; set; }

        [JsonProperty("workTime")]
        public string WorkTime { get; set; }

        [JsonProperty("teleworking")]
        public string Teleworking { get; set; }

        [JsonProperty("salaryTo")]
        public string SalaryTo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("shifttype")]
        public string Shifttype { get; set; }

        [JsonProperty("mobility")]
        public string Mobility { get; set; }

        [JsonProperty("salaryfrom")]
        public string Salaryfrom { get; set; }

        [JsonProperty("otherBenefits")]
        public string OtherBenefits { get; set; }

        [JsonProperty("benefits")]
        public string Benefits { get; set; }

        [JsonProperty("surveyUrl")]
        public string SurveyUrl { get; set; }

        [JsonProperty("applicationRequirement")]
        public string ApplicationRequirement { get; set; }

        [JsonProperty("language")]
        public object Language { get; set; }
    }
}
