namespace BankingKata.Tests;

public class StatementPrinterTests
{
	[Fact]
	public void EmptyAccount_ShouldPrintOnlyHeader()
	{
		var printer = new StatementPrinter();

		var statement = printer.Print([]);

		Assert.Equal("DATE | AMOUNT | BALANCE", statement);
	}

	[Fact]
	public void Statement_ShouldPrintTransaction()
	{
		var transactions = new[]
		{
		new Transaction(new DateOnly(2026, 1, 10),1000,1000)
		};

		var statement = new StatementPrinter().Print(transactions);

		Assert.Equal(
			"""
        DATE | AMOUNT | BALANCE
        10/01/2026 | 1000 | 1000
        """,
			statement);
	}

	[Fact]
	public void Statement_ShouldPrintTransactionsInReverseChronologicalOrder()
	{
		var transactions = new[]
		{
		new Transaction(new DateOnly(2026, 1, 10), 1000, 1000),
		new Transaction(new DateOnly(2026, 1, 13), 2000, 3000),
		new Transaction(new DateOnly(2026, 1, 14), -500, 2500)
	};

		var statement = new StatementPrinter().Print(transactions);

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
