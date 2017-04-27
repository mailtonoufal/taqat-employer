using System;
using System.Collections.Generic;

namespace ArabWaha.Models
{
	public class SurveryResponseSet
	{
		public string surveyId { get; set; }
		public string questionId { get; set; }
		public string answerType { get; set; }
		public string answerOptionId { get; set; }
		public string rank { get; set; }
		public string percentage { get; set; }
		public string otherText { get; set; }
	}

	public class SurveyResponse
	{
		public string nesIndividualId { get; set; }
		public string surveyId { get; set; }
		public string questionId { get; set; }
		public string answerType { get; set; }
		public string answerOptionId { get; set; }
		public string rank { get; set; }
		public string percentage { get; set; }
		public string responseStatus { get; set; }
		public string obligationApplicationId { get; set; }
		public IList<SurveryResponseSet> SurveryResponseSet { get; set; }
	}

	public class AnswerDetails
	{
		public string QuestionID { get; set; }
		public string AnswerID { get; set; }
		public bool Clicked { get; set; }
	}
}
