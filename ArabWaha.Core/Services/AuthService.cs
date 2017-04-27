using ArabWaha.Models;
using ArabWaha.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.Services
{
    public class AuthService
    {
        public static bool IsAuthorised { get; set; } = false;// set to public to test menu until auth code is in


        public async Task Login(string username, string password, bool isGuest)
        {
            IsAuthorised = true;
            // TODO Call API 
            //LoginInternal()
            return;
        }


        private async Task LoginInternal(String email, String password, bool isGuest)
        {
            //View.ShowLoading(true);

            try
            {
                DebugDataSingleton.Instance.BasicAuth = "Basic OTAwNjI3OTpzYXBAMTIzNA==";

                var bytes = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", email, password));
                var base64String = Convert.ToBase64String(bytes);
                string authHeader = String.Format("Basic {0}", base64String);

                var result = await AWHttpClient.Instance.RegisterUser(authHeader, "android");
                //var result = await AWWebClient.Instance.RegisterUser("Basic OTAwNjI3OTpzYXBAMTIzNA==", Constants.Device);
                if (result.StatusCode == "201") //success case
                {
                    DebugDataSingleton.Instance.ApplicationConnectionId = result.Result.RegistrationObjectItem.ApplicationConnectionId;
                    DebugDataSingleton.Instance.UserName = result.Result.RegistrationObjectItem.UserName;
                    DebugDataSingleton.Instance.BasicAuth = authHeader;   //X-SMP-APPCID
                    DebugDataSingleton.Instance.X_SMP_APPCID = result.Result.RegistrationObjectItem.ApplicationConnectionId;
                    DebugDataSingleton.Instance.Language = "en";

                    var resultIndividual = await AWHttpClient.Instance.GetNESIndividualId(email);
                    if (resultIndividual.StatusCode == "200")
                    {
                        DebugDataSingleton.Instance.NesIndividualID = resultIndividual.Result.NesIndividualItem.NesIndividualId;
                        var sapBPIndividual = await AWHttpClient.Instance.GetIndividualSBPId(DebugDataSingleton.Instance.NesIndividualID);

                        bool isHafiz = false;
                        if (!isGuest)
                        {
                            var programs = await AWHttpClient.Instance.GetAllPrograms();
                            TmpObject.ProgramListRoot = programs.Result;

                            foreach (ArabWaha.Models.Programs masterProgram in programs.Result.programList.programs)
                            {
                                if ((masterProgram.ProgramId == "1") || (masterProgram.ProgramId == "2"))
                                {
                                    if ((masterProgram.Status == EnumGlobal.ProgramStatus.Applied.GetHashCode().ToString()) ||
                                        (masterProgram.Status == EnumGlobal.ProgramStatus.Enrolled.GetHashCode().ToString()))
                                    {
                                        isHafiz = true;
                                    }
                                }
                            }
                        }

                        //View.ShowOnBoarding(isHafiz, isGuest);
                    }
                    else
                    {
                        //View.ShowError("");
                        //View.ShowLoading(false);
                    }
                }
                else
                {
                    ///View.ShowError("");
                    //View.ShowLoading(false);
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
