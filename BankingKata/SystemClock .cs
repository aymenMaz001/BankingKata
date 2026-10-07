namespace BankingKata;

internal sealed class SystemClock : IClock
{
	public DateOnly Today => DateOnly.FromDateTime(DateTime.Today);
}
