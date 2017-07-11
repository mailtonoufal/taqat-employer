using ArabWaha.Enums;
using ArabWaha.Models;
using ArabWaha.Models.JobDetails;
using ArabWaha.Models.Search;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;
using ArabWaha.Enums;
using ArabWaha.Common;
using System.Net.Http.Headers;
using ArabWaha.Core.Models.Company;
using ArabWaha.Core.Models.Candidates;
using ArabWaha.Core.Models.Profile;
using ArabWaha.Core.Models.User;
using ArabWaha.Core.Models.SubUser;
using ArabWaha.Core.Models.Applications;
using ArabWaha.Core.Models.JobLists;

namespace ArabWaha.Web
{
    public class AWHttpClient
    {
        private static AWHttpClient instance;
        public static AWHttpClient Instance => instance ?? (instance = new AWHttpClient());

        private const string HEADER_JSON = "application/json";
        private static string baseUrl = "http://10.37.37.22:8080";
        private string regServiceUrl = $"{baseUrl}/odata/applications/latest/com.aec.taqat.emp/";
        private string serviceUrl = $"{baseUrl}/com.aec.taqat.emp/";

        private RestClient client = new RestClient(new Uri($"{baseUrl}/com.aec.taqat.emp/"));
        private RestClient localClient = new RestClient(new Uri($"{baseUrl}/odata/applications/latest/com.aec.taqat.emp/"));
        //private RestClient likeClient = new RestClient(new Uri("http://arab-waha.staging-like.st/api/"));
        private RestClient likeClient = new RestClient(new Uri("http://arab-waha.development-like.st/api/"));
       
        #region likeClient

        public async Task<IRestResponse<AnnouncementsRoot>> GetAnnouncements()
        {
            var request = new RestRequest("announcements", Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Language", Constants.AcceptLanguage);

            return await likeClient.Execute<AnnouncementsRoot>(request);
        }

        public async Task<IRestResponse<ProgramsRoot>> GetPrograms()
        {
            var request = new RestRequest("programs", Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept-Language", Constants.AcceptLanguage);

            return await likeClient.Execute<ProgramsRoot>(request);
        }

        #endregion

        #region client

        public async Task<IRestResponse<SearchRoot>> GetSearchdJobsList(string keyword = null, JobTypeEnum jobtype = 0, WorkTimeEnum workTime = 0, ShiftTypeEnum shiftType = 0,
                                                                         TravellingRequiredEnum travellingRequired = 0, TeleWorkingEnum teleWorking = 0, int salaryTo = 0,
                                                                         int salaryFrom = 0, RequiredEducationEnum requiredEducation = 0, GenderEnum gender = 0, string location = null)
        {
            var url = "jobPostingSearchSet";

            var parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(DebugDataSingleton.Instance?.NesIndividualID))
                parameters.Add("nesIndividualID", DebugDataSingleton.Instance.NesIndividualID);

            if (!string.IsNullOrEmpty(keyword))
                parameters.Add("Keyword", $"'{keyword}'");

            if (jobtype > 0)
                parameters.Add("JobType", $"'{jobtype.ToString()}'");

            if (workTime > 0)
                parameters.Add("WorkTime", $"'{workTime.ToString()}'");

            if (shiftType > 0)
                parameters.Add("ShiftType", $"'{(int)shiftType}'");

            if (travellingRequired > 0)
                parameters.Add("TravellingRequired", $"'{(int)travellingRequired}'");

            if (teleWorking > 0)
                parameters.Add("TeleWorking", $"'{(int)teleWorking}'");

            if (salaryTo > 0)
                parameters.Add("SalaryTo", $"'{salaryTo}'");

            if (salaryFrom > 0)
                parameters.Add("SalaryFrom", $"'{salaryFrom}'");

            if (requiredEducation > 0)
                parameters.Add("RequiredEducation", $"'{(int)requiredEducation}'");

            if (gender > 0)
                parameters.Add("Gender", $"'{gender.ToString()}'");

            if (!string.IsNullOrEmpty(location))
                parameters.Add("location", $"'{location}'");

            var query = ToQueryString(parameters);

            var request = new RestRequest($"{url}{query}", Method.GET);

            return await ExecuteRequest<SearchRoot>(request);
        }

        internal async Task<ServiceResult<ApplicationDetailsObject>> GetApplicationDetails(string nesIndividualID, string applicationID)
        {
			ServiceResult<ApplicationDetailsObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "ApplicationDetailsSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("ApplicationDetailsSet?$filter=nesIndividualID eq '{0}' and applicationID eq '{1}'", nesIndividualID,applicationID);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<ApplicationDetailsObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<ApplicationDetailsObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
        }

        internal async Task<ServiceResult<JobsListObject>> GetAssignedJobs()
		{
			ServiceResult<JobsListObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "AssignJobPostListSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

					string Apiname = string.Format("AssignJobPostListSet?$filter=language eq '{0}'", DebugDataSingleton.Instance.Language);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<JobsListObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<JobsListObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}

        internal async Task<ServiceResult<WatchJobListRoot>> GetWatchlistJobs()
        {
			ServiceResult<WatchJobListRoot> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "WatchlistJobsListSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

					string Apiname = string.Format("WatchlistJobsListSet?$filter=language eq '{0}'", DebugDataSingleton.Instance.Language);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<WatchJobListRoot>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<WatchJobListRoot>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
        }

		public async Task<ServiceResult<JobsListObject>> GetJobsList()
        {
			ServiceResult<JobsListObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "JobsListSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

					string Apiname = string.Format("JobsListSet?$filter=language eq '{0}'", DebugDataSingleton.Instance.Language);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<JobsListObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<JobsListObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
        }

        public  async Task<ServiceResult<ApplicationsListObject>> GetApplications()
        {
			ServiceResult<ApplicationsListObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "ApplicationsListSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

					string Apiname = string.Format("ApplicationsListSet?$filter=language eq '{0}'", DebugDataSingleton.Instance.Language);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<ApplicationsListObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<ApplicationsListObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
        }

        public async Task<IRestResponse<JobDetailsRoot>> GetJobDetails(string id)
        {
            var url = "getJobDetailsSet";

            var parameters = new Dictionary<string, string>();
            parameters.Add("jobpostId", $"'{id}'");
            parameters.Add("language", "'en'");

            var query = ToQueryString(parameters);

            var request = new RestRequest($"{url}{query}", Method.GET);

            return await ExecuteRequest<JobDetailsRoot>(request);
        }

        private async Task<IRestResponse<T>> ExecuteRequest<T>(RestRequest request)
        {
            if (!string.IsNullOrEmpty(DebugDataSingleton.Instance?.ApplicationConnectionId))
                request.AddHeader("X-SMP-APPCID", DebugDataSingleton.Instance.ApplicationConnectionId);

            request.AddHeader("Accept", "application/json");

            if (!string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth))
                request.AddHeader("Authorization", DebugDataSingleton.Instance.BasicAuth);

            return await client.Execute<T>(request);
        }

