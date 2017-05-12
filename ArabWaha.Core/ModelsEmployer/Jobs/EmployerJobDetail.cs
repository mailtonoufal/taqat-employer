using ArabWaha.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.ModelsEmployer.Jobs
{
    public class EmployerJobDetail
    {

        public EmployerJobDetail()
        {
            // init for new object - ie add new job
            JobLanguages = new ObservableCollection<JobDetailLanguage>();
            JobLicenses = new ObservableCollection<JobDetailLicenses>();
            JobTraining = new ObservableCollection<EmployerJobDetailTraining>();            
        }

        [JsonProperty("jobPostId")]
        public string JobPostId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("jobPostTitle")]
        public string JobPostTitle { get; set; }

        [JsonIgnore]
        public string ApplicationsLanguageText { get; set; }
        [JsonIgnore]
        public string GetJobPostTitle
        {
            get
            {
                return $"{ApplicationsLanguageText} '{JobPostTitle}'";
            }
        }

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

        [JsonProperty("publicationDate")]
        public string PublicationDate { get; set; }

        [JsonProperty("publicationEndDate")]
        public string PublicationEndDate { get; set; }

        [JsonProperty("posted")]
        public string Posted { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("rolesResponsibilities")]
        public string RolesResponsibilities { get; set; }

        [JsonProperty("companyLogo")]
        public string CompanyLogo { get; set; }

        [JsonProperty("companyLocation")]
        public EmployerCompanyLocation CompanyLocation { get; set; }

        [JsonProperty("contactPersonInd")]
        public ContactPersonInd ContactPersonInd { get; set; }

        [JsonProperty("workTime")]
        public string WorkTime { get; set; }
        [JsonProperty("teleworking")]
        public string Teleworking { get; set; }

        [JsonProperty("salaryTo")]
        public string SalaryTo { get; set; }

        [JsonIgnore]
        public string SalaryRange
        {
            get
            {
                return $"{SalaryFrom} - {SalaryTo}";
            }

        }

        [JsonIgnore]
        public string MonthlySalary
        {
            get
            {
                int retVal = 0;
                if (!string.IsNullOrEmpty(SalaryTo))
                {
                    if (int.TryParse(SalaryTo, out retVal))
                    {
                        return $"{retVal / 12}";
                    }
                }
                if(!string.IsNullOrEmpty(SalaryFrom))
                {
                    if (int.TryParse(SalaryFrom, out retVal))
                    {
                        return $"{retVal / 12}";
                    }
                }

                return "n/a";
            }

        }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("shifttype")]
        public string Shifttype { get; set; }

        [JsonProperty("mobility")]
        public string Mobility { get; set; }

        [JsonProperty("otherBenefits")]
        public string OtherBenefits { get; set; }

        [JsonProperty("bonus")]
        public string Bonus { get; set; }

        [JsonProperty("benefits")]
        public string Benefits { get; set; }

        [JsonProperty("surveyUrl")]
        public string SurveyUrl { get; set; }

        [JsonProperty("applicationRequirement")]
        public string ApplicationRequirement { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("Joblanguages")]
        public ObservableCollection<JobDetailLanguage> JobLanguages { get;set;}

        [JsonProperty("JobLicenses")]
        public ObservableCollection<JobDetailLicenses> JobLicenses { get; set; }

        //[JsonProperty("JobSkills")]
        //public ObservableCollection<JobDetailSkills> JobSkills { get; set; }

        [JsonProperty("JobTraining")]
        public ObservableCollection<EmployerJobDetailTraining> JobTraining { get; set; }

        [JsonProperty("RequiresDrivingLicence")]
        public string RequiresDrivingLicence { get; set; }

        [JsonProperty("DrivingLicenceType")]
        public string DrivingLicenceType { get; set; }


        [JsonProperty("benefit2")]
        public string Benefit2 { get; set; }

        [JsonProperty("benefit3")]
        public string Benefit3 { get; set; }

        [JsonProperty("applicationRequirement2")]
        public string ApplicationRequirement2 { get; set; }

        [JsonProperty("applicationRequirement3")]
        public string ApplicationRequirement3 { get; set; }

        [JsonProperty("applicationRequirement4")]
        public string ApplicationRequirement4 { get; set; }

        // new fields we need for matching
        [JsonProperty("MatchScore")]
        public string MatchScore { get; set; }

        [JsonIgnore]
        public int MatchScoreInt
        {
            get
            {
                int val = 0;

                int tx;
                if (int.TryParse(MatchScore, out tx))
                {
                    return tx;
                }
                return val;
            }
        }

        [JsonIgnore]
        public string PostedText { get; set; }

        [JsonIgnore]
        public string GetPostedInfo
        {
            get
            {
                return $"{PostedText} {Posted}";
            }
        }

        [JsonIgnore]
        public string JobStatusText { get; set; }
        [JsonIgnore]
        public string GetJobStatusInfo
        {
            get
            {
                return $"{JobStatusText} {Status}";
            }
        }



    }
}
