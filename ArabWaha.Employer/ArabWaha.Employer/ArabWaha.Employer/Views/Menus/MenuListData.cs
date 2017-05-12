using ArabWaha.Core.Services;
using ArabWaha.Employer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employer.Views.Menus
{
    // menu items we need to use
    // include the type we need to navigate to
    public class MenuListData : List<MasterPageItem>
    {
        public MenuListData()
        {
            bool isEnglishText = true;
            if (GlobalSetting.CultureCode == "ar")
                isEnglishText = false;


            bool IsAuth = AuthService.IsAuthorised ; // needs to check auth service param on the pcl

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Home" : "الصفحة الرئيسية",
                IconSource = "arrow_white.png",
                TargetType = $"{nameof(HomePage)}?TAB=1",
                PageType = typeof(HomePage),
                IconImage = Application.Current.Resources["MenuIconHome"] as FileImageSource
            });

            if(IsAuth)
            {
                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "My Company" : "شركتي",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(CompanyDetailsPage),
                    PageType = typeof(CompanyDetailsPage),
                    IconImage = Application.Current.Resources["MenuIconMyCompany"] as FileImageSource
                });

                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Applications" : "التطبيقات",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(ApplicationsPage),
                    PageType = typeof(ApplicationsPage),
                    IconImage = Application.Current.Resources["MenuIconApplications"] as FileImageSource
                });

                //this.Add(new MasterPageItem
                //{
                //    Title = isEnglishText ? "Job Postings" : "وظائف شاغرة",
                //    IconSource = "arrow_white.png",
                //    TargetType = $"{nameof(HomePage)}?TAB=2",
                //    PageType = typeof(HomePage),
                //    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
                //});

               

            }

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Programs" : "البرامج",
                IconSource = "arrow_white.png",
                TargetType = $"{nameof(HomePage)}?TAB=3",
                PageType = typeof(HomePage),
                IconImage = Application.Current.Resources["MenuIconPrograms"] as FileImageSource
            });

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Services" : "خدمات",
                IconSource = "arrow_white.png",
                TargetType = $"{nameof(HomePage)}?TAB=4",
                PageType = typeof(HomePage),
                IconImage = Application.Current.Resources["MenuIconServices"] as FileImageSource
            });

      

            if (IsAuth)
            {
                //this.Add(new MasterPageItem
                //{
                //    Title = isEnglishText ? "Notifications" : "الإشعارات",
                //    IconSource = "arrow_white.png",
                //    TargetType = nameof(NotificationsPage),
                //    PageType = typeof(NotificationsPage),
                //    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
                //});

                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Calendar" : "التقويم",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(CalendarPage),
                    PageType = typeof(CalendarPage),
                    IconImage = Application.Current.Resources["MenuIconCalendar"] as FileImageSource
                });


                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Complaints" : "شكاوي",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(ComplaintsPage),
                    PageType = typeof(ComplaintsPage),
                    IconImage = Application.Current.Resources["MenuIconComplaints"] as FileImageSource
                });

            }

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Contact Us" : "اتصل بنا",
                IconSource = "arrow_white.png",
                TargetType = nameof(ContactUsPage),
                PageType = typeof(ContactUsPage),
                IconImage = Application.Current.Resources["MenuIconContactUs"] as FileImageSource
            });


            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Settings" : "إعدادات",
                IconSource = "arrow_white.png",
                TargetType = nameof(SettingsPage),
                PageType = typeof(SettingsPage),
                IconImage = Application.Current.Resources["MenuIconSettings"] as FileImageSource
            });


            if (!IsAuth)
            {
                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Sign In" : "تسجيل الدخول",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(LoginPage),
                    PageType = typeof(LoginPage),
                    IconImage = Application.Current.Resources["MenuIconLogInOut"] as FileImageSource
                });


            }
            else
            {

                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Log out" : "الخروج",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(LoginPage),
                    PageType = typeof(LoginPage),
                    IconImage = Application.Current.Resources["MenuIconLogInOut"] as FileImageSource
                });

                SetUser();
            }

        }

        // pull user info from auth so we can use this in settings etc and job applications etc
        private async Task SetUser()
        {
            // do we have a current user?
            //if (App.GetInstance().CurrentUser == null)
            //{
            //    // set current user
            //    var current = await userset.Getuser();
            //    App.GetInstance().CurrentUser = current;
            //}
        }
    }
}
