using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using FunctionalKataLib;
using FunctionalKata.CoffeePrices;

namespace FunctionalKataTests.CoffeePrices;

// ReSharper disable once ClassNeverInstantiated.Global
public class CoffeePriceTimeSeriesTests
{
    public class MakeMonthlyAverageTimeSeriesTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeNotEvident")]
        public void ReturnsMonthlyTimeSeries()
        {
            var ts = ImmutableList.Create<CoffeePrice>(
                new(new DateOnly(2023, 08, 06), 10),
                new(new DateOnly(2023, 08, 07), 12),
                new(new DateOnly(2023, 08, 09), 10),
                new(new DateOnly(2023, 09, 10), 10),
                new(new DateOnly(2023, 09, 10), 14),
                new(new DateOnly(2023, 11, 14), 14),
                new(new DateOnly(2024, 2, 14), 14)
            );
            var monthlyTs = CoffeePriceTimeSeries.MakeMonthlyAverageTimeSeries(ts);
            var monthlyTsString = string.Join(", ", monthlyTs);
            Assert.Equal("2023-08-01: 10.67, 2023-09-01: 12.00, 2023-11-01: 14.00, 2024-02-01: 14.00", monthlyTsString);
        }
    }

    public class FindNumPriceIncreasesTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeNotEvident")]
        public void ReturnsMissingDays()
        {
            var ts = ImmutableList.Create<CoffeePrice>(
                new(new DateOnly(2023, 08, 06), 10),
                new(new DateOnly(2023, 08, 07), 11),
                new(new DateOnly(2023, 08, 09), 10),
                new(new DateOnly(2023, 08, 10), 10),
                new(new DateOnly(2023, 08, 14), 14)
            );
            var numPriceIncreases = CoffeePriceTimeSeries.FindNumPriceIncreases(ts);
            Assert.Equal(2, numPriceIncreases);
        }

        [Fact]
        public void HandlesEmptyTimeSeries()
        {
            var ts = ImmutableList<CoffeePrice>.Empty;
            var numPriceIncreases = CoffeePriceTimeSeries.FindNumPriceIncreases(ts);
            Assert.Equal(0, numPriceIncreases);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeNotEvident")]
        public void HandlesSingleItemTimeSeries()
        {
            var ts = ImmutableList.Create(
                new CoffeePrice[] {new(new DateOnly(2023, 08, 06), 10)});
            var numPriceIncreases = CoffeePriceTimeSeries.FindNumPriceIncreases(ts);
            Assert.Equal(0, numPriceIncreases);
        }
    }

    public class FindMissingDaysTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeNotEvident")]
        public void ReturnsMissingDays()
        {
            var ts = ImmutableList.Create<CoffeePrice>(
                new(new DateOnly(2023, 08, 06), 10),
                new(new DateOnly(2023, 08, 07), 11),
                new(new DateOnly(2023, 08, 09), 12),
                new(new DateOnly(2023, 08, 10), 13),
                new(new DateOnly(2023, 08, 14), 14)
            );
            var missingDays = CoffeePriceTimeSeries.FindMissingDays(ts);
            var missingDaysString = string.Join(", ", missingDays.Select(d => $"{d:yyyy-MM-dd}"));
            Assert.Equal("2023-08-08, 2023-08-11, 2023-08-12, 2023-08-13", missingDaysString);
        }

        [Fact]
        public void HandlesEmptyTimeSeries()
        {
            var ts = ImmutableList<CoffeePrice>.Empty;
            var missingDays = CoffeePriceTimeSeries.FindMissingDays(ts);
            Assert.Empty(missingDays);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeNotEvident")]
        public void HandlesSingleItemTimeSeries()
        {
            var ts = ImmutableList.Create(
                new CoffeePrice[] {new(new DateOnly(2023, 08, 06), 10)});
            var missingDays = CoffeePriceTimeSeries.FindMissingDays(ts);
            Assert.Empty(missingDays);
        }
    }

    public class FillMissingDaysTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeNotEvident")]
        public void InsertsPreviousValueForMissingDays()
        {
            var ts = ImmutableList.Create<CoffeePrice>(
                new(new DateOnly(2023, 08, 06), 10),
                new(new DateOnly(2023, 08, 07), 11),
                new(new DateOnly(2023, 08, 09), 12),
                new(new DateOnly(2023, 08, 10), 13),
                new(new DateOnly(2023, 08, 14), 14)
            );
            var tsWithoutHoles = CoffeePriceTimeSeries.FillMissingDays(ts);
            var tsWithoutHolesString = string.Join(", ", tsWithoutHoles);
            Assert.Equal("2023-08-06: 10.00, 2023-08-07: 11.00, 2023-08-08: 11.00, " +
                         "2023-08-09: 12.00, 2023-08-10: 13.00, 2023-08-11: 13.00, " +
                         "2023-08-12: 13.00, 2023-08-13: 13.00, 2023-08-14: 14.00", tsWithoutHolesString);
        }

        [Fact]
        public void HandlesEmptyTimeSeries()
        {
            var ts = ImmutableList<CoffeePrice>.Empty;
            var tsWithoutHoles = CoffeePriceTimeSeries.FillMissingDays(ts);
            Assert.Empty(tsWithoutHoles);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeNotEvident")]
        public void HandlesSingleItemTimeSeries()
        {
            var ts = ImmutableList.Create(
                new CoffeePrice[] {new(new DateOnly(2023, 08, 06), 10)});
            var tsWithoutHoles = CoffeePriceTimeSeries.FillMissingDays(ts);
            var tsWithoutHolesString = string.Join(", ", tsWithoutHoles);
            Assert.Equal("2023-08-06: 10.00", tsWithoutHolesString);
        }
    }
}