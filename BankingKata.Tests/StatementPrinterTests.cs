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
}
