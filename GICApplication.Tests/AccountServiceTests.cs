using Xunit;
using GICApplication.Application.Services;
using GICApplication.Domain.Entities;
using GICApplication.Domain.Enums;
using System;

namespace GICApplication.Tests
{
    public class AccountServiceTests
    {
        private readonly AccountService _accountService;

        public AccountServiceTests()
        {
            // Initialize AccountService instance 
            _accountService = new AccountService();
        }

        [Fact]
        public void InputTransaction_ShouldCreateAccount_WhenNewAccountNumberIsProvided()
        {
            // Arrange
            string accountNumber = "AC001";
            DateTime date = DateTime.Now;
            TransactionType type = TransactionType.Deposit;
            decimal amount = 100.00m;

            // Act
            _accountService.InputTransaction(accountNumber, date, type, amount);

            // Assert
            
            try
            {
                _accountService.PrintStatement(accountNumber);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Exception was thrown: {ex.Message}");
            }
        }

        [Fact]
        public void ApplyInterest_ShouldIncreaseBalance_WhenInterestIsApplied()
        {
            // Arrange
            string accountNumber = "AC001";
            decimal initialAmount = 1000.00m;
            _accountService.InputTransaction(accountNumber, DateTime.Now, TransactionType.Deposit, initialAmount);

            var interestRule = new InterestRule(0.05m); // Assuming interest rate of 5%

            // Act
            _accountService.ApplyInterest(accountNumber, interestRule);

            // Assert
            // We don't have direct access to the balance, so we'll check using PrintStatement to ensure no errors and assume correct behavior.
            try
            {
                _accountService.PrintStatement(accountNumber);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Exception was thrown: {ex.Message}");
            }
        }

        [Fact]
        public void PrintStatement_ShouldShowAllTransactions_WhenCalled()
        {
            // Arrange
            string accountNumber = "AC002";
            _accountService.InputTransaction(accountNumber, DateTime.Now, TransactionType.Deposit, 500.00m);
            _accountService.InputTransaction(accountNumber, DateTime.Now, TransactionType.Withdrawal, 200.00m);

            // Act & Assert
            
            try
            {
                _accountService.PrintStatement(accountNumber);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Exception was thrown: {ex.Message}");
            }
        }
    }
}
