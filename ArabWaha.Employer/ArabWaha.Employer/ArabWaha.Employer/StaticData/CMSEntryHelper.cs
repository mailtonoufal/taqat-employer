using System;
using System.Collections.ObjectModel;
using ArabWaha.Enums;

namespace ArabWaha.Employer.StaticData
{
    public static class CMSEntryHelper
    {
		public static ObservableCollection<SortByEntryCMS> GetSortByEntries()
		{
            ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
                new SortByEntryCMS { TextTitle="filterlbldistance", Value="DISTANCE",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblrelevance", Value="RELEVANCE",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblmatscorehigh", Value="SCORE_HIGH",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblmatscorelow", Value="SCORE_LOW",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblstartdaterecent", Value="STARTDATE_RECENT",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblstartdatefuture", Value="STARTDATE_FUTURE",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblgendermale", Value="GENDER_MALEFIRST",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblgenderfemale", Value="GENDER_FEMALEFIRST",  Selected = false },
				};
			return vals;
		}
		public static ObservableCollection<SortByEntryCMS> GetJobTypeEntries(JobTypeEnum? startVal = null, JobTypeEnum? endVal = null)
		{
			// when the data is pulled from Resource for the Text/Descriptions then we can loop round the values 0 -> lastVal and just add the entries.
			//var lastVal = Enum.GetValues(typeof(JobTypeEnum)).Cast<JobTypeEnum>().Last();

			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
                
				new SortByEntryCMS { TextTitle="filterlbljtpermanent", Value="PERM",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlbljtcontract", Value="CONTR",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlbljtminijob", Value="MINJOB",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlbljtinternship", Value="INTERN",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlbljtsummerjob", Value="SUMMJOB",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlbljttamheer", Value="TAMOJT",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlbljtemploymentdriven", Value="EMPDVNAC",  Selected = false }
				};

			return vals;
		}

		public static ObservableCollection<SortByEntryCMS> GetShiftTypeEntries()
		{
			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
				new SortByEntryCMS { TextTitle="filterlblshifttypeday", Value="SHF_Day",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblshifttypenight", Value="SHF_Night",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblshifttypetwoshifts", Value="SHF_TwoShifts",  Selected = false },
				};

