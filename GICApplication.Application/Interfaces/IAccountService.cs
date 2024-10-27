using GICApplication.Domain.Entities;
using GICApplication.Domain.Enums;

namespace GICApplication.Application.Interfaces
{
    public interface IAccountService
    {
        void InputTransaction(string accountNumber, DateTime date, TransactionType type, decimal amount);
        void ApplyInterest(string accountNumber, InterestRule interestRule);
        void PrintStatement(string accountNumber);
    }
}
