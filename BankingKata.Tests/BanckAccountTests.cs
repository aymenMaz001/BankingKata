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
}