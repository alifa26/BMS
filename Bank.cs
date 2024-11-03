using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class Bank
    {
        private readonly Dictionary<string, Account> accounts;
        private readonly Dictionary<string, Customer> customers;

        public Bank()
        {
            accounts = new Dictionary<string, Account>();
            customers = new Dictionary<string, Customer>();
        }

        public void CreateCustomer(string customerId)
        {
            var customer = new Customer(customerId);
            customers[customerId] = customer;
            Console.WriteLine($"Customer {customerId} created.");
        }
        public Account CreateAccount(string customerId, string accountType, float initialBalance, float InterestRate = 0 , string currency = "USD")
        {
            if (!customers.ContainsKey(customerId))
                throw new InvalidOperationException("Customer does not exist.");

            Account account;
            if (accountType== "savings")
                account = new SavingsAccount(Guid.NewGuid().ToString(), initialBalance, InterestRate,currency);
            else if (accountType == "checking")
                account = new CheckingAccount(Guid.NewGuid().ToString(), initialBalance, InterestRate, currency);
            else
                throw new ArgumentException("Invalid account type.");

            accounts[account.AccountId] = account;
            customers[customerId].AddAccount(account);

            return account;
        }
        public Account GetAccount(string accountId)
        {
            accounts.TryGetValue(accountId, out var account);
            return account;
        }

        public void ProcessTransaction(string fromAccountId, string toAccountId, float amount)
        {
            var fromAccount = GetAccount(fromAccountId);
            var toAccount = GetAccount(toAccountId);

            if (fromAccount == null || toAccount == null)
                throw new InvalidOperationException("One or both accounts do not exist.");

            fromAccount.Transfer(amount, toAccount);
        }
    }


       
}
