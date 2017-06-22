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

		public class Employer
		{
			public string welcomelbltitle { get; set; }
			public string welcomelbldescription { get; set; }
			public string welcomebtnskip { get; set; }
			public string signinlbltitle { get; set; }
			public string signinlbldescription { get; set; }
			public string signinbtnmollogin { get; set; }
			public string signinbtnnlglogin { get; set; }
			public string signinbtnsignup { get; set; }
			public string signinbtnguest { get; set; }
			public string guestlbldesc { get; set; }
			public string guesttxbsearch { get; set; }
			public string guesttxblocation { get; set; }
			public string guestbtnsearch { get; set; }
			public string guestbtnsignin { get; set; }
			public string guestsearchbtnfilter { get; set; }
			public string guestsearchlbltitle { get; set; }
			public string guestprofiledetlblprofile { get; set; }
			public string guestprofiledetlblusername { get; set; }
			public string guestprofiledetlblidnumber { get; set; }
			public string guestprofiledetlblstatus { get; set; }
			public string guestprofiledetlblpersonalinfo { get; set; }
			public string guestprofiledetlbldob { get; set; }
			public string guestprofiledetlblcity { get; set; }
			public string guestprofiledetlblmaritalstatus { get; set; }
			public string guestprofiledetlblmobile { get; set; }
			public string guestprofiledetlblemail { get; set; }
			public string guestprofiledetlbladdress { get; set; }
			public string guestprofiledetlblemppref { get; set; }
			public string guestprofiledetlbllookjob { get; set; }
			public string guestprofiledetlblshifttype { get; set; }
			public string guestprofiledetlbltelework { get; set; }
			public string guestprofiledetlblaboutme { get; set; }
			public string guestprofiledetlbleducation { get; set; }
			public string guestprofiledetlbllvlofedu { get; set; }
			public string guestprofiledetlblmajor { get; set; }
			public string guestprofiledetlblinstitute { get; set; }
			public string guestprofiledetlblyears { get; set; }
			public string guestprofiledetlblgpa { get; set; }
			public string guestprofiledetlblworkexp { get; set; }
			public string guestprofiledetlblworkexptitle { get; set; }
			public string guestprofiledetlblworkexpcompany { get; set; }
			public string guestprofiledetlblworkexpsector { get; set; }
			public string guestprofiledetlblworkexpyears { get; set; }
			public string guestprofiledetlblworkexpmonsal { get; set; }
			public string guestprofiledetlblworkexprolres { get; set; }
			public string guestprofiledetlblcompetencies { get; set; }
			public string guestprofiledetlbllanguages { get; set; }
			public string guestprofiledetlblgeneral { get; set; }
			public string guestprofiledetlbllicenses { get; set; }
			public string guestprofiledetlbllicname { get; set; }
			public string guestprofiledetlbllicexpiry { get; set; }
			public string guestprofiledetlbldrivlicense { get; set; }
			public string guestprofiledetlbllictype { get; set; }
			public string guestprofiledetlbltrainandcert { get; set; }
			public string guestprofiledetlbltrainname { get; set; }
			public string guestprofiledetlblinstname { get; set; }
			public string guestprofiledetlbltrnlocation { get; set; }
			public string guestprofiledetlbltrnvalidity { get; set; }
			public string guestprofiledetlblreferences { get; set; }
			public string guestprofiledetlblrefname { get; set; }
			public string guestprofiledetlblrefassociation { get; set; }
			public string guestprofiledetlblrefcompany { get; set; }
			public string guestprofiledetlblrefphone { get; set; }
			public string homelblhome { get; set; }
			public string homelbljobposts { get; set; }
			public string homelblprograms { get; set; }
			public string homelblservices { get; set; }
			public string sidemenulblmycompany { get; set; }
			public string sidemenulblapplications { get; set; }
			public string sidemenulblcalendar { get; set; }
			public string sidemenulblcontactus { get; set; }
			public string sidemenulblsettings { get; set; }
			public string sidemenulbllogout { get; set; }
			public string jobpostslistlbltitle { get; set; }
			public string jobpostslistlblposted { get; set; }
			public string jobpostslistlbljobstatus { get; set; }
			public string jobpostslistlbllocation { get; set; }
			public string jobpostsdetlbldescription { get; set; }
			public string jobpostsdetlblgeninfo { get; set; }
			public string jobpostsdetlbljobpoststatus { get; set; }
			public string jobpostsdetlbljobpostid { get; set; }
			public string jobpostsdetlbljobtype { get; set; }
			public string jobpostsdetlblopenpositions { get; set; }
			public string jobpostsdetlblfilledpositions { get; set; }
			public string jobpostsdetlblsalary { get; set; }
			public string jobpostsdetlblsector { get; set; }
			public string jobpostsdetlblminexp { get; set; }
			public string jobpostsdetlblappldate { get; set; }
			public string jobpostsdetlbldesstartdate { get; set; }
			public string jobpostsdetlblskills { get; set; }
			public string jobpostsdetlbltitle { get; set; }
			public string jobpostsdetlblcompany { get; set; }
			public string jobpostsdetlblyears { get; set; }
			public string jobpostsdetlblmonsal { get; set; }
			public string jobpostsdetlblroleresp { get; set; }
			public string jobpostsdetlbllanguages { get; set; }
			public string jobpostsdetlblgeneral { get; set; }
			public string jobpostsdetlbllocation { get; set; }
			public string jobpostsdetlbladdress { get; set; }
			public string jobpostsdetlblworktime { get; set; }
			public string jobpostsdetlblmobility { get; set; }
			public string jobpostsdetlblenvdisinfo { get; set; }
			public string jobpostsdetlblbenefits { get; set; }
			public string jobpostsdetlblother { get; set; }
			public string jobpostsdetlblbonus { get; set; }
			public string jobpostsdetlblmethodofappl { get; set; }
			public string jobpostsdetlblrequirements { get; set; }
			public string jobpostsdetlblsurvey { get; set; }
			public string jobpostsdetlblcontactperson { get; set; }
			public string jobpostsdetlblattachments { get; set; }
			public string jobpostsdetbtnmatchingcandidates { get; set; }
			public string jobpostsdetlbleditjobpost { get; set; }
			public string jobpostsdetlbldeletejobpost { get; set; }

			public string jobpostlistbtnedit { get; set; }
			public string jobpostlistbtndelete { get; set; }
			public string jobpostlistbtnadd { get; set; }
			public string jobpostlistbtnview { get; set; }
			public string jobswatchlisttabtitle { get; set; }
			public string jobswatchlisbtnapply { get; set; }



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
		public Employer employer { get; set; }
	}
}
