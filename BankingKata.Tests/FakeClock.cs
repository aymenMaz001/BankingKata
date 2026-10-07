namespace BankingKata.Tests;

internal sealed class FakeClock : IClock
{
	public FakeClock(DateOnly today)
	{
		Today = today;
	}

	public DateOnly Today { get; set; }
}