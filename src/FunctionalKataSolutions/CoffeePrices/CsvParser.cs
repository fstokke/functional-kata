using System.Collections.Immutable;
using System.Globalization;
using FunctionalKataLib;

namespace FunctionalKata.CoffeePrices;

public static class CsvParser
{

    public static ImmutableList<CoffeePrice> ReadCoffeePrices(string filePath) =>
        File.ReadLines(filePath)
            .Skip(1)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line =>
            {
                var values = line.Split(',');

                var date = DateOnly.Parse(values[0], CultureInfo.InvariantCulture);
                var price = decimal.Parse(values[1], CultureInfo.InvariantCulture);

                return new CoffeePrice(date, price);
            })
            .ToImmutableList();
}