﻿using ArabWaha.Models;
using ArabWaha.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArabWaha.Common;
using System.Diagnostics;
using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Models.Company;

namespace ArabWaha.Core.Services
{
    public class AuthService
    {
        public static bool IsAuthorised { get; set; } = false;// set to public to test menu until auth code is in


        public async Task<bool> Login(string username, string password, bool isGuest)
        {
            // TODO Call API 
            //Comment this line to bypass the login API
            return await LoginInternal(username, password, isGuest);
            IsAuthorised = true;
            return true;
        }


        public async Task<bool> LoginInternal(String email, String password, bool isGuest)
        {
            //View.ShowLoading(true);

            try
            {
                DebugDataSingleton.Instance.IsHafiz = false;
                DebugDataSingleton.Instance.BasicAuth = "Basic OTAwNjI3OTpzYXBAMTIzNA==";
                var bytes = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", email, password));
                var base64String = Convert.ToBase64String(bytes);
                string authHeader = String.Format("Basic {0}", base64String);

				DbAccessor db = new DbAccessor();

				var result = await AWHttpClient.Instance.RegisterUser(authHeader, Constants.DevicePlatform);
                if (result.StatusCode == "201") //success case
                {
                    if (!isGuest)
                    {
                        IsAuthorised = true;
                    }
                    DebugDataSingleton.Instance.ApplicationConnectionId = result.Result.RegistrationObjectItem.ApplicationConnectionId;
                    DebugDataSingleton.Instance.UserName = result.Result.RegistrationObjectItem.UserName;
                    DebugDataSingleton.Instance.BasicAuth = authHeader;   //X-SMP-APPCID
                    DebugDataSingleton.Instance.X_SMP_APPCID = result.Result.RegistrationObjectItem.ApplicationConnectionId;


                    //Get the Cookie and XCSRF Token
                    //var resultXCSRF = await AWHttpClient.Instance.GetXCSRFToken();


                    //Get the MyCompanyDetails
                    var myCompanyDetails = await AWHttpClient.Instance.GetCompanyDetails();
                    if (myCompanyDetails.IsSuccess)
                    {
                        if (myCompanyDetails.Result != null && myCompanyDetails.Result.myCompanyObjectList != null && myCompanyDetails.Result.myCompanyObjectList.myCompanyList.Count > 0)
                        {
                            var myCompany = myCompanyDetails.Result.myCompanyObjectList.myCompanyList[0];
                            //insert the My company details in to the db
                            db.InsertReplaceRecord<MyCompany>(myCompany);

                            //retrieve the company details from the db
                            var myCompanyFromDb = db.GetTableItems<MyCompany>();
                        }
                    }

                    //Get the CandidateList

                    var candidateList = await AWHttpClient.Instance.GetCandidatesList("JobType eq *");
					//TODO parse the candidateList to get the required response



					//Get the MatchingCandidates List for a particular Job Post ID
					var matchingCandidatesSet = await AWHttpClient.Instance.GetMatchingCandidatesList("1000278384");
					//TODO parse the matchingCandidatesSet to get the required response



					//Get the Personal Details
					var personalDetails = await AWHttpClient.Instance.GetPersonalDetails();
					if (personalDetails.IsSuccess)
					{
                        if (personalDetails.Result != null && personalDetails.Result.personalDetailsObject != null && myCompanyDetails.Result.myCompanyObjectList.myCompanyList.Count > 0)
						{
                            var details = personalDetails.Result.personalDetailsObject.personalDetailsList[0];
							
						}
					}



					//Forgot UserName 
                    var forgotUser = await AWHttpClient.Instance.ForgotUserName("ashutoshg@aecl.com");



					//ForgotPassword
					var forgotPwd = await AWHttpClient.Instance.ForgotPassword("Pubemp002");





					return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //View.ShowLoading(false);
                Debug.WriteLine(ex.ToString());
                //View.ShowError(getErrorMessageFromException(ex));
                return false;

            }
        }

    }
}
