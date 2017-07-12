using System;
using System.Collections.Generic;
using System.Text;
using ArabWaha.Models;

namespace ArabWaha
{
	public static class BatchRequest
	{
		/// <summary>
		/// Generates the company header string for batch.
		/// </summary>
		/// <returns>The company header string for batch.</returns>
		/// <param name="apiName">API name.</param>
		/// <param name="criteriaValueList">Criteria value list.</param>
		public static string GenerateCompanyHeaderStringForBatch(string apiName, IList<AppliedJob> criteriaValueList)
		{
			StringBuilder sbBatchHeader = new StringBuilder();
			foreach (var item in criteriaValueList)
			{
				sbBatchHeader.AppendLine("--batch");
				sbBatchHeader.AppendLine("Content-Type:application/http");
				sbBatchHeader.AppendLine("Content-Transfer-Encoding: binary");
				sbBatchHeader.AppendLine("\r");
				sbBatchHeader.AppendLine(string.Format("GET {0}?$filter=employerId%20eq%20{1}&$format=json HTTP/1.1", apiName, Convert.ToInt64(item.employerId)));
				sbBatchHeader.AppendLine("\r");
				sbBatchHeader.AppendLine("\r");
			}
			sbBatchHeader.Append("--batch--");
			string returnString = sbBatchHeader.ToString();
			return returnString;
		}

		public static string GenerateCompanyHeaderStringForBatch(string apiName, IList<JobDetailsDtoItem> criteriaValueList)
		{
			StringBuilder sbBatchHeader = new StringBuilder();
			foreach (var item in criteriaValueList)
			{
				sbBatchHeader.AppendLine("--batch");
				sbBatchHeader.AppendLine("Content-Type:application/http");
				sbBatchHeader.AppendLine("Content-Transfer-Encoding: binary");
				sbBatchHeader.AppendLine("\r");
				sbBatchHeader.AppendLine(string.Format("GET {0}?$filter=employerId%20eq%20{1}&$format=json HTTP/1.1", apiName, Convert.ToInt64(item.jobDetailsDto.employerId)));
				sbBatchHeader.AppendLine("\r");
				sbBatchHeader.AppendLine("\r");
			}
			sbBatchHeader.Append("--batch--");
			string returnString = sbBatchHeader.ToString();
			return returnString;
		}

		/// <summary>
		/// Generates the job details header.
		/// </summary>
		/// <returns>The job details header.</returns>
		/// <param name="apiName">API name.</param>
		/// <param name="jobPostId">Job post identifier.</param>
		public static string GenerateJobDetailsHeader(List<string> apiName, string jobPostId)
		{
			StringBuilder sbBatchHeader = new StringBuilder();
			foreach (var subitem in apiName)
			{
				sbBatchHeader.AppendLine("--batch");
				sbBatchHeader.AppendLine("Content-Type:application/http");
				sbBatchHeader.AppendLine("Content-Transfer-Encoding: binary");
				sbBatchHeader.AppendLine("\r");
				// pass jobPostId instead of 4568449 on navigating from joblist to details
				sbBatchHeader.AppendLine(string.Format("GET {0}?$filter=jobPostId%20eq%20'{1}'%20and%20language%20eq%20'{2}'&$format=json HTTP/1.1", subitem, "4568449", "en"));
				sbBatchHeader.AppendLine("\r");
				sbBatchHeader.AppendLine("\r");
			}
			sbBatchHeader.Append("--batch--");
			string returnString = sbBatchHeader.ToString();
			return returnString;
		}

