namespace BankingKata;

internal class BankAccount
{
	public decimal Balance { get; private set; }

	public void Deposit(decimal amount)
	{
		Balance += amount;
	}
}
