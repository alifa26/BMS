using BMS;

public class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        // Create a customer
        bank.CreateCustomer("C001");

        // Create accounts for the customer
        var savingsAccount = bank.CreateAccount("C001", "savings", 1000, 5, "EUR");
        var checkingAccount = bank.CreateAccount("C001", "checking", 500, 0,"EUR");

        // Perform transactions
        savingsAccount.Deposit(200f);

        try
        {
            savingsAccount.Withdraw(100);
            checkingAccount.Deposit(150);
            bank.ProcessTransaction(savingsAccount.AccountId, checkingAccount.AccountId, 50);
            savingsAccount.ApplyInterest();

            //Check balances and transaction history
            Console.WriteLine("Savings Account Balance: {savingsAccount.getBalance()}");
            Console.WriteLine("Checking Account Balance: {checkingAccount.getBalance()}");

            foreach (var transaction in savingsAccount.GetTransactions())
            {
                Console.WriteLine(transaction);
            }

            foreach (var transaction in checkingAccount.GetTransactions())
            {
                Console.WriteLine(transaction);
            }

           
            checkingAccount.Withdraw(600);

            
            savingsAccount.Withdraw(1200);

        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: {ex.Message}");
        }

       
        Console.WriteLine("Bank operations completed.");
    }
}