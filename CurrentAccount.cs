public class CurrentAccount : BankAccount
{
    public decimal OverdraftLimit { get; private set; }

    public CurrentAccount(
        string customerName,
        decimal balance,
        decimal overdraftLimit,
        int? accountNumber = null)
        : base(customerName, balance, accountNumber)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override bool Withdraw(decimal amount)
    {
        if (amount > 0 && Balance - amount >= -OverdraftLimit)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }
}
