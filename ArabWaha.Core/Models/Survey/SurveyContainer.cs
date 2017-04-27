using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ArabWaha
{
	//EntityForSurveyAnswerSet
	public class SurveyAnswerResult
	{
		public string surveyId { get; set; }
		public string surveyAnswerId { get; set; }
		public string questionId { get; set; }
		public string answerOption { get; set; }
	}

	public class SurveyAnswerResultList
	{
		[JsonProperty("results")]
		public IList<SurveyAnswerResult> SurveyAnswerResult { get; set; }
	}

	public class SurveyAnswerResultRoot
	{
		[JsonProperty("d")]
		public SurveyAnswerResultList SurveyAnswerResultList { get; set; }
	}


	//EntityForSurveyByID
	public class TargetSegmentInfo
	{
		public string allNin { get; set; }
		public string allIquama { get; set; }
		public string males { get; set; }
	}

	public class Survey
	{
		public string surveyId { get; set; }
		public string surveyName { get; set; }
		public string surveyDescription { get; set; }
		public TargetSegmentInfo TargetSegmentInfo { get; set; }
		public string surveyType { get; set; }
		public string modelSurveyNumber { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public bool addSurveyToPSO { get; set; }
		public bool isPublished { get; set; }
		public bool isActive { get; set; }
	}

	public class SurveyResult
	{
		public string surveyId { get; set; }
		public Survey Survey { get; set; }
	}

	public class SurveyResultList
	{
		[JsonProperty("results")]
		public IList<SurveyResult> SurveyResult { get; set; }
	}

	public class SurveyResultListRoot
	{
		[JsonProperty("d")]
		public SurveyResultList SurveyResultList { get; set; }
	}

	//EntityForSurveyQuestionSet
	public class SurveyQuestionResult
	{
		public string surveyId { get; set; }
		public string questionId { get; set; }
		public string questionDesription { get; set; }
		public string answerType { get; set; }
		public string questionNumber { get; set; }
		public bool isMandatory { get; set; }
		public string order { get; set; }
	}

	public class SurveyQuestionResultList
	{
		[JsonProperty("results")]
		public IList<SurveyQuestionResult> SurveyQuestionResult { get; set; }
	}

	public class SurveyQuestionResultListRoot
	{
		[JsonProperty("d")]
		public SurveyQuestionResultList SurveyQuestionResultList { get; set; }
	}

	public class SurveyContainer
	{
		public SurveyAnswerResultRoot SurveyAnswerResultRoot { get; set; }
		public SurveyResultListRoot SurveyResultListRoot { get; set; }
		public SurveyQuestionResultListRoot SurveyQuestionResultListRoot { get; set; }
	}
}
