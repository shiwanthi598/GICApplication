using System;
using GICApplication.Application.Interfaces;
using GICApplication.Application.Services;
using GICApplication.Domain.Entities;
using GICApplication.Domain.Enums;

namespace GICApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccountService accountService = new AccountService(); 
            try
            {
                 while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("T - Input Transactions");
                Console.WriteLine("I - Apply Interest");
                Console.WriteLine("S - Print Statement");
                Console.WriteLine("Q - Quit");
                Console.Write("Select an option: ");
                
                string option = Console.ReadLine().Trim().ToUpper();

                if (option == "T")
                {
                    Console.WriteLine("Please enter transaction details in <Date> <Account> <Type> <Amount> format (or enter blank to go back):");
                    string transactionDetails = Console.ReadLine();

                    if (string.IsNullOrEmpty(transactionDetails))
                        continue;

                    string[] details = transactionDetails.Split(' ');

                    DateTime date = DateTime.ParseExact(details[0], "yyyyMMdd", null);
                    string accountNumber = details[1];
                    TransactionType type = details[2] == "W" ? TransactionType.Withdrawal : TransactionType.Deposit;
                    decimal amount = decimal.Parse(details[3]);

                    accountService.InputTransaction(accountNumber, date, type, amount);
                }
                else if (option == "I")
                {
                    Console.Write("Enter Account Number: ");
                    string accountNumber = Console.ReadLine();

                    Console.Write("Enter Interest Rate (as decimal): ");
                    decimal interestRate = decimal.Parse(Console.ReadLine());

                    var interestRule = new InterestRule(interestRate);
                    accountService.ApplyInterest(accountNumber, interestRule);
                }
                else if (option == "S")
                {
                    Console.Write("Enter Account Number: ");
                    string accountNumber = Console.ReadLine();
                    //accountService.PrintStatement("Your Account is "+accountNumber);
                    Console.WriteLine("Your Account is: " + accountNumber);
                    accountService.PrintStatement(accountNumber);
                }
                else if (option == "Q")
                {
                    break;
                }
            }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid inputs");
                //throw ex;
            }
           
        }
    }
}
