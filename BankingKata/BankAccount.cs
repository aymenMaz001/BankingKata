
using System.Collections;

namespace BankingKata;

internal class BankAccount
{
	public decimal Balance { get; private set; }
	private readonly List<Transaction> _transactions = [];
	public IReadOnlyList<Transaction> Transactions => _transactions;

	public void Deposit(decimal amount)
	{
		ValidateAmount(amount);
		Balance += amount;
		_transactions.Add(new Transaction(DateTime.Today,amount));
	}

	internal void Withdraw(decimal amount)
	{
		ValidateAmount(amount);
		Balance -= amount;
		_transactions.Add(new Transaction(DateTime.Today, -amount));
	}

	private static void ValidateAmount(decimal amount)
	{
		if (amount <= 0)
			throw new ArgumentOutOfRangeException(nameof(amount),"Amount must be greater than zero.");
	}
}
