namespace BankingKata.Tests;

public class BankingKataAcceptanceTests
{
	[Fact]
	public void ShouldProduceExpectedBankStatement()
	{
		var clock = new FakeClock(new DateOnly(2026, 1, 10));
		var account = new BankAccount(clock);
		var printer = new StatementPrinter();

		account.Deposit(1000);

		clock.Today = new DateOnly(2026, 1, 13);
		account.Deposit(2000);

		clock.Today = new DateOnly(2026, 1, 14);
		account.Withdraw(500);

		var statement = printer.Print(account.Transactions);

		Assert.Equal(
			"""
            DATE | AMOUNT | BALANCE
            14/01/2026 | -500 | 2500
            13/01/2026 | 2000 | 3000
            10/01/2026 | 1000 | 1000
            """,
			statement);
	}
}