        private static string ToQueryString(Dictionary<string, string> pairs)
        {
            var list = pairs.Select(pair => string.Format("{0} eq {1}", pair.Key, pair.Value)).ToList();
            return $"?$filter=" + string.Join(" and ", list);
        }

		#endregion

		//public async Task<IRestResponse<RegistrationObjectRoot>> RegisterUser(string authHeader, string type)
		//{
		//    var request = new RestRequest("Connections", Method.POST) { ContentCollectionMode = ContentCollectionMode.BasicContent };

		//    request.AddHeader("Content-Type", "application/json");
		//    request.AddHeader("Accept", "application/json");
		//    request.AddHeader("authorization", authHeader);

		//    request.AddBody($"{{ \"DeviceType\": \"{type}\"}} ", Encoding.UTF8);

		//    return await localClient.Execute<RegistrationObjectRoot>(request);
		//}

		public async Task<ServiceResult<RegistrationObjectRoot>> RegisterUser(string authHeader, string type)
		{
			ServiceResult<RegistrationObjectRoot> returnVal = null;

			using (HttpServiceClient httpclient = new HttpServiceClient("", "Connections"))
			{
				try
				{
					httpclient.DefaultRequestHeaders.Add("authorization", authHeader);
					var requestBody = new DeviceDetail();
					requestBody.DeviceType = type;
					var requestJson = JsonConvert.SerializeObject(requestBody);
					returnVal = new ServiceResult<RegistrationObjectRoot>();

					var response = await httpclient.PostAsync(regServiceUrl + "Connections", new StringContent(requestJson, Encoding.UTF8, HEADER_JSON));
					if (response.StatusCode == System.Net.HttpStatusCode.Created)
					{
						// all success
						var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						var descontent = JsonConvert.DeserializeObject<RegistrationObjectRoot>(content);
						returnVal.Result = descontent;
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));

					}
				}
				catch (Exception ex)
				{
                    Debug.WriteLine(ex.Message);
					throw ex;
				}

