using LoanLendingApp.Core.Models;
using LoanLendingApp.Core.Services;

namespace LoanLendingApp.Tests
{
    public class LoanLendingAppTests
    {
        private static LoanLendingService _loanLendingService = new();

        [Fact]
        public void Loan_Request_Is_Applicant_Successful_Test()
        {
            // re-initialize for accuracy
            _loanLendingService = new();

            // Expected
            bool shouldBeSuccessful = true;
            bool shouldBeUnsuccessful = false;

            // Arrange
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

            // Act
            var result1 = _loanLendingService.LoanRequest(loanRequest1);// should be successful
            var result2 = _loanLendingService.LoanRequest(loanRequest2);// should be unsuccessful
            var result3 = _loanLendingService.LoanRequest(loanRequest3);// should be successful

            // Assert

            Assert.Equal(expected: shouldBeSuccessful, actual: result1);
            Assert.Equal(expected: shouldBeUnsuccessful, actual: result2);
            Assert.Equal(expected: shouldBeSuccessful, actual: result3);
        }
        [Fact]
        public void Total_Applicants_Test()
        {
            // Expected
            int totalApplicants = 3;
            int successfulApplicants = 2;
            int unsuccessfulApplicants = 1;

            // Arrange
            // Make sure you are running all test in sequence else, you have to call Loan_Request_Is_Applicant_Successful_Test() first
            Loan_Request_Is_Applicant_Successful_Test();

            // Act
            var result = _loanLendingService.TotalApplicants();

            // Assert
            Assert.Equal(expected: totalApplicants, actual: result.TotalApplication);
            Assert.Equal(expected: successfulApplicants, actual: result.SuccessfulApplication);
            Assert.Equal(expected: unsuccessfulApplicants, actual: result.UnSuccessfulApplication);
        }
        [Fact]
        public void Total_Loan_Value_Test()
        {
            // Expected
            double expected = 1900000;

            // Arrange
            // Make sure you are running all test in sequence else, you have to call Loan_Request_Is_Applicant_Successful_Test() first
            Loan_Request_Is_Applicant_Successful_Test();
            // Act
            var result = _loanLendingService.TotalLoanValue();

            // Assert
            Assert.Equal(expected: expected, actual: result);
        }
        [Fact]
        public void Mean_Average_Loan_To_Value_Test()
        {
            // Expected
            double expected = 50;

            // Arrange
            // Make sure you are running all test in sequence else, you have to call Loan_Request_Is_Applicant_Successful_Test() first
            Loan_Request_Is_Applicant_Successful_Test();


            // Act
            var result = _loanLendingService.MeanAverageLoanToValue();

            // Assert
            Assert.Equal(expected: expected, actual: result);
        }
    }
}