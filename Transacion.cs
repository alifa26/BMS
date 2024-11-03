using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS
{
    public class Transaction
    {
        Random rnd = new Random();
        public int TransactionId { get; }
        public Account FromAccount { get; }
        public Account ToAccount { get; }
        public float Amount { get; }
        public DateTime Date { get; }

        public Transaction(Account fromAccount, Account toAccount, float amount)
        {
            TransactionId = rnd.Next(1,9999);
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Amount = amount;
            Date = DateTime.Now;
        }

        
    }
}
