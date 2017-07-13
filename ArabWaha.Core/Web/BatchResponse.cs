using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ArabWaha.Models;
using Newtonsoft.Json;

namespace ArabWaha
{
	public static class BatchResponse
	{
		//Common Batch Response Parser
		public static List<BatchResponseDetail> Parse(string Response)
		{
			string responseSplitter = new StringReader(Response).ReadLine();
			List<BatchResponseDetail> batchResponseDetailList = new List<BatchResponseDetail>();
			string[] batchResponses = Response.Split(new string[] { responseSplitter }, StringSplitOptions.None);
			foreach (string strResponse in batchResponses)
			{
				if (strResponse.Trim().Length > 0)
				{
					if (strResponse != "--")
					{
						if (strResponse.Contains("HTTP/1.1 200 OK"))
						{
							string[] strBreaks = strResponse.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
							foreach (string str in strBreaks)
							{

								if (str.IndexOf("{\"d\"", StringComparison.Ordinal) >= 0)
								{
									BatchResponseDetail batchResponseDetail = new BatchResponseDetail();
									batchResponseDetail.IndividualBatchResponse = str;
									batchResponseDetailList.Add(batchResponseDetail);
								}
							}
						}
						else
						{
							BatchResponseDetail batchResponseDetail = new BatchResponseDetail();
							batchResponseDetailList.Add(batchResponseDetail);
						}
					}
				}
			}
			return batchResponseDetailList;
		}

