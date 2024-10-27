//using System;
//using System.Collections.Generic;
using GICApplication.Application.Interfaces;
using GICApplication.Domain.Entities;
using GICApplication.Domain.Enums;

namespace GICApplication.Application.Services
{
    public class AccountService : IAccountService
    {
      private Dictionary<string, Account> _accounts;

        public AccountService()
        {
            _accounts = new Dictionary<string, Account>();
        }

        // Add transaction
        public void InputTransaction(string accountNumber, DateTime date, TransactionType type, decimal amount)
        {
            if (!_accounts.ContainsKey(accountNumber))
            {
                _accounts[accountNumber] = new Account(accountNumber);
            }

            var account = _accounts[accountNumber];
            account.AddTransaction(date, type, amount);
        }

        // Interest add
        public void ApplyInterest(string accountNumber, InterestRule interestRule)
        {
            if (_accounts.ContainsKey(accountNumber))
            {
                var account = _accounts[accountNumber];
                decimal interest = interestRule.CalculateInterest(account.Balance);
                account.AddTransaction(DateTime.Now, TransactionType.Deposit, interest); // Interest is added as deposit
                Console.WriteLine($"Applied interest: {interest} to account {accountNumber}");
            }
        }

        // Print statement
        public void PrintStatement(string accountNumber)
        {
            if (_accounts.ContainsKey(accountNumber))
            {
                var account = _accounts[accountNumber];
                Console.WriteLine($"Statement for account: {accountNumber}");
                foreach (var transaction in account.Transactions)
                {
                    Console.WriteLine($"{transaction.Date.ToShortDateString()} - {transaction.Type} - {transaction.Amount}");
                }
                Console.WriteLine($"Current Balance: {account.GetBalance()}");
            }
        }
    }
}

