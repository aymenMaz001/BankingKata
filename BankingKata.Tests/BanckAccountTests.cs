namespace BankingKata.Tests;

public class BanckAccountTests
{
	[Fact]
	public void Deposit_ShouldIncreaseBalance()
	{
		var account = new BankAccount();

		account.Deposit(1000);

		Assert.Equal(1000, account.Balance);
	}

	[Fact]
	public void MultipleDeposits_ShouldAccumulateBalance()
	{
		var account = new BankAccount();

		account.Deposit(1000);
		account.Deposit(2000);

		Assert.Equal(3000, account.Balance);
	}

	[Fact]
	public void Withdraw_ShouldDecreaseBalance()
	{
		var account = new BankAccount();

		account.Deposit(1000);
		account.Withdraw(400);

		Assert.Equal(600, account.Balance);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(-1)]
	[InlineData(-500)]
	public void Deposit_WhenAmountIsNotPositive_ShouldThrowArgumentOutOfRangeException(
	decimal amount)
	{
		var account = new BankAccount();

		var exception = Assert.Throws<ArgumentOutOfRangeException>(
			() => account.Deposit(amount));

		Assert.Equal("amount", exception.ParamName);
	}

	[Theory]
	[InlineData(0)]
	[InlineData(-1)]
	[InlineData(-500)]
	public void Withdraw_WhenAmountIsNotPositive_ShouldThrowArgumentOutOfRangeException(
	decimal amount)
	{
		var account = new BankAccount();

		var exception = Assert.Throws<ArgumentOutOfRangeException>(
			() => account.Withdraw(amount));

		Assert.Equal("amount", exception.ParamName);
	}

	[Fact]
	public void Deposit_ShouldRecordTransaction()
	{
		var account = new BankAccount();

		account.Deposit(1000);

		var transaction = Assert.Single(account.Transactions);

		Assert.Equal(1000, transaction.Amount);
	}

	[Fact]
	public void Withdraw_ShouldRecordTransaction()
	{
		var account = new BankAccount();

		account.Withdraw(1000);

		var transaction = Assert.Single(account.Transactions);

		Assert.Equal(-1000, transaction.Amount);
	}
}