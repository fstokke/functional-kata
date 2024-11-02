using System.Collections.Immutable;
using System.Globalization;
using FunctionalKataLib;

namespace FunctionalKata.CoffeePrices;

public static class CsvParser
{
    public static ImmutableList<CoffeePrice> ReadCoffeePrices(string filePath)
    {
        var records = new List<CoffeePrice>();

        
        using (var reader = new StreamReader(filePath))
        {
            // Skip the header line
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                // Skip blank lines
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var values = line.Split(',');

                var date = DateOnly.Parse(values[0], CultureInfo.InvariantCulture);
                var price = decimal.Parse(values[1], CultureInfo.InvariantCulture);

                var record = new CoffeePrice(date, price);
                records.Add(record);
            }
        }

        return records.ToImmutableList();
    }
}