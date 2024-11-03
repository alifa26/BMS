using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BMS
{
    public abstract class Account
    {
        private float initialBalance;

        public string AccountId { get; }
        protected float Balance { get; set; }
        protected string Currency { get; set; }
        protected List<Transaction> Transactions { get; }

        protected Account(string accountId, float initialBalance, string currency)
        {
            AccountId = accountId;
            Balance = initialBalance;
            Currency = currency;
            Transactions = new List<Transaction>();
        }

        protected Account(string accountId, float initialBalance)
        {
            AccountId = accountId;
            this.initialBalance = initialBalance;
        }

        public virtual void Deposit(float amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount} {Currency} to account {AccountId}. New balance: {Balance}");
        }

        public virtual void Withdraw(float amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Deducted {amount} {Currency} from account {AccountId}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("NO ENOUGH BALANCE");
            }
        }
        public virtual void Transfer(float amount, Account targetAccount)
        {
            Withdraw(amount);
            targetAccount.Deposit(amount);
            Transaction transaction = new Transaction(this, targetAccount, amount);
            Transactions.Add(transaction);
            Console.WriteLine($"Transferred {amount} {Currency} from {AccountId} to {targetAccount.AccountId}");
        }

        public float getBalance() {
            return Balance;
        }
        public List<Transaction> GetTransactions() {
            return Transactions;
        }
        public void ApplyInterest()
        {
        }
    }
    }
