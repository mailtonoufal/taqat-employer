using ArabWaha.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Employer.StaticData
{
    public static class StaticEntryHelper
    {

        public static ObservableCollection<SortByEntry> GetSortByEntries()
        {
            ObservableCollection<SortByEntry> vals = new ObservableCollection<SortByEntry>() {
                new SortByEntry { SortBy= SortByEnum.DISTANCE,  Selected = false },
                new SortByEntry { SortBy= SortByEnum.RELEVANCE,  Selected = false },
                new SortByEntry { SortBy= SortByEnum.SCORE_HIGH,  Selected = false },
                new SortByEntry { SortBy= SortByEnum.SCORE_LOW,  Selected = false },
                new SortByEntry { SortBy= SortByEnum.STARTDATE_RECENT,  Selected = false },
                new SortByEntry { SortBy= SortByEnum.STARTDATE_FUTURE,  Selected = false },
                new SortByEntry { SortBy= SortByEnum.GENDER_MALEFIRST,  Selected = false },
                new SortByEntry { SortBy= SortByEnum.GENDER_FEMALEFIRST,  Selected = false },
                };
            return vals;
        }
        public static ObservableCollection<JobTypeEntry> GetJobTypeEntries(JobTypeEnum? startVal = null, JobTypeEnum? endVal = null)
        {
            // when the data is pulled from Resource for the Text/Descriptions then we can loop round the values 0 -> lastVal and just add the entries.
            //var lastVal = Enum.GetValues(typeof(JobTypeEnum)).Cast<JobTypeEnum>().Last();

            ObservableCollection<JobTypeEntry> vals = new ObservableCollection<JobTypeEntry>() {
                new JobTypeEntry { JobTypeText = "PERM", Selected = false },
                new JobTypeEntry { JobTypeText = "CONTR", Selected = false },
                new JobTypeEntry { JobTypeText = "MINJOB", Selected = false },
                new JobTypeEntry { JobTypeText = "INTERN", Selected = false },
                new JobTypeEntry { JobTypeText = "SUMMJOB", Selected = false },
                new JobTypeEntry { JobTypeText = "TAMOJT", Selected = false },
                new JobTypeEntry { JobTypeText = "EMPDVNAC", Selected = false },
                };

            return vals;
        }

        public static ObservableCollection<ShiftTypeEntry> GetShiftTypeEntries()
        {
            ObservableCollection<ShiftTypeEntry> vals = new ObservableCollection<ShiftTypeEntry>() {
                new ShiftTypeEntry { ShiftType =ShiftTypeEnum.SHF_Day, Selected = false },
                new ShiftTypeEntry { ShiftType =ShiftTypeEnum.SHF_Night,  Selected = false },
                new ShiftTypeEntry { ShiftType =ShiftTypeEnum.SHF_TwoShifts, Selected = false },
                };

            return vals;
        }


        public static ObservableCollection<WorkTypeEntry> GetWorkTypeEntries()
        {
            ObservableCollection<WorkTypeEntry> vals = new ObservableCollection<WorkTypeEntry>() {
                new WorkTypeEntry { WorkType = WorkTimeEnum.FULLT,  Selected = false },
                new WorkTypeEntry { WorkType = WorkTimeEnum.PART,  Selected = false },
                };
            return vals;
        }

        public static ObservableCollection<TravellingRequiredEntry> GetTravellingRequiredEntries()
        {
            ObservableCollection<TravellingRequiredEntry> vals = new ObservableCollection<TravellingRequiredEntry>() {
                new TravellingRequiredEntry { TravellingRequired = TravellingRequiredEnum.Day,   Selected = false },
                new TravellingRequiredEntry { TravellingRequired = TravellingRequiredEnum.Night,   Selected = false },
                new TravellingRequiredEntry { TravellingRequired = TravellingRequiredEnum.TwoShifts,   Selected = false },
                };
            return vals;
        }

        public static ObservableCollection<TeleWorkingEntry> GetTeleWorkingEntries()
        {
            ObservableCollection<TeleWorkingEntry> vals = new ObservableCollection<TeleWorkingEntry>() {
                new TeleWorkingEntry { TeleWorking = TeleWorkingEnum.TELEW, Text = "Yes",  Selected = false },
                new TeleWorkingEntry { TeleWorking = TeleWorkingEnum.NOTELEW, Text = "No",  Selected = false },
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
        public static ObservableCollection<RequiredEducationEntry> GetRequiredEducationEntries()
        {
            //LES, Less than elementary school
            //ESH, Elementary school
            //HSH, High school or equivalent
            //BDG, Bachelor's degree or equivalent
            //MDG, Master's degree or equivalent postgraduate education
            //DDG, Doctorate degree or equivalent

            ObservableCollection<RequiredEducationEntry> vals = new ObservableCollection<RequiredEducationEntry>() {
                new RequiredEducationEntry { RequiredEducation= RequiredEducationEnum.LES,  Text = "Less than elementary school",  Selected = false },
                new RequiredEducationEntry { RequiredEducation= RequiredEducationEnum.ESH,  Text = "Elementary school",  Selected = false },
                new RequiredEducationEntry { RequiredEducation= RequiredEducationEnum.HSH,  Text = "High school or equivalent",  Selected = false },
                new RequiredEducationEntry { RequiredEducation= RequiredEducationEnum.BDG,  Text = "Bachelor's degree or equivalent",  Selected = false },
                new RequiredEducationEntry { RequiredEducation= RequiredEducationEnum.MDG,  Text = "Master's degree or equivalent postgraduate education",  Selected = false },
                new RequiredEducationEntry { RequiredEducation= RequiredEducationEnum.DDG,  Text = "Doctorate degree or equivalent",  Selected = false },
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
        public static ObservableCollection<SpecializationEntry> GetSpecializationEntries()
        {
            ObservableCollection<SpecializationEntry> vals = new ObservableCollection<SpecializationEntry>() {
                new SpecializationEntry { Specialization = SpecilizationEnum.Services,  Selected = false },
                new SpecializationEntry {  Specialization = SpecilizationEnum.GenericProgrammesAndQualifications,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.Education,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.ArtsAndHumanities,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.SocialSciences,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.BusinessAdministration,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.NaturalSciencesMathematics,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.InformationAndCommunicationTechnologies,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.EngineeringManufacturingConstruction,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.AgricultureForestryFisheriesVeterinary,  Selected = false },
                new SpecializationEntry { Specialization = SpecilizationEnum.HealthWelfare,  Selected = false },
                };
            return vals;
        }

        public static ObservableCollection<GenderEntry> GetGenderEntries()
        {
            ObservableCollection<GenderEntry> vals = new ObservableCollection<GenderEntry>() {
                new GenderEntry { Gender= GenderEnum.M,  Selected = false },
                new GenderEntry { Gender= GenderEnum.F,  Selected = false },
                new GenderEntry { Gender= GenderEnum.BOTH,  Selected = false },
                };
            return vals;
        }


        // No Enums yet for these but we will probably need to add them - just use generic to get page implemented first.
        public static ObservableCollection<PostedSinceEntry> GetPostedSinceEntries()
        {
            ObservableCollection<PostedSinceEntry> vals = new ObservableCollection<PostedSinceEntry>() {
                new PostedSinceEntry { Id = "TWODAYS", Text = "Two Days",  Selected = false },
                new PostedSinceEntry { Id = "ONEWEEK", Text = "One Week",  Selected = false },
                new PostedSinceEntry { Id = "TWOWEEKS", Text = "Two Weeks",  Selected = false },
                new PostedSinceEntry { Id = "THREEWEEKS", Text = "Three Weeks",  Selected = false },
                new PostedSinceEntry { Id = "FOURORMORE", Text = "Four Weeks or More",  Selected = false },
                };
            return vals;
        }
    }
}

    

