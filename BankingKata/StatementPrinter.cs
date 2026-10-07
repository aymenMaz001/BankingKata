
namespace BankingKata;

internal class StatementPrinter
{
	private const string Header = "DATE | AMOUNT | BALANCE";
	internal string Print(IEnumerable<Transaction> transactions)
	{
		var statement = Header;

		foreach (var transaction in transactions.OrderByDescending(d => d.Date))
		{
			statement += Environment.NewLine;
			statement += $"{transaction.Date:dd/MM/yyyy} | {transaction.Amount} | {transaction.Balance}";
		}

		return statement;
	}
}
