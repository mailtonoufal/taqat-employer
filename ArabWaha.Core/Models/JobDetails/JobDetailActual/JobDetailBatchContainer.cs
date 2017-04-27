using System;
namespace ArabWaha
{
	public class JobDetailBatchContainer
	{
		public JobDetailSetRoot JobDetailSet { get; set; }
		public JobDetailAttachmentsSetRoot JobDetailAttachments { get; set; }
		public JobDetailLanguageSetRoot JobDetailLanguages { get; set; }
		public JobDetailLicensesSetRoot JobDetailLicenses { get; set; }
		public JobDetailSkillsSetRoot JobDetailSkillsSet { get; set; }
		public JobDetailTrainingSetRoot JobDetailTraining { get; set; }

		//Applicable for only for Applied job case not more MatchedJobs
		public IndividualApplicationDetailRoot IndividualApplicationDetail{get;set;}
		public AppliedJobNotesRoot AppliedJobNotes { get; set;}
		public CoverLettersRoot CoverLetters { get; set; }
	}
}