				return returnVal;
			}
		}

        public async Task<ServiceResult<NesDetails>> GetNESIndividualId(string username)
        {
            ServiceResult<NesDetails> returnVal = null;
            string strFullSyncData = "";
            using (HttpServiceClient httpclient = new HttpServiceClient("", "getNesIndividualIdSet"))
            {
                httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                httpclient.DefaultRequestHeaders.Add("X-CSRF-Token", "Fetch");

                string Apiname = "getNesIndividualIdSet(userid='" + username + "')";
                var response = await httpclient.GetAsync(serviceUrl + Apiname);
                returnVal = new ServiceResult<NesDetails>();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                    {
                        using (var reader = new System.IO.StreamReader(stream))
                        {
                            strFullSyncData = reader.ReadToEnd();
                        }
                    }

                    // all success
                    var getNesIndividualResponse = JsonConvert.DeserializeObject<NesDetails>(strFullSyncData);
                    returnVal.IsSuccess = true;
                    returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    returnVal.Result = getNesIndividualResponse;

                    GetResponseHeaders(response.Headers);

                }
                else
                {
                    returnVal.IsSuccess = false;
                    returnVal.Result = null;
                    returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                }
                Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);

                return returnVal;
            }
        }


		public async Task<ServiceResult<NesDetails>> GetXCRFToken()
		{
			ServiceResult<NesDetails> returnVal = null;
			string strFullSyncData = "";
			using (HttpServiceClient httpclient = new HttpServiceClient("", ""))
			{
				httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
				httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
				httpclient.DefaultRequestHeaders.Add("X-CSRF-Token", "Fetch");

				var response = await httpclient.GetAsync(serviceUrl);
				returnVal = new ServiceResult<NesDetails>();
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					using (Stream stream = await httpclient.GetStreamAsync(serviceUrl))
					{
						using (var reader = new System.IO.StreamReader(stream))
						{
							strFullSyncData = reader.ReadToEnd();
						}
					}

					// all success
					var getNesIndividualResponse = JsonConvert.DeserializeObject<NesDetails>(strFullSyncData);
					returnVal.IsSuccess = true;
					returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					returnVal.Result = getNesIndividualResponse;

					GetResponseHeaders(response.Headers);

				}
				else
				{
					returnVal.IsSuccess = false;
					returnVal.Result = null;
					returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
				}
				Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);

				return returnVal;
			}
		}

        public async Task<ServiceResult<SapBpDetails>> GetIndividualSBPId(string userID)
        {
            ServiceResult<SapBpDetails> returnVal = null;
            string strFullSyncData = "";
            using (HttpServiceClient httpclient = new HttpServiceClient("", "getSapBpIdSet"))
            {
                httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                string Apiname = serviceUrl + "getSapBpIdSet(userId=" + userID + ",role='IND')";
                var response = await httpclient.GetAsync(Apiname);
                returnVal = new ServiceResult<SapBpDetails>();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (Stream stream = await httpclient.GetStreamAsync(Apiname))
                    {
                        using (var reader = new System.IO.StreamReader(stream))
                        {
                            strFullSyncData = reader.ReadToEnd();
                        }
                    }

                    // all success
                    var getSapBpIndividualResponse = JsonConvert.DeserializeObject<SapBpDetails>(strFullSyncData);
                    DebugDataSingleton.Instance.SapBpIndividualID = getSapBpIndividualResponse.SapBpIndividualItem.SapBpIndividualId?.ToString();
                }
                else
                {
                    returnVal.IsSuccess = false;
                    returnVal.Result = null;
                    returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                }
                Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                return returnVal;
            }
        }

        void GetResponseHeaders(HttpResponseHeaders header)
        {
            if (header != null)
            {
                foreach (var item in header)
                {
                    string sTemp = String.Format("CacheControl {0}={1}", item.Key, item.Value);
                    if (item.Key == "X-CSRF-Token")
                    {
                        foreach (var item1 in item.Value)
                        {
                            DebugDataSingleton.Instance.X_CSRF_TOKEN = item1;
                        }
                        //DebugDataSingleton.Instance.COOKIE = item.Value.ToString();
                    }
                    if (item.Key == "Set-Cookie")
                    {
                        foreach (var item1 in item.Value)
                        {
                            DebugDataSingleton.Instance.COOKIE += item1 + ";";
                        }

                    }

                }
            }
        }
        //http://10.38.42.23:8080/com.aec.taqat.mobile/getNesIndividualIdSet(userid='ashugupta'

        //public async Task<IRestResponse<AppliedJobListRoot>> GetAppliedJobsList()
        //{
        //    var request = new RestRequest($"getAppliedJobsListSet?$filter=nesIndividualID eq '{DebugDataSingleton.Instance.UserName}' and language eq 'en'", Method.GET);

        //    request.AddHeader("X-SMP-APPCID", DebugDataSingleton.Instance.ApplicationConnectionId);
        //    request.AddHeader("Accept", "application/json");
        //    request.AddHeader("Authorization", DebugDataSingleton.Instance.BasicAuth);

        //    return await client.Execute<AppliedJobListRoot>(request);
        //}

        public async Task<IRestResponse<ObligationsListRoot>> GetObligations()
        {
            string requestUrl = $"getProgramObligationsSet?$filter=userId eq {DebugDataSingleton.Instance.UserName} and locale eq 'en' and obligationToken eq 'All'";
            var request = new RestRequest(requestUrl, Method.GET);

            request.AddHeader("X-SMP-APPCID", DebugDataSingleton.Instance.ApplicationConnectionId);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", DebugDataSingleton.Instance.BasicAuth);

            return await client.Execute<ObligationsListRoot>(request);
        }

        /// <summary>
        /// Gets the profile completeness.
        /// </summary>
        /// <returns>The profile completeness.</returns>
        /// <param name="programCode">Program code.</param>
        public async Task<ProfileCompletenessRoot> GetProfileCompleteness(string programCode)
        {
            ProfileCompletenessRoot returnVal = null;
            string strFullSyncData = "";
            using (HttpServiceClient httpclient = new HttpServiceClient("", "ProfileCompletenessSet"))
            {
                httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                string Apiname = serviceUrl + "ProfileCompletenessSet?$filter=nesIndividualId eq '" + DebugDataSingleton.Instance.NesIndividualID + "' and ProgramCode eq '" + programCode + "'";
                var response = await httpclient.GetAsync(Apiname);
                returnVal = new ProfileCompletenessRoot();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (Stream stream = await httpclient.GetStreamAsync(Apiname))
                    {
                        using (var reader = new System.IO.StreamReader(stream))
                        {
                            strFullSyncData = reader.ReadToEnd();
                        }
                    }

                    // all success
                    returnVal = JsonConvert.DeserializeObject<ProfileCompletenessRoot>(strFullSyncData);
                    //DebugDataSingleton.Instance.SapBpIndividualID = getSapBpIndividualResponse.SapBpIndividualItem.SapBpIndividualId.ToString();

                }
                else
                {
                    //returnVal.IsSuccess = false;
                    //returnVal.Result = null;
                    //returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                }
                Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                return returnVal;
            }
        }

        /// <summary>
        /// Applies for program.
        /// </summary>
        /// <returns>The for program.</returns>
        /// <param name="applyProgram">Apply program.</param>
        public async Task<bool> ApplyForProgram(ApplyProgram applyProgram)
        {
            bool returnVal = false;
            try
            {
                using (HttpClient wc = new HttpClient())
                {
                    wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");
                    wc.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                    wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                    wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                    var requestBody = new ApplyProgram();
                    requestBody = applyProgram;

                    var requestJson = JsonConvert.SerializeObject(requestBody);

                    byte[] dataBytes = Encoding.UTF8.GetBytes(requestJson);
                    ByteArrayContent content = new ByteArrayContent(dataBytes);
                    var responseBytes = await wc.PostAsync(serviceUrl + "applyForProgramSet", content);
                    byte[] response = await responseBytes.Content.ReadAsByteArrayAsync();

                    string responseString = Encoding.UTF8.GetString(response, 0, response.Length);
                    returnVal = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return returnVal;
        }

        /// <summary>
        /// Gets the individual profile batch.
        /// </summary>
        /// <returns>The individual profile batch.</returns>
        public async Task<ProfileBatchDetailContainer> GetIndividualProfileBatch()
        {
            ProfileBatchDetailContainer returnVal = null;

            using (HttpClient wc = new HttpClient())
            {

                ////wc.DefaultRequestHeaders.Add(HttpRequestHeader.Cookie, DebugDataSingleton.Instance.COOKIE);
                wc.DefaultRequestHeaders.Add("ContentType", "multipart/mixed;boundary=batch");
                wc.DefaultRequestHeaders.Add("Accept", "multipart/mixed;boundary=batch, text/javascript, */*; q=0.01");
                wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                string body = BatchRequest.ForProfile();
                StringContent content = new StringContent(body);
                var response = await wc.PostAsync(serviceUrl + "$batch", content);

                returnVal = BatchResponse.GetProfileDetails(await response.Content.ReadAsStringAsync());
            }

            return returnVal;
        }

        /// <summary>
        /// Generates the company header string for batch.
        /// </summary>
        /// <returns>The company header string for batch.</returns>
        /// <param name="apiName">API name.</param>
        /// <param name="criteriaValueList">Criteria value list.</param>
        public string GenerateCompanyHeaderStringForBatch(string apiName, IList<AppliedJob> criteriaValueList)
        {
            string authHeader = "Authorization:" + DebugDataSingleton.Instance.BasicAuth;
            string X_SMP_APPCIDHeader = "X-SMP-APPCID:" + DebugDataSingleton.Instance.X_SMP_APPCID;
            string acceptHeader = "Accept:application/json";
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

        /// <summary>
        /// Generates the job details header.
        /// </summary>
        /// <returns>The job details header.</returns>
        /// <param name="apiName">API name.</param>
        /// <param name="criteriaValueList">Criteria value list.</param>
        public string GenerateJobDetailsHeader(List<string> apiName, IList<AppliedJob> criteriaValueList)
        {
            string authHeader = "Authorization:" + DebugDataSingleton.Instance.BasicAuth;
            string X_SMP_APPCIDHeader = "X-SMP-APPCID:" + DebugDataSingleton.Instance.X_SMP_APPCID;
            string acceptHeader = "Accept:application/json";
            StringBuilder sbBatchHeader = new StringBuilder();
            foreach (var item in criteriaValueList)
            {
                foreach (var subitem in apiName)
                {
                    sbBatchHeader.AppendLine("--batch");
                    sbBatchHeader.AppendLine("Content-Type:application/http");
                    sbBatchHeader.AppendLine("Content-Transfer-Encoding: binary");
                    sbBatchHeader.AppendLine("\r");
                    sbBatchHeader.AppendLine(string.Format("GET {0}?$filter=jobPostId%20eq%20'{1}'%20and%20language%20eq%20'{2}'&$format=json HTTP/1.1", subitem, item.jobPostId, "en"));
                    sbBatchHeader.AppendLine("\r");
                    sbBatchHeader.AppendLine("\r");
                }
            }
            sbBatchHeader.Append("--batch--");
            string returnString = sbBatchHeader.ToString();
            return returnString;
        }
        /// <summary>
        /// Executes the batch.
        /// </summary>
        /// <returns>The batch.</returns>
        /// <param name="inputHeader">Input header.</param>
        /// <param name="batchName">Batch name.</param>
        public async Task<ServiceResult<JobDetailBatchContainer>> ExecuteBatchAsync(string inputHeader)
        {
            ServiceResult<JobDetailBatchContainer> returnVal = new ServiceResult<JobDetailBatchContainer>();

            try
            {
                using (HttpClient wc = new HttpClient())
                {

                    wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("ContentType", "multipart/mixed;boundary=batch");
                    wc.DefaultRequestHeaders.Add("Accept", "multipart/mixed;boundary=batch, text/javascript, */*; q=0.01");
                    wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                    wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    string body = inputHeader;
                    StringContent content = new StringContent(body);
                    var responseString = await wc.PostAsync(serviceUrl + "$batch", content);
                    //if (batchName == "COMPANY")
                    //{
                    //	var companyBatchresut = BatchResponse.GenerateCompanyModel(responseString);
                    //	returnVal.Result = companyBatchresut;
                    //}
                    //else if (batchName == "JOBDETAIL")
                    //{
                    var jobBatchresut = BatchResponse.GenerateAppliedJobDetailModel(await responseString.Content.ReadAsStringAsync());
                    returnVal.Result = jobBatchresut;
                    //}

                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return returnVal;
        }

        public async Task<List<CompanyObjectRoot>> ExecuteCompanyBatchAsync(string inputHeader, string batchName)
        {
            List<CompanyObjectRoot> returnVal = null;

            try
            {
                using (HttpClient wc = new HttpClient())
                {

                    wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("ContentType", "multipart/mixed;boundary=batch");
                    wc.DefaultRequestHeaders.Add("Accept", "multipart/mixed;boundary=batch, text/javascript, */*; q=0.01");
                    wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                    wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    string body = inputHeader;
                    StringContent content = new StringContent(body);
                    var responseString = await wc.PostAsync(serviceUrl + "$batch", content);
                    if (batchName == "COMPANY")
                    {
                        var companyBatchresut = BatchResponse.GenerateCompanyModel(await responseString.Content.ReadAsStringAsync());
                        returnVal = companyBatchresut;
                    }
                    //else if (batchName == "JOBDETAIL")
                    //{
                    //	var jobBatchresut = BatchResponse.GenerateAppliedJobDetailModel(responseString);
                    //	returnVal = jobBatchresut;
                    //}

                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return returnVal;
        }

        public async Task<IRestResponse<AppliedJobListRoot>> GetAppliedJobsList()
        {
            var request = new RestRequest($"getAppliedJobsListSet?$filter=nesIndividualID eq '{DebugDataSingleton.Instance.NesIndividualID}' and language eq 'en'", Method.GET);

            request.AddHeader("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", DebugDataSingleton.Instance.BasicAuth);

            var result = await client.Execute<AppliedJobListRoot>(request);
            return result;
        }

        /// <summary>
        /// Gets the applied jobs list1.
        /// </summary>
        /// <returns>The applied jobs list1.</returns>
        public async Task<ServiceResult<AppliedJobListRoot>> GetAppliedJobsListService()
        {
            ServiceResult<AppliedJobListRoot> returnVal = null;
            try
            {
                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "getAppliedJobsListSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("getAppliedJobsListSet?$filter=nesIndividualID eq '{0}' and language eq '{1}'", DebugDataSingleton.Instance.NesIndividualID, "en");
                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<AppliedJobListRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var getNesIndividualResponse = JsonConvert.DeserializeObject<AppliedJobListRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = getNesIndividualResponse;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    //Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }

        /// <summary>
        /// Gets the matched jobs list.
        /// </summary>
        /// <returns>The matched jobs list.</returns>
        public async Task<ServiceResult<AppliedJobListRoot>> GetMatchedJobsList()

        {
            ServiceResult<AppliedJobListRoot> returnVal = null;
            try
            {
                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "getJobsMatchedSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);


                    var nesIndId = "6308402";
                    string Apiname = "getJobsMatchedSet?$filter=NesIndividualID eq '" + nesIndId + "' and maxResultCount eq '10' and resultOffset eq '0' and selectMatchCount eq 'true' and language eq 'en'";
                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<AppliedJobListRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var getMatchedJobList = JsonConvert.DeserializeObject<AppliedJobListRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = getMatchedJobList;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }

        /// <summary>
        /// Gets the watch job list.
        /// </summary>
        /// <returns>The watch job list.</returns>
        public async Task<ServiceResult<JobDetailsDtoWatchRoot>> GetWatchJobList()
        {
            ServiceResult<JobDetailsDtoWatchRoot> returnVal = null;
            try
            {
                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "WatchListSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    var nesindid = "6308402";
                    string Apiname = string.Format("WatchListSet?$filter=nesIndividualId eq {0}", nesindid);// DebugDataSingleton.Instance.NesIndividualID);
                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<JobDetailsDtoWatchRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var getWatchJobList = JsonConvert.DeserializeObject<JobDetailsDtoWatchRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = getWatchJobList;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }

        /// <summary>
        /// Adds the job to watch list.
        /// </summary>
        /// <returns>The job to watch list.</returns>
        /// <param name="addToWatchList">Add to watch list.</param>
        public async Task<bool> AddJobToWatchList(AddToWatchList addToWatchList)
        {
            bool returnVal = false;
            try
            {
                using (HttpClient wc = new HttpClient())
                {

                    wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");
                    wc.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                    wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                    wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    var requestJson = JsonConvert.SerializeObject(addToWatchList);

                    byte[] dataBytes = Encoding.UTF8.GetBytes(requestJson);
                    ByteArrayContent content = new ByteArrayContent(dataBytes);
                    var responseBytes = await wc.PostAsync(new Uri(serviceUrl + "UpdateIndividualWatchListSet"), content);
                    byte[] response = await responseBytes.Content.ReadAsByteArrayAsync();
                    string responseString = Encoding.UTF8.GetString(response, 0, response.Length);
                    returnVal = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return returnVal;
        }



        /// <summary>
        /// Deletes the job from watch list.
        /// </summary>
        /// <returns>The job from watch list.</returns>
        /// <param name="removeFromWatchList">Remove from watch list.</param>
        public async Task<bool> DeleteJobFromWatchList(RemoveFromWatchList removeFromWatchList)
        {
            bool returnVal = false;
            try
            {
                using (HttpClient wc = new HttpClient())
                {

                    wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");
                    wc.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                    wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                    wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    var requestJson = JsonConvert.SerializeObject(removeFromWatchList);

                    byte[] dataBytes = Encoding.UTF8.GetBytes(requestJson);
                    ByteArrayContent content = new ByteArrayContent(dataBytes);
                    var responseBytes = await wc.PostAsync(new Uri(serviceUrl + "DeleteIndividualWatchListSet"), content);
                    byte[] response = await responseBytes.Content.ReadAsByteArrayAsync();
                    string responseString = Encoding.UTF8.GetString(response, 0, response.Length);
                    returnVal = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return returnVal;
        }

        public async Task<ServiceResult<DeleteWatchListResponse>> DeleteJobFromWatchListAsync(RemoveFromWatchList removeFromWatchList)
        {
            ServiceResult<DeleteWatchListResponse> returnResponse = new ServiceResult<DeleteWatchListResponse>();
            try
            {
                using (HttpClient wc = new HttpClient())
                {

                    wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");
                    wc.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                    wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                    wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    var requestJson = JsonConvert.SerializeObject(removeFromWatchList);

                    byte[] dataBytes = Encoding.UTF8.GetBytes(requestJson);
                    ByteArrayContent content = new ByteArrayContent(dataBytes);
                    var responseBytes = await wc.PostAsync(new Uri(serviceUrl + "DeleteIndividualWatchListSet"), content);
                    byte[] response = await responseBytes.Content.ReadAsByteArrayAsync();
                    string responseString = Encoding.UTF8.GetString(response, 0, response.Length);
                    DeleteWatchListResponse responseObject = JsonConvert.DeserializeObject<DeleteWatchListResponse>(responseString);
                    //returnVal = true;
                    if (responseObject != null)
                    {
                        returnResponse.IsSuccess = true;
                        returnResponse.StatusCode = "201";
                        returnResponse.Result = responseObject;
                    }
                    else
                    {
                        returnResponse.IsSuccess = false;
                        returnResponse.StatusCode = "500";
                        returnResponse.Result = null;
                    }
                    return returnResponse;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return returnResponse;
        }


        /// <summary>
        /// Gets the job matching search for Guest and Individual
        /// </summary>
        /// <returns>The job matching search.</returns>
        /// <param name="searchFilter">Search filter.</param>
        //for guest searchFilter will be ?$filter=location eq 'Riyadh' and Keyword eq 'test' 
        //for individual searchFilter will be  ?$filter=Keyword eq 'test'
        public async Task<ServiceResult<AppliedJobListRoot>> GetJobMatchingSearch(string searchFilter)
        {
            ServiceResult<AppliedJobListRoot> returnVal = null;
            try
            {
                string parameter = String.Format("filter=nesIndividualID eq {0} ", DebugDataSingleton.Instance.NesIndividualID);
                if (searchFilter != "")
                {
                    parameter = String.Concat(parameter, "and ", searchFilter);
                }

                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "jobPostingSearchSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Concat("jobPostingSearchSet?$", parameter);
                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<AppliedJobListRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var getNesIndividualResponse = JsonConvert.DeserializeObject<AppliedJobListRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = getNesIndividualResponse;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    //Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }

        /// <summary>
        /// Gets the complaints.
        /// </summary>
        /// <returns>The complaints.</returns>
        /// <param name="searchFilter">Search filter.</param>
        public async Task<ServiceResult<ComplaintsListRoot>> GetComplaints()
        {
            ServiceResult<ComplaintsListRoot> returnVal = null;
            try
            {
                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "TAppealsSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("TAppealsSet?$filter=IpPartnerNo eq '{0}' and IpLang eq 'E'", DebugDataSingleton.Instance.SapBpIndividualID);
                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<ComplaintsListRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var modelResponse = JsonConvert.DeserializeObject<ComplaintsListRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = modelResponse;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    //Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }



		/// <summary>
        /// Gets the company details.
        /// </summary>
        /// <returns>The company details.</returns>
		public async Task<ServiceResult<MyCompanyObjectRoot>> GetCompanyDetails()
		{
			ServiceResult<MyCompanyObjectRoot> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "MyCompanySet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("MyCompanySet?$filter=language eq '{0}'",DebugDataSingleton.Instance.Language);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<MyCompanyObjectRoot>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<MyCompanyObjectRoot>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}




		/// <summary>
        /// Gets the candidates list.
        /// </summary>
        /// <returns>The candidates list.</returns>
        public async Task<ServiceResult<CandidateListRoot>> GetCandidatesList(string jobType)
		{
			ServiceResult<CandidateListRoot> returnVal = null;

			//if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "CandidatesListSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("CandidatesListSet?$filter={0}",jobType);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<CandidateListRoot>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<CandidateListRoot>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}


		/// <summary>
        /// Gets the matching candidates list.
        /// </summary>
        /// <returns>The matching candidates list.</returns>
        /// <param name="jobPostID">Job post identifier.</param>
        public async Task<ServiceResult<MatchingCandidateListRoot>> GetMatchingCandidatesList(string jobPostID)
		{
			ServiceResult<MatchingCandidateListRoot> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "MatchingCandidatesSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("MatchingCandidatesSet?$filter=JobPostID eq '{0}'",jobPostID);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<MatchingCandidateListRoot>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<MatchingCandidateListRoot>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}


        public async Task<ServiceResult<DeleteUserListObject>> DeleteUser(string userId)
		{
			ServiceResult<DeleteUserListObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "DeleteUserSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("DeleteUserSet?$filter=userId eq '{0}'", userId);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<DeleteUserListObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<DeleteUserListObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}

        public async Task<ServiceResult<SubUsersListObject>> GetSubUser(string establishmentId, string employerIdentifier)
		{
			ServiceResult<SubUsersListObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "EmployerSubUserSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("EmployerSubUserSet?$filter=establishmentId eq '{0}' and employerIdentifier eq '{1}'", establishmentId,employerIdentifier);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<SubUsersListObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<SubUsersListObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}

        public async Task<ServiceResult<PersonalDetailsObject>> GetPersonalDetails()
		{
			ServiceResult<PersonalDetailsObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "PersonalDetailsSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

					string Apiname = string.Format("PersonalDetailsSet?$filter=language eq '{0}'", DebugDataSingleton.Instance.Language);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<PersonalDetailsObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<PersonalDetailsObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}

        public async Task<ServiceResult<ForgotUserObject>> ForgotUserName(string email)
		{
			ServiceResult<ForgotUserObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "forgetEmployerUsernameSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("forgetEmployerUsernameSet(email='{0}')", email);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<ForgotUserObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<ForgotUserObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}


		public async Task<ServiceResult<ForgotUserObject>> ForgotPassword(string username)
		{
			ServiceResult<ForgotUserObject> returnVal = null;

			if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

			try
			{
				string strFullSyncData = "";
				using (HttpServiceClient httpclient = new HttpServiceClient("", "forgetEmployerPasswordSet"))
				{
					httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
					httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("forgetEmployerPasswordSet(userName='{0}')", username);
					var response = await httpclient.GetAsync(serviceUrl + Apiname);
					returnVal = new ServiceResult<ForgotUserObject>();
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
						{
							using (var reader = new System.IO.StreamReader(stream))
							{
								strFullSyncData = reader.ReadToEnd();
							}
						}

						// all success
						var getNesIndividualResponse = JsonConvert.DeserializeObject<ForgotUserObject>(strFullSyncData);
						returnVal.IsSuccess = true;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
						returnVal.Result = getNesIndividualResponse;
					}
					else
					{
						returnVal.IsSuccess = false;
						returnVal.Result = null;
						returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
					}
					//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
					return returnVal;
				}
			}
			catch (Exception ex)
			{
				return returnVal;

			}
			finally
			{
			}
		}

        /// <summary>
        /// Gets all programs.
        /// </summary>
        /// <returns>The all programs.</returns>
        public async Task<ServiceResult<ProgramListRoot>> GetAllPrograms()
        {
            ServiceResult<ProgramListRoot> returnVal = null;

            if (string.IsNullOrEmpty(DebugDataSingleton.Instance?.BasicAuth)) return returnVal;

            try
            {
                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "getAllProgramDetailsSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("getAllProgramDetailsSet?$filter=userId eq {0} and language eq '{1}'", DebugDataSingleton.Instance.NesIndividualID, "en");
                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<ProgramListRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var getNesIndividualResponse = JsonConvert.DeserializeObject<ProgramListRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = getNesIndividualResponse;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    //Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }

        public async Task<bool> ApplyForJob(ApplyJob ApplyJob)
        {
            bool returnVal = false;
            try
            {
                using (HttpClient wc = new HttpClient())
                {

                    wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");
                    wc.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                    wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                    wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    var requestJson = JsonConvert.SerializeObject(ApplyJob);

                    byte[] dataBytes = Encoding.UTF8.GetBytes(requestJson);
                    ByteArrayContent content = new ByteArrayContent(dataBytes);
                    var responseBytes = await wc.PostAsync(new Uri(serviceUrl + "applyForJobSet"), content);
                    byte[] response = await responseBytes.Content.ReadAsByteArrayAsync();
                    string responseString = Encoding.UTF8.GetString(response, 0, response.Length);
                    returnVal = true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return returnVal;
        }

        public async Task<SurveyContainer> GetSurveyBatch(int surveyID)
        {
            SurveyContainer returnVal = null;

            using (HttpClient wc = new HttpClient())
            {

                wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                wc.DefaultRequestHeaders.Add("ContentType", "multipart/mixed;boundary=batch");
                wc.DefaultRequestHeaders.Add("Accept", "multipart/mixed;boundary=batch, text/javascript, */*; q=0.01");
                wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                string body = BatchRequest.ForSurvey(surveyID);
                StringContent content = new StringContent(body);
                var responseString = await wc.PostAsync(serviceUrl + "$batch", content);

                returnVal = BatchResponse.GetSurvey(await responseString.Content.ReadAsStringAsync());
            }

            return returnVal;
        }

        /// <summary>
        /// Gets the obligations batch.
        /// </summary>
        /// <returns>The obligations container.</returns>
        public async Task<ObligationContainer> GetObligationsBatch(string date)
        {
            ObligationContainer returnVal = null;

            using (HttpClient wc = new HttpClient())
            {

                //wc.DefaultRequestHeaders.Add(HttpRequestHeader.Cookie, DebugDataSingleton.Instance.COOKIE);
                wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                wc.DefaultRequestHeaders.Add("ContentType", "multipart/mixed;boundary=batch");
                wc.DefaultRequestHeaders.Add("Accept", "multipart/mixed;boundary=batch, text/javascript, */*; q=0.01");
                wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                string body = BatchRequest.ForObligations(DebugDataSingleton.Instance.NesIndividualID, "en", date);
                StringContent content = new StringContent(body);
                var responseString = await wc.PostAsync(serviceUrl + "$batch", content);

                returnVal = BatchResponse.GetObligations(await responseString.Content.ReadAsStringAsync());
            }

            return returnVal;
        }

        /// <summary>
        /// Gets the Interview feedback request form.
        /// </summary>
        /// <returns>The feedback application form.</returns>
        public async Task<ServiceResult<FeedbackRoot>> ApplicationFeedbackByID(long applicationID)
        {
            ServiceResult<FeedbackRoot> returnVal = null;
            try
            {
                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "individualInterviewFeedbackFormLoadRequestSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    string Apiname = "individualInterviewFeedbackFormLoadRequestSet(" + applicationID + ")";
                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<FeedbackRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var getFeedbackRoot = JsonConvert.DeserializeObject<FeedbackRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = getFeedbackRoot;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }



        /// <summary>
        /// Request for OTP.
        /// </summary>
        public async Task<bool> OTPRequest(int loginAttempts, EnumGlobal.OTPRequestType OTPRequestType, string OTPvalue)
        {
            bool returnVal = false;
            try
            {
                using (HttpServiceClient httpclient = new HttpServiceClient("", "individualInterviewFeedbackFormLoadRequestSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    httpclient.DefaultRequestHeaders.Add("ChannelId", "PORTAL");
                    httpclient.DefaultRequestHeaders.Add("UserId", DebugDataSingleton.Instance.NesIndividualID);
                    httpclient.DefaultRequestHeaders.Add("UserType", "IND");
                    httpclient.DefaultRequestHeaders.Add("PrefLang", DebugDataSingleton.Instance.Language);

                    if (OTPRequestType == EnumGlobal.OTPRequestType.ValidateOTP)
                    {
                        httpclient.DefaultRequestHeaders.Add("AuthName", "OTP");
                        httpclient.DefaultRequestHeaders.Add("AuthValue", OTPvalue);
                    }

                    string Apiname = "PSOAuthenticationSet(nesIndividualId=" + DebugDataSingleton.Instance.NesIndividualID + ",loginAttempts=" + loginAttempts + ")";
                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    var responseCode = string.Empty;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        returnVal = true;
                    }
                    else
                    {
                        if (OTPRequestType == EnumGlobal.OTPRequestType.OTPRequest)
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                            {
                                returnVal = true;
                            }
                        }

                    }
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
        }

        //public async Task<ServiceResult<ProgramListRoot>> GetMyProgram(int statusId)
        //{
        //	ServiceResult<ProgramListRoot> returnVal = null;
        //	try
        //	{
        //		string strFullSyncData = "";
        //		using (HttpServiceClient httpclient = new HttpServiceClient("", "getProgramDetailsSet"))
        //		{
        //			httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
        //			httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

        //			string Apiname = string.Format("getProgramDetailsSet?$filter=userId eq {0} and locale eq '{1}' and status eq {2}",
        //										   DebugDataSingleton.Instance.NesIndividualID,
        //										   DebugDataSingleton.Instance.Language,
        //										   statusId);

        //			var response = await httpclient.GetAsync(serviceUrl + Apiname);
        //			returnVal = new ServiceResult<ProgramListRoot>();
        //			if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //			{
        //				using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
        //				{
        //					using (var reader = new System.IO.StreamReader(stream))
        //					{
        //						strFullSyncData = reader.ReadToEnd();
        //					}
        //				}

        //				// all success
        //				var getProgramResponse = JsonConvert.DeserializeObject<ProgramListRoot>(strFullSyncData);
        //				returnVal.IsSuccess = true;
        //				returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
        //				returnVal.Result = getProgramResponse;
        //			}
        //			else
        //			{
        //				returnVal.IsSuccess = false;
        //				returnVal.Result = null;
        //				returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
        //			}
        //			//Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
        //			return returnVal;
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		return returnVal;

        //	}
        //	finally
        //	{
        //	}
        //}

        public async Task<ServiceResult<ProgramListRoot>> GetProgramOverView(int programId)
        {
            ServiceResult<ProgramListRoot> returnVal = null;
            try
            {
                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "getAllProgramDetailsSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("getProgramOverviewSet?$filter=userId eq {0} and locale eq '{1}' and programId eq {2}",
                                                   DebugDataSingleton.Instance.NesIndividualID,
                                                   DebugDataSingleton.Instance.Language,
                                                   programId);

                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<ProgramListRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var getProgramResponse = JsonConvert.DeserializeObject<ProgramListRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = getProgramResponse;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    //Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }

        public async Task<ServiceResult<ProgramListRoot>> GetMyProgram(int statusId)
        {
            ServiceResult<ProgramListRoot> returnVal = null;
            try
            {
                string strFullSyncData = "";
                using (HttpServiceClient httpclient = new HttpServiceClient("", "getProgramDetailsSet"))
                {
                    httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                    string Apiname = string.Format("getProgramDetailsSet?$filter=userId eq {0} and locale eq '{1}' and status eq {2}",
                                                   DebugDataSingleton.Instance.NesIndividualID,
                                                   DebugDataSingleton.Instance.Language,
                                                   statusId);

                    var response = await httpclient.GetAsync(serviceUrl + Apiname);
                    returnVal = new ServiceResult<ProgramListRoot>();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (Stream stream = await httpclient.GetStreamAsync(serviceUrl + Apiname))
                        {
                            using (var reader = new System.IO.StreamReader(stream))
                            {
                                strFullSyncData = reader.ReadToEnd();
                            }
                        }

                        // all success
                        var getProgramResponse = JsonConvert.DeserializeObject<ProgramListRoot>(strFullSyncData);
                        returnVal.IsSuccess = true;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                        returnVal.Result = getProgramResponse;
                    }
                    else
                    {
                        returnVal.IsSuccess = false;
                        returnVal.Result = null;
                        returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                    }
                    //Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                    return returnVal;
                }
            }
            catch (Exception ex)
            {
                return returnVal;

            }
            finally
            {
            }
        }

        public async Task<ServiceResult<IndividualApplicationDetailRoot>> GetIndividualApplicationDetailsSet(string applicationID)
        {
            ServiceResult<IndividualApplicationDetailRoot> returnVal = null;
            string strFullSyncData = "";
            using (HttpServiceClient httpclient = new HttpServiceClient("", "IndividualApplicationDetailsSet"))
            {
                httpclient.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                httpclient.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);

                string Apiname = serviceUrl + "IndividualApplicationDetailsSet(nesIndividualID=" + DebugDataSingleton.Instance.NesIndividualID + ",applicationID=" + applicationID + ",locale='" + DebugDataSingleton.Instance.Language + "')";
                var response = await httpclient.GetAsync(Apiname);
                returnVal = new ServiceResult<IndividualApplicationDetailRoot>();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (Stream stream = await httpclient.GetStreamAsync(Apiname))
                    {
                        using (var reader = new System.IO.StreamReader(stream))
                        {
                            strFullSyncData = reader.ReadToEnd();
                        }
                    }

                    // all success
                    var getIndApplicationresponse = JsonConvert.DeserializeObject<IndividualApplicationDetailRoot>(strFullSyncData);
                    returnVal.IsSuccess = true;
                    returnVal.Result = getIndApplicationresponse;
                    returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                }
                else
                {
                    returnVal.IsSuccess = false;
                    returnVal.Result = null;
                    returnVal.StatusCode = Convert.ToString(Convert.ToInt32(response.StatusCode));
                }
                Debug.WriteLine("Cookie-" + DebugDataSingleton.Instance.COOKIE);
                return returnVal;
            }
        }

        /// <summary>
        /// Posts the answers for the survey questions
        /// </summary>
        /// <returns>true or false</returns>
        public async Task<bool> UpdateSurveyResponse(SurveyResponse surveyResponse)
        {
            bool returnVal = false;
            try
            {

                using (HttpClient wc = new HttpClient())
                {

                    //wc.DefaultRequestHeaders.Add(HttpRequestHeader.Cookie, DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("Cookie", DebugDataSingleton.Instance.COOKIE);
                    wc.DefaultRequestHeaders.Add("ContentType", "application/json; charset=utf-8");
                    wc.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                    wc.DefaultRequestHeaders.Add("X-CSRF-Token", DebugDataSingleton.Instance.X_CSRF_TOKEN);
                    wc.DefaultRequestHeaders.Add("Authorization", DebugDataSingleton.Instance.BasicAuth);
                    wc.DefaultRequestHeaders.Add("X-SMP-APPCID", DebugDataSingleton.Instance.X_SMP_APPCID);
                    wc.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                    string body = JsonConvert.SerializeObject(surveyResponse);
                    StringContent content = new StringContent(body);
                    var response = await wc.PostAsync(serviceUrl + "SurveyHeaderSet", content);

                    returnVal = true;
                }

                return returnVal;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
