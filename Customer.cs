using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class Customer
    {
        public string CustomerId { get; }
        private List<Account> Accounts { get; }

        public Customer(string customerId)
        {
            CustomerId = customerId;
            Accounts = new List<Account>();
        }
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
            Console.WriteLine($"Added account {account.AccountId} for customer {CustomerId}");
        }

        public float GetBalance(string accountId)
        {
            var account = Accounts.Find(a => a.AccountId == accountId);
            return account.getBalance();
        }
        public List<Transaction> GetTransactions(string accountId)
        {
            var account = Accounts.Find(a => a.AccountId == accountId);
            return account.GetTransactions();
        }
    }
}