		public static string GenerateAppliedJobDetailHeader(List<string> apiName, string jobPostId, long applicationId,long coverLetterId=0)
		{
			StringBuilder sbBatchHeader = new StringBuilder();

			var individualApplicationFilter =
				String.Format("GET IndividualApplicationDetailsSet(nesIndividualID={0},applicationID={1},locale='{2}')?$format=json HTTP/1.1",
							  DebugDataSingleton.Instance.NesIndividualID,
							  applicationId,
							  DebugDataSingleton.Instance.Language);

			var appliedJobDetailNoteFilter =
				String.Format("GET AppliedJobDetailNotesSet?$filter=nesIndividualId%20eq%20'{0}'%20and%20applicationId%20eq%20'{1}'%20and%20locale%20eq%20'{2}'&$format=json HTTP/1.1",
							  DebugDataSingleton.Instance.NesIndividualID,
							  applicationId,
							  DebugDataSingleton.Instance.Language);

			var coverLetterByIdSetFilter =
				String.Format("GET getCoverLetterByIdSet?$filter=nesIndividualId%20eq%20'{0}'%20and%20CoverLetterId%20eq%20'{1}'&$format=json HTTP/1.1",
							  DebugDataSingleton.Instance.NesIndividualID,
				             coverLetterId);


			foreach (var subitem in apiName)
			{
				sbBatchHeader.AppendLine("--batch");
				sbBatchHeader.AppendLine("Content-Type:application/http");
				sbBatchHeader.AppendLine("Content-Transfer-Encoding: binary");
				sbBatchHeader.AppendLine("\r");

				if (subitem == "IndividualApplicationDetailsSet")
					sbBatchHeader.AppendLine(individualApplicationFilter);
				else if (subitem == "AppliedJobDetailNotesSet")
					sbBatchHeader.AppendLine(appliedJobDetailNoteFilter);
				else if (subitem == "getCoverLetterByIdSet")
					sbBatchHeader.AppendLine(coverLetterByIdSetFilter);
				else
					// pass jobPostId instead of 4568449 on navigating from joblist to details
					sbBatchHeader.AppendLine(string.Format("GET {0}?$filter=jobPostId%20eq%20'{1}'%20and%20language%20eq%20'{2}'&$format=json HTTP/1.1", subitem, jobPostId, "en"));

				sbBatchHeader.AppendLine("\r");
				sbBatchHeader.AppendLine("\r");
			}

			sbBatchHeader.Append("--batch--");
			string returnString = sbBatchHeader.ToString();
			return returnString;
		}


		public static string ForProfile()
		{
			string batchRequest = string.Empty;

			StringBuilder sbRequest = new StringBuilder();
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET GetIndividualProfileDetailsSet(nesIndividualId=" + DebugDataSingleton.Instance.NesIndividualID + ")?$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET EducationSet?$filter=nesIndividualId%20eq%20" + DebugDataSingleton.Instance.NesIndividualID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET LicenseSet?$filter=nesIndividualId%20eq%20" + DebugDataSingleton.Instance.NesIndividualID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET ProfessionalExperienceSet?$filter=nesIndividualId%20eq%20" + DebugDataSingleton.Instance.NesIndividualID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET ReferenceSet?$filter=nesIndividualId%20eq%20" + DebugDataSingleton.Instance.NesIndividualID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET CompetencySet?$filter=nesIndividualId%20eq%20" + DebugDataSingleton.Instance.NesIndividualID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET TrainingandCertificateSet?$filter=nesIndividualId%20eq" + DebugDataSingleton.Instance.NesIndividualID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch--");

			batchRequest = sbRequest.ToString();

			return batchRequest;
		}

		public static string ForSurvey(int surveyID)
		{
			string batchRequest = string.Empty;

			StringBuilder sbRequest = new StringBuilder();
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET AnswerOptionSet?$filter=surveyId%20eq%20" + surveyID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET GetSurveyByIdSet?$filter=surveyId%20eq%20" + surveyID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET SurveyQuestionSet?$filter=surveyId%20eq%20" + surveyID + "&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch--");

			batchRequest = sbRequest.ToString();

			return batchRequest;
		}

		public static string ForObligations(string userID, string locale, string date)
		{
			string batchRequest = string.Empty;

			StringBuilder sbRequest = new StringBuilder();
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET getAnnouncementDetailsSet?$filter=UserID%20eq%20'" + userID + "'%20and%20Language%20eq%20'" + locale + "'%20and%20lastLoginTime%20eq%20'" + date + "'&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET getProgramObligationsSet?$filter=userId%20eq%20" + userID + "%20and%20locale%20eq%20'" + locale + "'%20and%20obligationToken%20eq%20'All'&$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch");
			sbRequest.AppendLine("Content-Type:application/http");
			sbRequest.AppendLine("Content-Transfer-Encoding: binary");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("GET tncDetailsModelsSet(individualId=" + userID + ",audienceType='1')?$format=json HTTP/1.1");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("\r");
			sbRequest.AppendLine("--batch--");

			batchRequest = sbRequest.ToString();

			return batchRequest;
		}
	}
}
