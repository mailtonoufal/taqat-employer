using System;
namespace ArabWaha
{
	public class EnumGlobal
	{
		/// <summary>
		/// OTPR equest type.
		/// </summary>
		public enum OTPRequestType
		{
			OTPRequest = 1,
			ValidateOTP = 2
		}

		/// <summary>
		/// Applied job.
		/// </summary>
		public enum EnumAppliedJob
		{
			getJobDetailsSet,
			JobDetailAttachmentsSet,
			JobDetailLanguagesSet,
			JobDetailLicensesSet,
			JobDetailSkillsSet,
			JobDetailTrainingSet,
			IndividualApplicationDetailsSet,
			AppliedJobDetailNotesSet,
			getCoverLetterByIdSet
		}

		/// <summary>
		/// Applied job.
		/// </summary>
		public enum EnumMatchedWatchedJob
		{
			getJobDetailsSet,
			JobDetailAttachmentsSet,
			JobDetailLanguagesSet,
			JobDetailLicensesSet,
			JobDetailSkillsSet,
			JobDetailTrainingSet,
			//IndividualApplicationDetailsSet,
			//AppliedJobDetailNotesSet,
			//getCoverLetterByIdSet
		}

		/// <summary>
		/// Programs navigation.
		/// </summary>
		public enum Program
		{
			MyProgram = 1,
			ProgramList = 2
		}

		/// <summary>
		/// Program status.
		/// </summary>
		public enum ProgramStatus
		{
			All = 0,
			Applied = 1,
			Enrolled = 2,
			Eligible = 3,
			Suspended = 5,
			Terminated = 6,
			Pending_Data_Validation = 9,
			Not_Eligible = 10,
			Hold = 11,
			Not_Applied = 12
		}

		/// <summary>
		/// Survey Answer Types.
		/// </summary>
		public enum SurveyAnswerType
		{
			FreeText = 1,
			MultipleChoice = 2,
			RadioButton = 3,
			RankTable = 4,
			CumulativeSumAnswers = 5,
			TabularSingleChoiceAnswers = 6,
			TabularMultipleChoiceAnswers = 7,
			MaxDiffAnswers = 8,
			ConditionRadioButton = 9,
			Dropdown = 10
		}

		public enum JobDetailsType
		{
			Applied,
			Matched,
			Watched
		}

		public enum UpdateType
		{
			Add,
			Remove
		}

		public enum MaritalStatus
		{
			MAR_Single = 0,
			MAR_Married = 1,
			MAR_Divorced = 2,
			MAR_Widowed = 3
		}

		public enum DrivingLicense
		{
			DRLIC_Yes = 1,
			DRLIC_No = 2,
			DRLIC_Yes_Commercial = 3
		}

		public enum General
		{
			COMMON_Yes = 1,
			COMMON_No = 2
		}

		/// <summary>
		/// Login mode.
		/// </summary>
		public enum LoginMode
		{
			Guest_Search,
			Guest_ForgotPassword,
			Individual_Login,
			Individual_Mobile,
		}

		/// <summary>
		/// University Type
		/// </summary>
		public enum UniversityTypeID
		{
			GOV,
			PRIV
		}

		public enum GPAScale
		{
			GPA,
			PERC
		}

		public enum SkillLevel
		{
			BEG = 10,
			INT = 50,
			ADV = 100
		}

		public enum RegistrationStatus
		{
			REGPNVAL,
			REGFAILV,
			REPEEMAI,
			REGCOMP
		}
	}
}
