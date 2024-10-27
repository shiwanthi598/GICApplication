using System;
using System.Collections.Generic;
using System.Linq;
using GICApplication.Domain.Enums;

namespace GICApplication.Domain.Entities
{
    public class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        public List<Transaction> Transactions { get; }

        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(DateTime date, TransactionType type, decimal amount)
        {
            var transaction = new Transaction(date, type, amount);
            Transactions.Add(transaction);

            if (type == TransactionType.Deposit)
            {
                Balance += amount;
            }
            else if (type == TransactionType.Withdrawal)
            {
                Balance -= amount;
            }
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
