namespace InheritanceApp;

public class Account
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }
    public Account(string accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Credited {amount:C}. New balance is {Balance:C}.");
        }
        else
        {
            Console.WriteLine("Insufficient Balance for withdrawal of Amount: " + amount);
        }
    }
}

public sealed class SavingsAccount : Account
{
    public SavingsAccount(string accountNumber, decimal balance)
        : base(accountNumber, balance)
    {
    }

    public override void Withdraw(decimal amount)
    {
        // Savings account specific withdrawal logic; e.g., no overdrafts allowed
        if (amount <= Balance)
        {
            base.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Insufficient Balance for withdrawal of Amount: " + amount+" in savings account.");
        }
    }


}