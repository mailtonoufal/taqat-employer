using ArabWaha.Core.Services;
using ArabWaha.Employee.Views.Badges;
using ArabWaha.Employee.Views.Branches;
using ArabWaha.Employee.Views.Home;
using ArabWaha.Employee.Views.Jobs;
using ArabWaha.Employee.Views.Programs;
using ArabWaha.Employee.Views.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArabWaha.Employee.Views.Menus
{
    public class MenuListData : List<MasterPageItem>
    {
        public MenuListData()
        {

            bool isEnglishText = true;
            if (GlobalSetting.CultureCode == "ar")
                isEnglishText = false;


            bool IsAuth = AuthService.IsAuthorised; // needs to check auth service param on the pcl

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Home" : "الصفحة الرئيسية",
                IconSource = "arrow_white.png",
                TargetType = $"{nameof(HomePage)}?TAB=1",
                PageType = typeof(HomePage),
                IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
            });

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Jobs" : "وظائف",
                IconSource = "arrow_white.png",
                TargetType = $"{nameof(JobsPage)}?TAB=1",
                PageType = typeof(JobsPage),
                IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
            });


            if (IsAuth)
            {
                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Profile" : "الملف الشخصي",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(ProfilePage), 
                    PageType=typeof(ProfilePage),
                    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
                });
            }

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Programs" : "البرامج",
                IconSource = "arrow_white.png",
                TargetType = nameof(ProgramsPage),
                PageType=typeof(ProgramsPage),
                IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
            });

        

            if (IsAuth)
            {
                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Notifications" : "الإشعارات",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(NotificationsPage),
                    PageType = typeof(NotificationsPage),
                    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
                });

                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Calendar" : "التقويم",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(CalendarPage),
                    PageType = typeof(CalendarPage),
                    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
                });

                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Badges" : "الشارات",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(BadgesPage),
                    PageType = typeof(BadgesPage),
                    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
                });

                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Branch Locator" : "فرع محدد",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(BranchesPage),
                    PageType = typeof(BranchesPage),
                    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
                });

            }

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Contact Us" : "اتصل بنا",
                IconSource = "arrow_white.png",
                TargetType = nameof(ContactUsPage),
                PageType = typeof(ContactUsPage),
                IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
            });

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Complaints" : "شكاوي",
                IconSource = "arrow_white.png",
                TargetType = nameof(ComplaintsPage),
                PageType = typeof(ComplaintsPage),
                IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
            });

            this.Add(new MasterPageItem
            {
                Title = isEnglishText ? "Settings" : "إعدادات",
                IconSource = "arrow_white.png",
                TargetType = nameof(SettingsPage),
                PageType = typeof(SettingsPage),
                IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
            });


            if (!IsAuth)
            {
                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Sign In" : "تسجيل الدخول",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(LoginPage),
                    PageType = typeof(LoginPage),
                    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
                });


            }
            else
            {

                this.Add(new MasterPageItem
                {
                    Title = isEnglishText ? "Sign out" : "خروج",
                    IconSource = "arrow_white.png",
                    TargetType = nameof(LoginOptionsPage),
                    PageType = typeof(LoginOptionsPage),
                    IconImage = Application.Current.Resources["startemptyblue"] as FileImageSource
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
