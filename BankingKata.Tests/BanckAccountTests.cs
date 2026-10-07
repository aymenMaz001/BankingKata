namespace BankingKata.Tests;

public class BanckAccountTests
{
	private readonly FakeClock _clock = new(new DateOnly(2026, 1, 10));
	private readonly BankAccount _account;

	public BanckAccountTests()
	{
		_clock = new FakeClock(new DateOnly(2026, 1, 10));
		_account = new BankAccount(_clock);
	}

	[Fact]
	public void Deposit_ShouldIncreaseBalance()
	{
		_account.Deposit(1000);
		var transaction = Assert.Single(_account.Transactions);

		Assert.Equal(1000, transaction.Amount);
	}

	[Fact]
	public void MultipleDeposits_ShouldAccumulateBalance()
	{
		_account.Deposit(1000);
		_account.Deposit(2000);

		Assert.Equal(3000, _account.Balance);
	}

	[Fact]
	public void Withdraw_ShouldDecreaseBalance()
	{
		_account.Deposit(1000);
		_account.Withdraw(400);

		Assert.Equal(600, _account.Balance);

	}

	[Theory]
	[InlineData(0)]
	[InlineData(-1)]
	[InlineData(-500)]
	public void Deposit_WhenAmountIsNotPositive_ShouldThrowArgumentOutOfRangeException(
	decimal amount)
	{
		var exception = Assert.Throws<ArgumentOutOfRangeException>(
			() => _account.Deposit(amount));

		Assert.Equal("amount", exception.ParamName);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(-1)]
	[InlineData(-500)]
	public void Withdraw_WhenAmountIsNotPositive_ShouldThrowArgumentOutOfRangeException(
	decimal amount)
	{
		var exception = Assert.Throws<ArgumentOutOfRangeException>(
			() => _account.Withdraw(amount));

		Assert.Equal("amount", exception.ParamName);
	}

	[Fact]
	public void Deposit_ShouldRecordTransaction()
	{
		_account.Deposit(1000);

		var transaction = Assert.Single(_account.Transactions);

		Assert.Equal(1000, transaction.Amount);
	}

	[Fact]
	public void Withdraw_ShouldRecordNegativeTransaction()
	{
		_account.Deposit(1000);
		_account.Withdraw(500);
		var transaction = _account.Transactions.Last();

		Assert.Equal(-500, transaction.Amount);
	}

	[Fact]
	public void Deposit_ShouldRecordTransactionDate()
	{
		_account.Deposit(1000);

		Assert.Equal(new DateOnly(2026, 1, 10),_account.Transactions.Single().Date);
	}

	[Fact]
	public void Transactions_ShouldContainRunningBalance()
	{
		_account.Deposit(1000);
		_account.Deposit(2000);
		_account.Withdraw(500);

		Assert.Collection(
			_account.Transactions,
			t => Assert.Equal(1000, t.Balance),
			t => Assert.Equal(3000, t.Balance),
			t => Assert.Equal(2500, t.Balance));
	}


}

internal sealed class FakeClock : IClock
{
	public FakeClock(DateOnly today)
	{
		Today = today;
	}

	public DateOnly Today { get; set; }
}