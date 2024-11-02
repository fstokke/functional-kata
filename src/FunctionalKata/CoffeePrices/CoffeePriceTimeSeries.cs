using System.Collections.Immutable;
using FunctionalKataLib;

namespace FunctionalKata.CoffeePrices;

public static class CoffeePriceTimeSeries
{
    // Returns list of monthly average prices (months without prices are not included)
    public static ImmutableList<CoffeePrice> MakeMonthlyAverageTimeSeries(ImmutableList<CoffeePrice> timeSeries)
    {
        var numPricesInMonth = 0;
        decimal sumPricesInMonth = 0;
        var currYear = 0;
        int currMonth = 0;
        var monthlyTimeSeries = new List<CoffeePrice>();
        foreach (var curr in timeSeries)
        {
            var month = curr.Date.Month;
            if (month != currMonth)
            {
                if (numPricesInMonth > 0)
                {
                    var averagePrice = sumPricesInMonth / numPricesInMonth;
                    monthlyTimeSeries.Add(new CoffeePrice(new DateOnly(currYear, currMonth, 1), averagePrice));
                    numPricesInMonth = 0;
                    sumPricesInMonth = 0;
                }
            }
            currYear = curr.Date.Year;
            currMonth = curr.Date.Month;
            numPricesInMonth++;
            sumPricesInMonth += curr.Price;
        }

        if (numPricesInMonth > 0)
        {
            var averagePrice = sumPricesInMonth / numPricesInMonth;
            monthlyTimeSeries.Add(new CoffeePrice(new DateOnly(currYear, currMonth, 1), averagePrice));
        }
        
        return monthlyTimeSeries.ToImmutableList();

    }
    
    // Count number of times the price has increased compared to the price the day before
    public static int FindNumPriceIncreases(ImmutableList<CoffeePrice> timeSeries)
    {
        CoffeePrice? prev = null;
        var numPriceIncreases = 0;
        foreach (var curr in timeSeries)
        {
            if (prev != null)
            {
                if (curr.Price > prev.Price)
                {
                    numPriceIncreases++;
                }
            }
            
            prev = curr;
        }

        return numPriceIncreases;
    }
    
    // Finds gaps with missing days in a time series
    public static ImmutableList<DateOnly> FindMissingDays(ImmutableList<CoffeePrice> timeSeries)
    {
        CoffeePrice? prev = null;
        var missingDays = new List<DateOnly>();
        foreach (var curr in timeSeries)
        {
            if (prev != null)
            {
                var dates = prev.Date.AddDays(1).RangeTo(curr.Date.AddDays(-1)).ToImmutableList();
                missingDays.AddRange(dates);
            }
            
            prev = curr;
        }

        return missingDays.ToImmutableList();
    }
    
    // Fills gaps in a daily time series. Price for missing days will be set equal to the price on the day before. 
    public static ImmutableList<CoffeePrice> FillMissingDays(ImmutableList<CoffeePrice> timeSeries)
    {
        var newTimeSeries = new List<CoffeePrice>();
        CoffeePrice? prev = null;
      
        foreach (var curr in timeSeries)
        {
            if (prev != null)
            {
                var datesMissing = prev.Date.AddDays(1).RangeTo(curr.Date.AddDays(-1)).ToImmutableList();
                foreach (var date in datesMissing)
                {
                    newTimeSeries.Add(prev with {Date = date});
                }
            }
            
            newTimeSeries.Add(curr);
            prev = curr;
        }

        return newTimeSeries.ToImmutableList();
    }
    
}