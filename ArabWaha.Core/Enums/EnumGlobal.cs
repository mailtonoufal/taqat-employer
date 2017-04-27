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
	}
}
