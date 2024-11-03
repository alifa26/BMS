using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class CheckingAccount : Account
    {
        private float OverdraftLimit { get; }

        public CheckingAccount(string accountId, float initialBalance, float overdraftLimit, string currency)
            : base(accountId, initialBalance, currency)
        {
            OverdraftLimit = overdraftLimit;
        }
        public void ApplyInterest()
        {
        }
        public float getBalance()
        {
            return Balance;
        }


    }
}
