namespace LoanLendingApp.Core.Models
{
    public class LoanRequestModel
    {
        public string? ApplicantFullName { get; set; }
        public double LoanAmount { get; set; }
        public string? AssetName { get; set; }
        public double AssetValue { get; set; }
        public int CreditScore { get; set; }
        public DateTime RequestDate { get; set; }
        internal bool IsLoanSuccessful { get; set; }
    }
}
