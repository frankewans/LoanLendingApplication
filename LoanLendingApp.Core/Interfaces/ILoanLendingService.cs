
using LoanLendingApp.Core.Models;

namespace LoanLendingApp.Core.Interfaces
{
    public interface ILoanLendingService
    {
        bool LoanRequest(LoanRequestModel model);
        LoanStatusModel TotalApplicants();
        double TotalLoanValue(); 
        double MeanAverageLoanToValue();
    }
}
