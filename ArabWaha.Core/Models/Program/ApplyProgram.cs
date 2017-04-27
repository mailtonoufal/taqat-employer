using System;
using Newtonsoft.Json;

namespace ArabWaha.Models
{
	public class ApplyProgram
	{
		[JsonProperty("programId")]
		public int ProgramID { get; set; }

		[JsonProperty("userId")]
		public int UserID { get; set; }

		[JsonProperty("sapBPId")]
		public string SapBPId { get; set; }

		[JsonProperty("locale")]
		public string Locale { get; set; }

		[JsonProperty("termsConditionFlag")]
		public bool TermsConditionFlag { get; set; }

		[JsonProperty("termsConditionId")]
		public string TermsConditionID { get; set; }

		[JsonProperty("bankAccountNo")]
		public string BankAccountNo { get; set; }

		[JsonProperty("relativePhoneNumber")]
		public string RelativePhoneNumber { get; set; }

		[JsonProperty("havePrimaryInternetAccess")]
		public bool HavePrimaryInternetAccess { get; set; }

		[JsonProperty("rentFromFixedMovableAssests")]
		public string RentFromFixedMovableAssests { get; set; }

		[JsonProperty("sharesDividends")]
		public string SharesDividends { get; set; }

		[JsonProperty("courtOrderOrPayments")]
		public string CourtOrderOrPayments { get; set; }

		[JsonProperty("otherGovernmentIncome")]
		public string OtherGovernmentIncome { get; set; }

		[JsonProperty("otherIncome")]
		public string OtherIncome { get; set; }

		[JsonProperty("amountRecievedFromSocialSecurity")]
		public string AmountRecievedFromSocialSecurity { get; set; }

		[JsonProperty("totalMonthlyIncome")]
		public string TotalMonthlyIncome { get; set; }

		[JsonProperty("amountRecievedFromGosiOrPPA")]
		public string AmountRecievedFromGosiOrPPA { get; set; }

	}
}
