using LoanLendingApp.Core.Helpers.Utilities;
using LoanLendingApp.Core.Interfaces;
using LoanLendingApp.Core.Models;

namespace LoanLendingApp.Core.Services
{
    public class LoanLendingService : ILoanLendingService
    {

        private readonly List<LoanRequestModel> _loanRequestModels = new();
        public bool LoanRequest(LoanRequestModel model)
        {
            LoanHelper.LoanRequest(model);
            _loanRequestModels?.Add(model);
            return model.IsLoanSuccessful;
        }
        public LoanStatusModel TotalApplicants()
        {
            return new LoanStatusModel 
            { 
                TotalApplication = _loanRequestModels.Count, 
                SuccessfulApplication = _loanRequestModels.Count(x => x.IsLoanSuccessful), 
                UnSuccessfulApplication = _loanRequestModels.Count(x => !x.IsLoanSuccessful) 
            };
        }
        public double TotalLoanValue()
        {
            return _loanRequestModels.Where(x => x.IsLoanSuccessful).Sum(x => x.LoanAmount);
        }
        public double MeanAverageLoanToValue()
        {
            return LoanHelper.CalculateLTV(loanAmount: _loanRequestModels
                .Where(x => x.IsLoanSuccessful).Sum(x => x.LoanAmount),
                assetValue: _loanRequestModels.Where(x => x.IsLoanSuccessful).Sum(x => x.AssetValue));
        }
    }
}
