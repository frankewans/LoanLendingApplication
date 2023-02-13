using LoanLendingApp.Core.Models;
using LoanLendingApp.Core.Services;

namespace LoanLending.App
{
    public class Program
    {
        private static LoanLendingService _loanLendingService = new();
        public static void Main(string[] args)
        {
            var loanRequest1 = new LoanRequestModel // should be successful
            {
                ApplicantFullName = "Francis Stephen",
                LoanAmount = 1000000,
                AssetValue = 2000000,
                AssetName = "Land",
                CreditScore = 950,
                RequestDate = DateTime.Now
            };
            var loanRequest2 = new LoanRequestModel // should be unsuccessful
            {
                ApplicantFullName = "Tim Carter",
                LoanAmount = 20000,
                AssetValue = 10000,
                AssetName = "Mercedece Benz C-Class 2009 Model",
                CreditScore = 200,
                RequestDate = DateTime.Now
            };
            var loanRequest3 = new LoanRequestModel // should be successful
            {
                ApplicantFullName = "John Doe",
                LoanAmount = 900000,
                AssetValue = 1800000,
                AssetName = "Gold Ring",
                CreditScore = 800,
                RequestDate = DateTime.Now
            };
            Console.WriteLine(LoanRequest(loanRequest1));
            Console.WriteLine(LoanRequest(loanRequest2));
            Console.WriteLine(LoanRequest(loanRequest3));
            Console.WriteLine(TotalApplicants());
            Console.WriteLine(TotalLoanValue());
            Console.WriteLine(MeanAverageLoanToValue());
            Console.ReadLine();
        }
        private static bool LoanRequest(LoanRequestModel model)
        {
            var result = _loanLendingService.LoanRequest(model);
            return result;
        }
        private static LoanStatusModel TotalApplicants()
        {
            var result = _loanLendingService.TotalApplicants();
            return result;
        }
        private static double TotalLoanValue()
        {
            var result = _loanLendingService.TotalLoanValue();
            return result;
        }
        private static double MeanAverageLoanToValue()
        {
            var result = _loanLendingService.MeanAverageLoanToValue();
            return result;
        }
    }
}