using LoanLendingApp.Core.Models;

namespace LoanLendingApp.Core.Helpers.Utilities
{
    public static class LoanHelper
    {
        /*If the value of the loan is more than £1.5 million or less than £100,000
          then the application must be declined
         *If the value of the loan is £1 million or more then the LTV must be 60% or less
          and the credit score of the applicant must be 950 or more
        **If the value of the loan is less than £1 million then the following rules apply:
          *If the LTV is less than 60%, the credit score of the applicant must be 750 or more
          *If the LTV is less than 80%, the credit score of the applicant must be 800 or more
          *If the LTV is less than 90%, the credit score of the applicant must be 900 or more
          *If the LTV is 90% or more, the application must be declined */
        public static void LoanRequest(LoanRequestModel model)
        {
            model.IsLoanSuccessful = false;

            if (model.LoanAmount <= 0 || model.AssetValue <= 0)
                model.IsLoanSuccessful = false; // throw new Exception($"Value of asset and loan amount must be more than 0");

            if (model.LoanAmount < 100000 || model.LoanAmount > 1500000)
                model.IsLoanSuccessful = false; // throw new Exception($"Application Declined. Loan value must be between £100,000 and £1,500,000. The loan value requested is £{model.LoanAmount:C0}");

            var ltv = CalculateLTV(model.LoanAmount, model.AssetValue);

            if (model.LoanAmount >= 1000000)
            {
                if (ltv <= 60 && model.CreditScore >= 950)
                    model.IsLoanSuccessful = true;

                else
                    model.IsLoanSuccessful = false;
            }
            else
            {
                if (ltv < 60 && model.CreditScore >= 750)
                    model.IsLoanSuccessful = true;

                else if (ltv < 80 && model.CreditScore >= 800)
                    model.IsLoanSuccessful = true;

                else if (ltv < 90 && model.CreditScore >= 900)
                    model.IsLoanSuccessful = true;

                else if (ltv >= 90)
                    model.IsLoanSuccessful = false;
            }
        }
        public static double CalculateLTV(double loanAmount, double assetValue)
        {
            if (loanAmount <= 0 || assetValue <= 0)
                return 0;
            double ltv = (loanAmount / assetValue) * 100D;
            return ltv;
        }
    }
}
