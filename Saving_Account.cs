using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class SavingsAccount : Account
    {
        private float InterestRate { get; }

        public SavingsAccount(string accountId, float initialBalance, float interestRate, string currency)
            : base(accountId, initialBalance, currency)
        {
            InterestRate = interestRate;
        }

        public void ApplyInterest()
        {
            var interest = Balance * InterestRate / 100;
            Deposit(interest);
            Console.WriteLine($"Added interest of ${interest} to account {AccountId}. New balance: ${Balance}");
        }
        public float getBalance()
        {
            return Balance;
        }
    }
}

