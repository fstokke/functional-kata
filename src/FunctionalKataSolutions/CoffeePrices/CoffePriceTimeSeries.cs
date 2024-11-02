using System.Collections.Immutable;
using FunctionalKataLib;

namespace FunctionalKata.CoffeePrices;

public static class CoffeePriceTimeSeries
{
    public static ImmutableList<CoffeePrice> MakeMonthlyAverageTimeSeries(ImmutableList<CoffeePrice> timeSeries) =>
        timeSeries.GroupBy(price => new DateOnly(price.Date.Year, price.Date.Month, 1))
            .Select(grouping => new CoffeePrice(grouping.Key, grouping.Average(coffeePrice => coffeePrice.Price)))
            .ToImmutableList();

    public static int FindNumPriceIncreases(ImmutableList<CoffeePrice> timeSeries) =>
        timeSeries.Zip(timeSeries.Skip(1)).Count(tuple => tuple.Second.Price > tuple.First.Price);

    public static ImmutableList<DateOnly> FindMissingDays(ImmutableList<CoffeePrice> timeSeries) =>
        timeSeries.Zip(timeSeries.Skip(1), (curr, next)
                => curr.Date.AddDays(1).RangeTo(next.Date.AddDays(-1)))
            .SelectMany(dates => dates)
            .ToImmutableList();

    public static ImmutableList<CoffeePrice> FillMissingDays(ImmutableList<CoffeePrice> timeSeries) =>
        timeSeries.Zip(timeSeries.Skip(1), (curr, next)
                => new[] {curr}.Concat(
                    curr.Date.AddDays(1).RangeTo(next.Date.AddDays(-1)).ToImmutableList()
                        .Select(date => curr with {Date = date})))
            .SelectMany(tsValues => tsValues)
            .Concat(timeSeries.TakeLast(1))
            .ToImmutableList();
}