		public static ProfileBatchDetailContainer GetProfileDetails(string Response)
		{
			
			ProfileBatchDetailContainer profileBatchDetailContainer = new ProfileBatchDetailContainer();
			try
			{
				List<BatchResponseDetail> batchResponseDetailList = Parse(Response);
                try
                {
					if (batchResponseDetailList[0].IndividualBatchResponse != null)
						profileBatchDetailContainer.ProfileBatchDetail_1 = JsonConvert.DeserializeObject<ProfileBatchDetail>(batchResponseDetailList[0].IndividualBatchResponse.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                try
                {
					if (batchResponseDetailList[1].IndividualBatchResponse != null)
						profileBatchDetailContainer.ProfileBatchDetail_2 = JsonConvert.DeserializeObject<ProfileBatchDetailResult>(batchResponseDetailList[1].IndividualBatchResponse.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                try
                {
					if (batchResponseDetailList[2].IndividualBatchResponse != null)
						profileBatchDetailContainer.ProfileBatchDetail_3 = JsonConvert.DeserializeObject<ProfileBatchDetailResult>(batchResponseDetailList[2].IndividualBatchResponse.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                try
                {
					if (batchResponseDetailList[3].IndividualBatchResponse != null)
						profileBatchDetailContainer.ProfileBatchDetail_4 = JsonConvert.DeserializeObject<ProfileBatchDetailResult>(batchResponseDetailList[3].IndividualBatchResponse.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }


                try
                {
					if (batchResponseDetailList[4].IndividualBatchResponse != null)
						profileBatchDetailContainer.ProfileBatchDetail_5 = JsonConvert.DeserializeObject<ProfileBatchDetailResult>(batchResponseDetailList[4].IndividualBatchResponse.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }


                try
                {
					if (batchResponseDetailList[5].IndividualBatchResponse != null)
						profileBatchDetailContainer.ProfileBatchDetail_6 = JsonConvert.DeserializeObject<ProfileBatchDetailResult>(batchResponseDetailList[5].IndividualBatchResponse.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }


                try
                {
					if (batchResponseDetailList[6].IndividualBatchResponse != null)
						profileBatchDetailContainer.ProfileBatchDetail_7 = JsonConvert.DeserializeObject<ProfileBatchDetailResult>(batchResponseDetailList[6].IndividualBatchResponse.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
               
                try
                {
					if (batchResponseDetailList[7].IndividualBatchResponse != null)
						profileBatchDetailContainer.ProfileBatchDetail_8 = JsonConvert.DeserializeObject<ProfileBatchDetailResult>(batchResponseDetailList[7].IndividualBatchResponse.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }


			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return profileBatchDetailContainer;
		}

		public static SurveyContainer GetSurvey(string Response)
		{

			SurveyContainer SurveyContainer = new SurveyContainer();
			try
			{
				List<BatchResponseDetail> batchResponseDetailList = Parse(Response);
				if (batchResponseDetailList[0].IndividualBatchResponse != null)
					SurveyContainer.SurveyAnswerResultRoot = JsonConvert.DeserializeObject<SurveyAnswerResultRoot>(batchResponseDetailList[0].IndividualBatchResponse.ToString());
				if (batchResponseDetailList[1].IndividualBatchResponse != null)
					SurveyContainer.SurveyResultListRoot = JsonConvert.DeserializeObject<SurveyResultListRoot>(batchResponseDetailList[1].IndividualBatchResponse.ToString());
				if (batchResponseDetailList[2].IndividualBatchResponse != null)
					SurveyContainer.SurveyQuestionResultListRoot = JsonConvert.DeserializeObject<SurveyQuestionResultListRoot>(batchResponseDetailList[2].IndividualBatchResponse.ToString());
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return SurveyContainer;
		}

		public static ObligationContainer GetObligations(string Response)
		{

			ObligationContainer ObligationContainer = new ObligationContainer();
			try
			{
				List<BatchResponseDetail> batchResponseDetailList = Parse(Response);
				if (batchResponseDetailList[0].IndividualBatchResponse != null)
					ObligationContainer.ObligationAnnouncementRoot = JsonConvert.DeserializeObject<ObligationAnnouncementRoot>(batchResponseDetailList[0].IndividualBatchResponse.ToString());
				if (batchResponseDetailList[1].IndividualBatchResponse != null)
					ObligationContainer.ObligationsListRoot = JsonConvert.DeserializeObject<ObligationsListRoot>(batchResponseDetailList[1].IndividualBatchResponse.ToString());
				if (batchResponseDetailList[2].IndividualBatchResponse != null)
					ObligationContainer.TermsAndConditionsRoot = JsonConvert.DeserializeObject<TermsAndConditionsRoot>(batchResponseDetailList[2].IndividualBatchResponse.ToString());

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return ObligationContainer;
		}

		public static List<CompanyObjectRoot> GenerateCompanyModel(string Response)
		{
			ProfileBatchDetailContainer profileBatchDetailContainer = new ProfileBatchDetailContainer();
			List<CompanyObjectRoot> listOfCompanay=null;
			try
			{
				List<BatchResponseDetail> batchResponseDetailList = Parse(Response);
				listOfCompanay = new List<CompanyObjectRoot>();
				foreach (var item in batchResponseDetailList)
				{
					listOfCompanay.Add(JsonConvert.DeserializeObject<CompanyObjectRoot>(item.IndividualBatchResponse.ToString()));
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return listOfCompanay;
		}

		public static JobDetailBatchContainer GenerateAppliedJobDetailModel(string Response)
		{
			JobDetailBatchContainer batchContainer = new JobDetailBatchContainer();

			try
			{
				List<BatchResponseDetail> batchResponseDetailList = Parse(Response);
				if (batchResponseDetailList != null && batchResponseDetailList.Count > 0)
				{
					if (batchResponseDetailList[0].IndividualBatchResponse != null)
						batchContainer.JobDetailSet = (JsonConvert.DeserializeObject<JobDetailSetRoot>(batchResponseDetailList[0].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[1].IndividualBatchResponse != null)
						batchContainer.JobDetailAttachments = (JsonConvert.DeserializeObject<JobDetailAttachmentsSetRoot>(batchResponseDetailList[1].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[2].IndividualBatchResponse != null)
						batchContainer.JobDetailLanguages = (JsonConvert.DeserializeObject<JobDetailLanguageSetRoot>(batchResponseDetailList[2].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[3].IndividualBatchResponse != null)
						batchContainer.JobDetailLicenses = (JsonConvert.DeserializeObject<JobDetailLicensesSetRoot>(batchResponseDetailList[3].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[4].IndividualBatchResponse != null)
						batchContainer.JobDetailSkillsSet = (JsonConvert.DeserializeObject<JobDetailSkillsSetRoot>(batchResponseDetailList[4].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[5].IndividualBatchResponse != null)
						batchContainer.JobDetailTraining = (JsonConvert.DeserializeObject<JobDetailTrainingSetRoot>(batchResponseDetailList[5].IndividualBatchResponse.ToString()));


					//Applicable only for AppliedJobDetails
					if (batchResponseDetailList[6].IndividualBatchResponse != null)
						batchContainer.IndividualApplicationDetail = (JsonConvert.DeserializeObject<IndividualApplicationDetailRoot>(batchResponseDetailList[6].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[7].IndividualBatchResponse != null)
						batchContainer.AppliedJobNotes = (JsonConvert.DeserializeObject<AppliedJobNotesRoot>(batchResponseDetailList[7].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[8].IndividualBatchResponse != null)
						batchContainer.CoverLetters = (JsonConvert.DeserializeObject<CoverLettersRoot>(batchResponseDetailList[8].IndividualBatchResponse.ToString()));
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return batchContainer;
		}


		//Applicable for Matched jobs , Watched Jobs 
		public static JobDetailBatchContainer GenerateJobDetailModel(string Response)
		{
			JobDetailBatchContainer batchContainer = new JobDetailBatchContainer();

			try
			{
				List<BatchResponseDetail> batchResponseDetailList = Parse(Response);
				if (batchResponseDetailList != null && batchResponseDetailList.Count > 0)
				{
					if (batchResponseDetailList[0].IndividualBatchResponse != null)
						batchContainer.JobDetailSet = (JsonConvert.DeserializeObject<JobDetailSetRoot>(batchResponseDetailList[0].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[1].IndividualBatchResponse != null)
						batchContainer.JobDetailAttachments = (JsonConvert.DeserializeObject<JobDetailAttachmentsSetRoot>(batchResponseDetailList[1].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[2].IndividualBatchResponse != null)
						batchContainer.JobDetailLanguages = (JsonConvert.DeserializeObject<JobDetailLanguageSetRoot>(batchResponseDetailList[2].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[3].IndividualBatchResponse != null)
						batchContainer.JobDetailLicenses = (JsonConvert.DeserializeObject<JobDetailLicensesSetRoot>(batchResponseDetailList[3].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[4].IndividualBatchResponse != null)
						batchContainer.JobDetailSkillsSet = (JsonConvert.DeserializeObject<JobDetailSkillsSetRoot>(batchResponseDetailList[4].IndividualBatchResponse.ToString()));
					if (batchResponseDetailList[5].IndividualBatchResponse != null)
						batchContainer.JobDetailTraining = (JsonConvert.DeserializeObject<JobDetailTrainingSetRoot>(batchResponseDetailList[5].IndividualBatchResponse.ToString()));
				}
			}
			catch (Exception er)
			{
				Debug.WriteLine(er);
			}
			return  batchContainer;
		}

	}
}

public class BatchResponseDetail
{
	[JsonProperty("d")]
	public Object IndividualBatchResponse { get; set; }
}
