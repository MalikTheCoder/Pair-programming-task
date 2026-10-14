public class BankAccount
{
    private static int nextAccountNumber = 100000;

    public string CustomerName { get; set; }
    public int AccountNumber { get; private set; }
    public decimal Balance { get; protected set; }

    public BankAccount(string customerName, decimal balance, int? accountNumber = null)
    {
        CustomerName = customerName;
        Balance = balance;

        if (accountNumber.HasValue)
        {
            AccountNumber = accountNumber.Value;
        }
        else
        {
            AccountNumber = nextAccountNumber++;
        }
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }
}