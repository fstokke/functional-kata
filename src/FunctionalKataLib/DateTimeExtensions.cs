namespace FunctionalKataLib;

public static class DateOnlyExtensions
{
    public static IEnumerable<DateOnly> RangeTo(this DateOnly fromInclusive, DateOnly toInclusive) =>
        Enumerable.Range(0, toInclusive.DayNumber - fromInclusive.DayNumber + 1).Select(fromInclusive.AddDays);
}