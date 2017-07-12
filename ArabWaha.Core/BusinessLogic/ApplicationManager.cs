using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArabWaha.Core.Models.AppliedJob;
using ArabWaha.Web;

namespace ArabWaha.Core.BusinessLogic
{
	public class ApplicationResultHolder
	{
		public JobDetailBatchContainer ApplicationResult { get; set; }
		public InterviewRoot InterViewResult { get; set; }
	}
	public class ApplicationManager
	{
		public static async Task<ApplicationResultHolder> GetApplicationDetails(string jobPostId, string applicationId)
		{
			ApplicationResultHolder ApplicationResultHolder = new ApplicationResultHolder();
			try
			{
				var applicationDetail = await AWHttpClient.Instance.GetIndividualApplicationDetailsSet(applicationId);

				List<string> jobDetailsBatchApis = new List<string>();
				var eNumvalues = Enum.GetValues(typeof(EnumGlobal.EnumAppliedJob));
				foreach (var item in eNumvalues)
				{
					jobDetailsBatchApis.Add(Convert.ToString(item));
				}
				if (applicationDetail.StatusCode == "200" && applicationDetail.Result != null)
				{
                    var coverLetterId = Convert.ToInt64(applicationDetail.Result.IndividualApplicationDetailList.IndividualApplicationDetail[0].CoverletterId);
					var jobDetailheaderForBatch = BatchRequest.GenerateAppliedJobDetailHeader(jobDetailsBatchApis, jobPostId, Convert.ToInt64(applicationId), coverLetterId);

					var resultBatchJobDetail = await AWHttpClient.Instance.ExecuteBatchAsync(jobDetailheaderForBatch);

					if (resultBatchJobDetail.Result != null && resultBatchJobDetail.Result.JobDetailSet != null)
					{
						var interviewDetails = await AWHttpClient.Instance.GetInterviewDetails(resultBatchJobDetail.Result.IndividualApplicationDetail.IndividualApplicationDetailList.IndividualApplicationDetail[0].ApplicationID.ToString());

						ApplicationResultHolder.ApplicationResult = resultBatchJobDetail.Result;
						ApplicationResultHolder.InterViewResult = interviewDetails.Result;
					}

				}
				else
				{
					//View.ShowLoading(false);
				}
			}
			catch (Exception ex)
			{
				throw ex;
				//View.ShowLoading(false);
				//Debug.Print(ex.ToString());
				//View.ShowError(getErrorMessageFromException(ex));
			}
			return ApplicationResultHolder;
		}
	}
}