			return vals;
		}


		public static ObservableCollection<SortByEntryCMS> GetWorkTypeEntries()
		{
			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
				new SortByEntryCMS { TextTitle="filterlblworktypefulltime", Value="FULLT",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblworktypeparttime", Value="PART",  Selected = false },
				};
			return vals;
		}

		public static ObservableCollection<SortByEntryCMS> GetTravellingRequiredEntries()
		{
			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
				new SortByEntryCMS { TextTitle="filterlblshifttypeday", Value="SHF_Day",  Selected = false },
                new SortByEntryCMS { TextTitle="filterlblshifttypenight", Value="SHF_Night",  Selected = false },
                new SortByEntryCMS { TextTitle="filterlblshifttypetwoshifts", Value="SHF_TwoShifts",  Selected = false },
				};
			return vals;
		}

		public static ObservableCollection<SortByEntryCMS> GetTeleWorkingEntries()
		{
			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
				new SortByEntryCMS { TextTitle="filterlbltravelreqyes", Value="TELEW",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlbltravelreqno", Value="NOTELEW",  Selected = false },
				};
			return vals;
		}


		/* From Individual/Core Resouces - we need to add/merge into ours.

            <data name="TCD" xml:space="preserve">
            <value>Technical diploma or equivalent</value>
            <comment>Education Level</comment>
            </data>
            <data name="HTC" xml:space="preserve">
            <value>Higher technical education, associate degree or equivalent</value>
            <comment>Education Level</comment>
            </data>
            <data name="LES" xml:space="preserve">
            <value>Less than elementary school</value>
            <comment>Education Level</comment>
            </data>
            <data name="ESH" xml:space="preserve">
            <value>Elementary school</value>
            <comment>Education Level</comment>
            </data>
            <data name="MSH" xml:space="preserve">
            <value>Middle school</value>
            <comment>Education Level</comment>
            </data>
            <data name="HSH" xml:space="preserve">
            <value>High school or equivalent</value>
            <comment>Education Level</comment>
            </data>
            <data name="BDG" xml:space="preserve">
            <value>Bachelor's degree or equivalent</value>
            <comment>Education Level</comment>
            </data>
            <data name="MDG" xml:space="preserve">
            <value>Master's degree or equivalent postgraduate education</value>
            <comment>Education Level</comment>
            </data>
            <data name="DDG" xml:space="preserve">
            <value>Doctorate degree or equivalent</value>
            <comment>Education Level</comment>
            </data>

        */
		public static ObservableCollection<SortByEntryCMS> GetRequiredEducationEntries()
		{
			//LES, Less than elementary school
			//ESH, Elementary school
			//HSH, High school or equivalent
			//BDG, Bachelor's degree or equivalent
			//MDG, Master's degree or equivalent postgraduate education
			//DDG, Doctorate degree or equivalent


			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {

				new SortByEntryCMS { TextTitle="filterlblreqedulessthanelementary", Value="LES",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblreqeduelementary", Value="ESH",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblreqeduhighschool", Value="HSH",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblreqedubachelordeg", Value="BDG",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblreqedumasterdeg", Value="MDG",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblreqedudoctoratedeg", Value="DDG",  Selected = false },
				};
			return vals;
		}


		// Specialization emum
		/*
        
        Notapplicable = 12,
        Services = 11,
        GenericProgrammesAndQualifications = 1,
        Education = 2,
        ArtsAndHumanities = 3,
        SocialSciences = 4,
        BusinessAdministration = 5,
        NaturalSciencesMathematics = 6,
        InformationAndCommunicationTechnologies = 7,
        EngineeringManufacturingConstruction = 8,
        AgricultureForestryFisheriesVeterinary = 9,
        HealthWelfare = 10
        */
		public static ObservableCollection<SortByEntryCMS> GetSpecializationEntries()
		{
			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
				new SortByEntryCMS { TextTitle="filterlblspecservices", Value="Services",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspecgenericprog", Value="GenericProgrammesAndQualifications",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspeceducation", Value="Education",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspecarts", Value="ArtsAndHumanities",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspecsocial", Value="SocialSciences",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspecbusiness", Value="BusinessAdministration",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspecnaturalsciences", Value="NaturalSciencesMathematics",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspecinformation", Value="InformationAndCommunicationTechnologies",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspecengineering", Value="EngineeringManufacturingConstruction",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspecagriculture", Value="AgricultureForestryFisheriesVeterinary",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblspechealth", Value="HealthWelfare",  Selected = false },
				};
			return vals;
		}

		public static ObservableCollection<SortByEntryCMS> GetGenderEntries()
		{
			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
				new SortByEntryCMS { TextTitle="filterlblgenmale", Value="M",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblgenfemale", Value="F",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblgenothers", Value="BOTH",  Selected = false },
				};
			return vals;
		}


		// No Enums yet for these but we will probably need to add them - just use generic to get page implemented first.
		public static ObservableCollection<SortByEntryCMS> GetPostedSinceEntries()
		{
			ObservableCollection<SortByEntryCMS> vals = new ObservableCollection<SortByEntryCMS>() {
				new SortByEntryCMS { TextTitle="filterlblpostedsincetwodays", Value="TWODAYS",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblpostedsinceoneweek", Value="ONEWEEK",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblpostedsincetwoweeks", Value="TWOWEEKS",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblpostedsincethreeweeks", Value="THREEWEEKS",  Selected = false },
				new SortByEntryCMS { TextTitle="filterlblpostedsincefourweeks", Value="FOURORMORE",  Selected = false },
				};
			return vals;
		}
    }
}
