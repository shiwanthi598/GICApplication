using System;
using GICApplication.Domain.Enums;

namespace GICApplication.Domain.Entities
{
   public class Transaction
    {
        public DateTime Date { get; private set; }
        public TransactionType Type { get; private set; }
        public decimal Amount { get; private set; }

        public Transaction(DateTime date, TransactionType type, decimal amount)
        {
            Date = date;
            Type = type;
            Amount = amount;
        }
    }

    
}
