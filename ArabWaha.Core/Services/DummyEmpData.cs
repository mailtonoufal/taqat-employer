using ArabWaha.Core.DBAccess;
using ArabWaha.Core.Helpers;
using ArabWaha.Core.ModelsEmployer;
using ArabWaha.Core.ModelsEmployer.Company;
using ArabWaha.Core.ModelsEmployer.Jobs;
using ArabWaha.Core.ModelsEmployer.Programs;
using ArabWaha.Core.ModelsEmployer.Services;
using ArabWaha.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Core.Services
{
    public class DummyEmpData
    {
        public static List<ComplaintRaised> GetComplaintsList()
        {
            var retSource = new List<ComplaintRaised>
            {
                new ComplaintRaised
                {
                    Subject="Website issues",
                    Category="Techical Issue(s)",
                    Status="Closed",
                    ComplaintId=12345,
                    ComplaintText="Website not displaying images",
                    CreatedOn="2017-2-17",
                    ClosedOn="2017-2-26"
                },
                new ComplaintRaised
                {
                    Subject="Sign In Issue",
                    Category="Password related issues",
                    Status="In progress",
                    ComplaintId=13456,
                    ComplaintText="Cannot signin with current password. Invalid password error",
                    CreatedOn="2017-4-15",
                    ClosedOn=""
                },
                new ComplaintRaised
                {
                    Subject="Forgot Password",
                    Category="Password related issues",
                    Status ="In progress",
                    ComplaintId=16543,
                    ComplaintText="How can I reset my password",
                    CreatedOn="2017-2-21",
                    ClosedOn=""
                },
                new ComplaintRaised
                {
                    Subject="Cannot create account",
                    Category="Issues with Registration",
                    Status="In progress",
                    ComplaintId=12345,
                    ComplaintText="When i create an account the website rejects my information stating that it is incorrect?",
                    CreatedOn="2017-3-10",
                    ClosedOn=""
                },
                new ComplaintRaised
                {
                    Subject="New jobs not showing",
                    Category="Technical issues with web portal",
                    Status="Closed",
                    ComplaintId=10092,
                    ComplaintText="I have watched 4 new jobs and they are not showing up in my watched list",
                    CreatedOn="2017-3-25",
                    ClosedOn="2017-3-29"
                },
                new ComplaintRaised
                {
                    Subject="Website crashed",
                    Status="rejected",
                    Category="Technical issues with web portal",
                    ComplaintId=23543,
                    ComplaintText="When i navigate to the website it crashes my browser",
                    CreatedOn="2016-9-10",
                    ClosedOn="2016-10-10"
                },
            };

            return retSource;

        }

        public static List<EventDetails> GetEventsList()
        {
            DateTime eventDate = DateTime.Now.AddHours(2);

            var retSource = new List<EventDetails>
            {
                new EventDetails
                {
                    EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                    EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                    EventLocation = "AEC Offices",
                    EventTitle ="Flight to Salt Lake city",
                    EventId =1,
                    Status ="Declined",
                    PhoneNumber="01234567890",
                    Email="admin@aramco.com",
                    AdditionalInfo="Dress code is required",
                    JobPostId= "12345"
                }
            };

            eventDate = eventDate.AddHours(2);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1.5)),
                EventLocation = "HDRF - Olaya street",
                EventTitle = "Team Meeting",
                EventId = 2,
                Status = "Accepted",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId = "1"
            });

            eventDate = eventDate.AddDays(1).AddHours(-2);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                EventLocation = "CBA Limited - Riyah, KSA",
                EventTitle = "Ford project Initialization",
                EventId = 3,
                Status = "Accepted",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId = "2"
            });

            eventDate = eventDate.AddHours(3);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                EventLocation = "Google Office - Dubai",
                EventTitle = "Google Conference",
                EventId = 4,
                Status = "Accepted",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId = "3"
            });

            eventDate = eventDate.AddDays(1).AddHours(3);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                EventLocation = "Excel centre - London UK",
                EventTitle = "Developers Conference",
                EventId = 5,
                Status = "Declined",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId = "4"
            });


            eventDate = eventDate.AddDays(3);
            retSource.Add(new EventDetails
            {
                EventStart = UtilHelper.ConvertDateToSqlDate(eventDate),
                EventEnd = UtilHelper.ConvertDateToSqlDate(eventDate.AddHours(1)),
                EventLocation = "office abc - Riyah, KSA",
                EventTitle = "Client meetup",
                EventId = 6,
                Status = "Accepted",
                PhoneNumber = "01234567890",
                Email = "info@aramco.com",
                AdditionalInfo = "Dress code is required",
                JobPostId = "5"
            });

            return retSource;
        }

        public static ObservableCollection<ApplicationProfile> GetCompanyJobApplications()
        {

            var Applications = new ObservableCollection<ApplicationProfile>()
                        {
                            new ApplicationProfile() { ProfileId=1,  Name= $"Mohammed Fadi 1", ApplicationId=1, Gender="Male", Occupation= $"Android Developer", Location="Riyadh", Availability="Imediate", MatchScore=90, JobPostId = 1, ApplicationDate=DateTime.Now.AddDays(7)},
                            new ApplicationProfile() { ProfileId=2,  Name= $"Mohammed Fadi 2", ApplicationId=2, Gender="Male", Occupation= $"iOS Android Developer", Location="Riyadh", Availability="Imediate", MatchScore=10, JobPostId = 1, ApplicationDate=DateTime.Now.AddDays(17) },
                            new ApplicationProfile() { ProfileId=3,  Name= $"Moh Fadi 3", ApplicationId=3, Gender="Female", Occupation= $"iOS Swift Programmer", Location="Riyadh", Availability="Imediate", MatchScore=76, JobPostId = 1 , ApplicationDate=DateTime.Now.AddDays(27)},
                            new ApplicationProfile() { ProfileId=4,  Name= $"Mohammed Fadi 4", ApplicationId=4, Gender="Male", Occupation= $"Java Developer", Location="Riyadh", Availability="Imediate", MatchScore=34, JobPostId = 1 , ApplicationDate=DateTime.Now.AddDays(57)},
                            new ApplicationProfile() { ProfileId=5,  Name= $"Moh Fadi 5", ApplicationId=5, Gender="Male", Occupation= $"Android Programmer", Location="Riyadh", Availability="Imediate", MatchScore=67, JobPostId = 1 , ApplicationDate=DateTime.Now.AddDays(77)},
                            new ApplicationProfile() { ProfileId=5,  Name= $"Mohammed Fadi 6", ApplicationId=6, Gender="Male", Occupation= $"iOS Android Swift", Location="Riyadh", Availability="Imediate", MatchScore=88, JobPostId = 2 , ApplicationDate=DateTime.Now.AddDays(57)},
                            new ApplicationProfile() { ProfileId=6,  Name= $"Mohammed Fadi 7", ApplicationId=7, Gender="Female", Occupation= $"IT iOS Java Android Dev", Location="Riyadh", Availability="Imediate", MatchScore=90, JobPostId = 3, ApplicationDate=DateTime.Now.AddDays(137)},
                            new ApplicationProfile() { ProfileId=7,  Name= $"Moh Fadi 8", ApplicationId=8, Gender="Male", Occupation= $"Swift android java ios", Location="Riyadh", Availability="Imediate", MatchScore=10, JobPostId = 4 , ApplicationDate=DateTime.Now.AddDays(47)},
                            new ApplicationProfile() { ProfileId=8,  Name= $"Mohammed Fadi 9", ApplicationId=9, Gender="Male", Occupation= $"iOS Software Engineer", Location="Riyadh", Availability="Imediate", MatchScore=76, JobPostId = 5 , ApplicationDate=DateTime.Now.AddDays(157)},
                            new ApplicationProfile() { ProfileId=9,  Name= $"Moh Fadi 10", ApplicationId=10, Gender="Male", Occupation= $"Android Java Software Engineer", Location="Riyadh", Availability="Imediate", MatchScore=34, JobPostId = 5 , ApplicationDate=DateTime.Now.AddDays(101)},
                            new ApplicationProfile() { ProfileId=10,  Name= $"Mohammed Fadi 11", ApplicationId=11, Gender="Male", Occupation= $"iOS Android Mobile Developer", Location="Riyadh", Availability="Imediate", MatchScore=67, JobPostId = 6 , ApplicationDate=DateTime.Now.AddDays(63)},
                            new ApplicationProfile() { ProfileId=11,  Name= $"Moh Fadi 12", ApplicationId=12, Gender="Female", Occupation= $"Android Mobile Developer", Location="Riyadh", Availability="Imediate", MatchScore=88, JobPostId = 6 , ApplicationDate=DateTime.Now.AddDays(7)},
            };

            return Applications;
        }

        
        public static ObservableCollection<ApplicationProfile> GetSearchApplications(string keyword, string location)
        {
            var src = new ObservableCollection<ApplicationProfile>();

            for (int i = 1; i < 11; i++)
                src.Add(new ApplicationProfile {
                    Occupation = $"Xamarin Developer {i}", Gender = "Male", Location = "Riyadh", MatchScore = i * 2, Availability = "01/01/2017", Name = $"Ali Fahad {i}" });

            return src;
        }



        public static ObservableCollection<CompanyUserDetails> GetCompanyUsers()
        {
            ObservableCollection<CompanyUserDetails> users = new ObservableCollection<CompanyUserDetails>();

            // Recruiter
            for (int i = 1; i < 11; i++)
            {
                CompanyUserDetails u = new CompanyUserDetails()
                {
                    FirstName = "Hammal",
                    SecondName = "Ali",
                    ThirdName = "Bin",
                    LastName = "Ismail",
                    Position = "Human Resource Manager",
                    PhoneNumber = "088989389893",
                    EmailAddress = "email@emailexample.com",
                    UserName = "mohammad.hadi",
                    AssignedRole = "Recruiter",
                    PreferredCommunication = "SMS",
                    AccountStatus = "Active",
                    Location = "",
                    CompanyId = "455657467677",
                    NIN = "7273445",
                    UserType = "Verified by MoL",

                };
                u.UserId = 100 + i;
                u.FirstName = $"{i} Hammal";
                users.Add(u);
            }

            // Representative
            for (int i = 1; i < 8; i++)
            {
                CompanyUserDetails u = new CompanyUserDetails()
                {
                    FirstName = "Mohammed",
                    SecondName = "Ali",
                    ThirdName = "Bin",
                    LastName = "Hussain",
                    Position = "Human Resource Manager",
                    PhoneNumber = "088989389893",
                    EmailAddress = "email@emailexample.com",
                    UserName = "mohammad.hadi",
                    AssignedRole = "Representative",
                    PreferredCommunication = "SMS",
                    AccountStatus = "Active",
                    Location = "",
                    CompanyId = "455657467677",
                    NIN = "7273445",
                    UserType = "Verified by MoL",

                };
                u.UserId = 700 + i;
                u.FirstName = $"{i} Mohammed";
                users.Add(u);
            }
            return users;
        }


 

        public static CompanyDetails GetCompanyDetails()
        {
            var  c = new CompanyDetails()
            {
                CompanyLogo = "Logo.png",
                CompanyName = "Advance Electronics Company",
                CompanyURL = "www.aecl.com",
                CompanyDescription = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.Aenean commodo ligula eget dolor.Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium.Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a",
                Industry = "Professional Services",
                CompanySize = "Large (500 - 2999 employees)",
                ProfileID = "455657467677",
                PreferredLanguage = "English",

                ContactName = "Mohammed Fadi",
                ContactPosition = "Human Resource Manage",
                ContactMobile = "0788893834834",
                ContactPhone = "+966 4556565656",
                ContactEmail = "info@example.com",
            };

            return c;

        }

        public static ObservableCollection<EmployerJobDetail> GetEmployerPostedJobs()
        {
                var source = new ObservableCollection<EmployerJobDetail>()
                {
                        new EmployerJobDetail { JobPostId="1", JobPostTitle="Android developer, Java",  Status="Open", JobDescription="description 1",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google", Posted="1 Months",
                        JobType="PERM", OpenPositions="2", FilledPosition="1",
                        SalaryFrom="9000",  SalaryTo ="150000",
                        Experience="5 Years", StartDate="2/6/2017",
                        PublicationDate="16/04/2017",
                        RolesResponsibilities="Database, Management, Security Checkups",


                        CompanyLocation=new EmployerCompanyLocation {
                            LocationId ="Ryyad, KSA", Address="5453 Al Olaya street, Riyah 23351 - 2609, Saudi Arabia",
                            LocationNotes="The environment is disability confident", Latitude="22.755439", Longitude="46.209155"
                        },
                        WorkTime="Full Time", Shifttype="Day", Teleworking="No", Mobility="Restricted",
                        OtherBenefits="Yearly training courses", Bonus="Yes",
                        ApplicationRequirement="CV & References", SurveyUrl="http://surveyexample.com",
                        ContactPersonInd = new ContactPersonInd
                        {
                            Name="Saud Khalid", Email="khalid@aec.com"
                        },


                        JobLanguages = new ObservableCollection<JobDetailLanguage>
                        {
                            new JobDetailLanguage {Name="English", ProficiencyLevel="40" },
                            new JobDetailLanguage {Name="Arabic", ProficiencyLevel="90" },
                            new JobDetailLanguage {Name="General Database Programming", ProficiencyLevel="7" },
                            new JobDetailLanguage {Name="IT Security", ProficiencyLevel="50" }
                        },
                        JobLicenses = new ObservableCollection<JobDetailLicenses>
                        {
                            new JobDetailLicenses {Value="Public Work-Driving",ExpiryValue="10/2005-04/2010"},
                            new JobDetailLicenses {Value="Motorcycle Driving",ExpiryValue="10/2005-04/2010"}
                        }
                        , RequiresDrivingLicence="Yes", DrivingLicenceType="Private Licence",
                        JobTraining = new ObservableCollection<EmployerJobDetailTraining>
                        {
                            new EmployerJobDetailTraining {Name="Six Segma Green belt",InstituteName ="Microsoft",
                            Location="Jeddah, Saudi Arabia",Validity="10/2005-04/2010"}
                        }
                        },

                new EmployerJobDetail { JobPostId="2", JobPostTitle="Android developer, Java",  Status="Closed", JobDescription="description 2",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google", Posted="2 Months",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" } },
                new EmployerJobDetail { JobPostId="3", JobPostTitle="Android developer, Java",  Status="Open", JobDescription="description 3",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google",  Posted="1 Week",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" } },
                new EmployerJobDetail { JobPostId="4", JobPostTitle="Android developer, Java",  Status="Open", JobDescription="description 4",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google",  Posted="3 Months",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" }},
                new EmployerJobDetail { JobPostId="5", JobPostTitle="Android developer, Java",  Status="Closed", JobDescription="description 5",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google",  Posted="2 Weeks",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" }},
                new EmployerJobDetail { JobPostId="6", JobPostTitle="Android developer, Java",  Status="Open", JobDescription="description 6",
                        CompanyIndustry="Advanced Electronics", CompanyName="Google",  Posted="1 Months",
                        CompanyLocation=new EmployerCompanyLocation  {LocationId="Ryyad, KSA" }},
            };
            
            return source;

        }

        public static ObservableCollection<EmployerProgram> GetCurrentPrograms()
        {
            var progSource = new ObservableCollection<EmployerProgram>
            {
                new EmployerProgram {ProgramId=1, Status="Open", ProgramName="Job Commitment Bonus" ,
                Description="When registered to the Job Commitment Bonus Program, newly employed Saudi nationals who have already enrolled in Hafiz Searching for Employment, in Hafiz Difficulty Finding Employment, or in Employment Support can now benefit from cash rewards.\nThe amount of the reward is calculated based on a number of criteria, with individuals belonging to one of 4 different groups - each group is eligible to receive a different level of rewards over a different amount of time. The plans vary between 3 and 4 installments, over the course of 2 years and for a full cash amount that can reach up to 24, 000 SAR.",
                WhoCanBenefit="Individuals’ portfolios are divided into 4 groups with settlement of cash reward plan detailed as per the specifics and table below. For ease of calculation, job seekers can visit the following link.",
                ProgramRequirements="Applications enrolling in Hafiz, Searching for Employment and Hafiz, Difficulty Finding Employment should in general meet the following requirements:\nShould be a Saudi national, or having a Saudi mother.\nShould be aged between 20 and 60 years.\nShould be eligible to work.\nShould not be employed neither in the public nor private sectors.\nShould not be a trainee neither at a academical nor a professional level.\nShould not be a full time student.\nShould not have any traiding or commercial activities.\nShould not be a prisoner or deceased.\nShould not be benefititng from a fixed pension or a financial support or from a social facility lodging.\nShould not have benifited from a 2, 000 SAR salary or above for the past 12 months.\nShould not be currently benefiting from a monthly income that exceeds 3, 000 SAR.\nShould have completed the latest academical enrollment succesfully, more than 6 months prior to their application to the program.\nShould have applied for the program within the set deadlines for application.\nShould not have been be previously suspended from Hafiz Searching for Employment or Hafiz Difficulty Finding Employment programs.\nShould have enrolled in their job for less than 100 days at time of application to the program.",
                ProgramUrl="https://www.taqat.sa/web/guest/individuallogin",
                HowToRegister="Click  here  and follow the easy steps to register for this program."
                },
                new EmployerProgram {ProgramId=2, Status="Open", ProgramName="Search For Employment" },
                new EmployerProgram {ProgramId=3, Status="Open", ProgramName="Finding Employment" },
            };

            return progSource;
        }

        public static ObservableCollection<EmployerProgram> GetAllPrograms()
        {
            var progSource = new ObservableCollection<EmployerProgram>
            {
                new EmployerProgram {ProgramId=1, Status="Open", ProgramName="Job Commitment Bonus" ,
                Description="When registered to the Job Commitment Bonus Program, newly employed Saudi nationals who have already enrolled in Hafiz Searching for Employment, in Hafiz Difficulty Finding Employment, or in Employment Support can now benefit from cash rewards.\nThe amount of the reward is calculated based on a number of criteria, with individuals belonging to one of 4 different groups - each group is eligible to receive a different level of rewards over a different amount of time. The plans vary between 3 and 4 installments, over the course of 2 years and for a full cash amount that can reach up to 24, 000 SAR.",
                WhoCanBenefit="Individuals’ portfolios are divided into 4 groups with settlement of cash reward plan detailed as per the specifics and table below. For ease of calculation, job seekers can visit the following link.",
                ProgramRequirements="Applications enrolling in Hafiz, Searching for Employment and Hafiz, Difficulty Finding Employment should in general meet the following requirements:\nShould be a Saudi national, or having a Saudi mother.\nShould be aged between 20 and 60 years.\nShould be eligible to work.\nShould not be employed neither in the public nor private sectors.\nShould not be a trainee neither at a academical nor a professional level.\nShould not be a full time student.\nShould not have any traiding or commercial activities.\nShould not be a prisoner or deceased.\nShould not be benefititng from a fixed pension or a financial support or from a social facility lodging.\nShould not have benifited from a 2, 000 SAR salary or above for the past 12 months.\nShould not be currently benefiting from a monthly income that exceeds 3, 000 SAR.\nShould have completed the latest academical enrollment succesfully, more than 6 months prior to their application to the program.\nShould have applied for the program within the set deadlines for application.\nShould not have been be previously suspended from Hafiz Searching for Employment or Hafiz Difficulty Finding Employment programs.\nShould have enrolled in their job for less than 100 days at time of application to the program.",
                ProgramUrl="https://www.taqat.sa/web/guest/individuallogin",
                HowToRegister="Click  here  and follow the easy steps to register for this program."
                },
                new EmployerProgram {ProgramId=2, Status="Open", ProgramName="Search For Employment" },
                new EmployerProgram {ProgramId=3, Status="Open", ProgramName= "Finding Employment" },
                new EmployerProgram {ProgramId=4, Status="Open", ProgramName="Employment Support" },
                new EmployerProgram {ProgramId=5, Status="Open", ProgramName="Saned" },
                new EmployerProgram {ProgramId=6, Status="Open", ProgramName="Dooroob" },
                new EmployerProgram {ProgramId=7, Status="Open", ProgramName="Tamheer (On Job Training)" },

            };

            return progSource;
        }


        public static ObservableCollection<EmployerService> GetEmployerServices()
        {

            var servSource = new ObservableCollection<EmployerService>
            {
                new EmployerService { ServiceId=1, ServiceName = "Service 1", ServiceUrl="https://www.taqat.sa",
                        Introduction ="intro to service here\ninto to service here\ninto to service here\ninto to service here\ninto to service here\ninto to service here",
                    Beneficiaries ="Beneficiaries here\nBeneficiaries here\nBeneficiaries here\nBeneficiaries here\nBeneficiaries here\nBeneficiaries here\nBeneficiaries here",
                    Benefits ="Benefits will go here\nBenefits will go here\nBenefits will go here\nBenefits will go here\nBenefits will go here\nBenefits will go here\nBenefits will go here",
                    HowToRegister ="Some reg text here" },
                new EmployerService { ServiceId=2, ServiceName = "Service 2", ServiceUrl="https://www.taqat.sa",
                        Introduction = "into to service here", Beneficiaries = "Beneficiaries here", Benefits = "Benefits will go here", HowToRegister = "Some reg text here" },

            };

            return servSource;
        }

        public static ObservableCollection<EmployerService> GetALLServices()
        {

            var servSource = new ObservableCollection<EmployerService>
            {
                new EmployerService { ServiceId=1, ServiceName = "Service 1", ServiceUrl="https://www.taqat.sa",
                        Introduction ="intro to service here\ninto to service here\ninto to service here\ninto to service here\ninto to service here\ninto to service here",
                    Beneficiaries ="Beneficiaries here\nBeneficiaries here\nBeneficiaries here\nBeneficiaries here\nBeneficiaries here\nBeneficiaries here\nBeneficiaries here",
                    Benefits ="Benefits will go here\nBenefits will go here\nBenefits will go here\nBenefits will go here\nBenefits will go here\nBenefits will go here\nBenefits will go here",
                    HowToRegister ="Some reg text here" },
                new EmployerService { ServiceId=2, ServiceName = "Service 2", ServiceUrl="https://www.taqat.sa",
                        Introduction = "into to service here", Beneficiaries = "Beneficiaries here", Benefits = "Benefits will go here", HowToRegister = "Some reg text here" },
                new EmployerService { ServiceId=3, ServiceName = "Service 3", ServiceUrl="https://www.taqat.sa",
                        Introduction ="into to service here", Beneficiaries="Beneficiaries here", Benefits="Benefits will go here", HowToRegister="Some reg text here"},
                new EmployerService { ServiceId=4, ServiceName = "Service 4", ServiceUrl="https://www.taqat.sa",
                        Introduction ="into to service here", Beneficiaries="Beneficiaries here", Benefits="Benefits will go here", HowToRegister="Some reg text here" },

            };

            return servSource;
        }

        public static ObservableCollection<Announcement> GetAnnouncements()
        {
            // just return dummy values here
            var annSource = new ObservableCollection<Announcement>()
                {
                    new Announcement {Ttle= "Share your vacancies", Description="Post your available jobs in just minutes and gain exposure to thousands of potential candidates.", CompanyName="google", Featured=false, Image="", Url="" },
                    new Announcement {Ttle= "Find new talent", Description="Browse through TAQAT's candidate database to findteam members and leaders of your company",CompanyName="google", Featured=false, Image="", Url="" },
                    new Announcement {Ttle= "Obtain  salary substitutes", Description="receive up to 4,000 SAR per newly hired Saudi national per month, for up to a period of 48 hours.",CompanyName="google", Featured=false, Image="", Url="" },
                    new Announcement {Ttle= "Upskill your staff", Description="test announcement 4" , CompanyName="google", Featured=false, Image="", Url=""},
                    new Announcement {Ttle= "Announcement 5", Description="test announcement 5" ,CompanyName="google", Featured=false, Image="", Url=""},
                    new Announcement {Ttle= "Announcement 6", Description="test announcement 6" ,CompanyName="google", Featured=false, Image="", Url=""},
                    new Announcement {Ttle= "Announcement 7", Description="test announcement 7" ,CompanyName="google", Featured=false, Image="", Url=""},
                    new Announcement {Ttle= "Announcement 8", Description="test announcement 8" ,CompanyName="google", Featured=false, Image="", Url=""},
                    new Announcement {Ttle= "Announcement 9", Description="test announcement 9" ,CompanyName="google", Featured=false, Image="", Url=""},
                    new Announcement {Ttle= "Announcement 10", Description="test announcement 10" ,CompanyName="google", Featured=false, Image="", Url=""},
                    new Announcement {Ttle= "Announcement 11", Description="test announcement 11" ,CompanyName="google", Featured=false, Image="", Url=""},
                    new Announcement {Ttle= "Announcement 12", Description="test announcement 12",CompanyName="google", Featured=false, Image="", Url="" }

                };

            return annSource;
        }


    }
}
