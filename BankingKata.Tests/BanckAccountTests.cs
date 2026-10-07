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
}