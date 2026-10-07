
using System.Collections;

namespace BankingKata;

internal class BankAccount
{
	public decimal Balance { get; private set; }

	private readonly List<Transaction> _transactions = [];
	public IReadOnlyList<Transaction> Transactions => _transactions;
	private readonly IClock _clock;

	public BankAccount(IClock clock)
	{
		_clock = clock;
	}

	public void Deposit(decimal amount)
	{
		ValidateAmount(amount);
		Balance += amount;
		_transactions.Add(new Transaction(_clock.Today,amount, Balance));
	}

	internal void Withdraw(decimal amount)
	{
		ValidateAmount(amount);
		Balance -= amount;
		_transactions.Add(new Transaction(_clock.Today, -amount, Balance));
	}

	private static void ValidateAmount(decimal amount)
	{
		if (amount <= 0)
			throw new ArgumentOutOfRangeException(nameof(amount),"Amount must be greater than zero.");
	}
}
