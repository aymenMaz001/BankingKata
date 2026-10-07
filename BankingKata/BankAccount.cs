
namespace BankingKata;

internal class BankAccount
{
	public decimal Balance { get; private set; }

	public void Deposit(decimal amount)
	{
		if (amount <= 0)
			throw new ArgumentOutOfRangeException(
				nameof(amount),
				"Deposit amount must be greater than zero.");
		Balance += amount;
	}

	internal void Withdraw(decimal amount)
	{
		if (amount <= 0)
			throw new ArgumentOutOfRangeException(
				nameof(amount),
				"Withdraw amount must be greater than zero.");
		Balance -= amount;
	}
}
