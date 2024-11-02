using System.Globalization;

namespace FunctionalKataLib;

public record CoffeePrice(DateOnly Date, decimal Price)
{
    public override string ToString() => $"{Date:yyyy-MM-dd}: {Price.ToString("N2", CultureInfo.InvariantCulture)}";
}