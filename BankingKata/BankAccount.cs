
using System.Collections;

namespace BankingKata;

internal class BankAccount
{
	public decimal Balance { get; private set; }
	private readonly List<Transaction> _transactions = [];
	public IReadOnlyList<Transaction> Transactions => _transactions;

	public void Deposit(decimal amount)
	{
		if (amount <= 0)
			throw new ArgumentOutOfRangeException(
				nameof(amount),
				"Deposit amount must be greater than zero.");
		Balance += amount;
		_transactions.Add(new Transaction(DateTime.Today,amount));
	}

	internal void Withdraw(decimal amount)
	{
		if (amount <= 0)
			throw new ArgumentOutOfRangeException(
				nameof(amount),
				"Withdraw amount must be greater than zero.");
		Balance -= amount;
		_transactions.Add(new Transaction(DateTime.Today, -amount));
	}
}
