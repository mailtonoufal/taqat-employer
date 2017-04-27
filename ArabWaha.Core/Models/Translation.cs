namespace ArabWaha.Models
{
    public class Translation
    {
        public class Default
        {
            public string cancel { get; set; }
            public string ok { get; set; }
            public string no { get; set; }
            public string yes { get; set; }
            public string retry { get; set; }
            public string edit { get; set; }
            public string save { get; set; }
            public string back { get; set; }
            public string settings { get; set; }
            public string later { get; set; }
            public string next { get; set; }
            public string previous { get; set; }
            public string skip { get; set; }
            public string english { get; set; }
            public string arabic { get; set; }
        }

        public class Error
        {
            public string authenticationError { get; set; }
            public string connectionError { get; set; }
            public string errorTitle { get; set; }
            public string unknownError { get; set; }
        }

        public class Intro
        {
            public string welcome { get; set; }
            public string welcomeSubTitle { get; set; }
            public string continueAsGuest { get; set; }
            public string getStarted { get; set; }
            public string getStartedSubTitle { get; set; }
            public string contact { get; set; }
            public string signup { get; set; }
            public string signin { get; set; }
        }


        public class Signin
        {
            public string title { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string forgottenPassword { get; set; }
            public string signinButton { get; set; }
        }

        public class Searchguest
        {
            public string searchJobName { get; set; }
            public string searchLocation { get; set; }
            public string searchDescription { get; set; }
            public string searchButton { get; set; }
            public string haveAccount { get; set; }
        }

        public class Signinotp
        {
            public string enterCode { get; set; }
            public string timeRemaining { get; set; }
            public string phoneMessage { get; set; }
            public string submit { get; set; }
            public string resend { get; set; }
        }

        public class ForgotPassword
        {
            public string sendButton { get; set; }
            public string title { get; set; }
            public string descriptionText { get; set; }
        }

        public class Terms
        {
            public string welcome { get; set; }
            public string termsTitle { get; set; }
            public string termsDescription { get; set; }
            public string infoTitle { get; set; }
            public string infoDescription { get; set; }
            public string termsSigninButton { get; set; }
        }

        public class Searchmain
        {
            public string title { get; set; }
            public string filter { get; set; }
        }

        public class Questionary
        {
            public string title { get; set; }
            public string subtitle { get; set; }
            public string agreeButton { get; set; }
            public string continueButton { get; set; }
            public string confirmText { get; set; }
            public string addText { get; set; }
        }

        public class Programs
        {
            public string title { get; set; }
        }


        public class Program
        {
            public string title { get; set; }
            public string attend { get; set; }
            public string subtitle { get; set; }
            public string benefitTitle { get; set; }
            public string descriptionText { get; set; }
            public string registerTitle { get; set; }
            public string requirementsTitle { get; set; }
            public string whyTitle { get; set; }
        }

        public class Menu
        {
            public string menuHome { get; set; }
            public string menuProfile { get; set; }
            public string menuPrograms { get; set; }
            public string menuJobs { get; set; }
            public string menuContactUs { get; set; }
            public string menuSettings { get; set; }
            public string menuLogout { get; set; }
        }

        public class Settings
        {
            public string language { get; set; }
            public string resetPassword { get; set; }
            public string complaints { get; set; }
            public string about { get; set; }
            public string logout { get; set; }
            public string feedbackFooter { get; set; }
            public string title { get; set; }
        }

        public class Contact
        {
            public string title { get; set; }
            public string phonenumber { get; set; }
            public string email { get; set; }
            public string footerText { get; set; }
        }

        public class Profile
        {
            public string title { get; set; }
            public string username { get; set; }
            public string idNumber { get; set; }
            public string status { get; set; }
            public string personalInfo { get; set; }
            public string employmentPreference { get; set; }
            public string education { get; set; }
            public string workExperience { get; set; }
            public string skills { get; set; }
            public string language { get; set; }
            public string licenses { get; set; }
            public string training { get; set; }
            public string references { get; set; }
            public string awards { get; set; }
        }

        public Questionary questionary { get; set; }

            public Default @default { get; set; }
        public Error error { get; set; }
        public Intro intro { get; set; }
        public Signin signin { get; set; }
        public Searchguest searchguest { get; set; }
        public Signinotp signinotp { get; set; }
        public ForgotPassword forgotpassword { get; set; }
        public Terms terms { get; set; }
        public Searchmain searchmain { get; set; }
        public Programs programs { get; set; }
        public Program program { get; set; }
        public Menu menu { get; set; }
        public Settings settings { get; set; }
        public Contact contact { get; set; }
        public Profile profile { get; set; }
    }
}
