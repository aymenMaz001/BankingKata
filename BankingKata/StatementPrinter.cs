
using System.Text;

namespace BankingKata;

internal class StatementPrinter
{
	private const string Header = "DATE | AMOUNT | BALANCE";
	internal string Print(IEnumerable<Transaction> transactions)
	{
		var statement = new StringBuilder(Header);

		foreach (var transaction in transactions.OrderByDescending(t => t.Date))
		{
			statement
				.AppendLine()
				.Append(transaction.Date.ToString("dd/MM/yyyy"))
				.Append(" | ")
				.Append(transaction.Amount)
				.Append(" | ")
				.Append(transaction.Balance);
		}

		return statement.ToString();
	}
}
