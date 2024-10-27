using System;

namespace GICApplication.Domain.Entities
{
    public class InterestRule
    {
         private decimal _interestRate;

        public InterestRule(decimal interestRate)
        {
            _interestRate = interestRate;
        }

        public decimal CalculateInterest(decimal balance)
        {
            return balance * _interestRate;
        }  
    }
}
