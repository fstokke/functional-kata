using System.Collections.Immutable;
using FunctionalKata.CoffeePrices;
using FunctionalKataLib;

namespace FunctionalKataTests.CoffeePrices;

 
// ReSharper disable once ClassNeverInstantiated.Global
public class CsvParserFixture
{
    public ImmutableList<CoffeePrice> CoffeePrices { get; }

    public CsvParserFixture()
    {
        CoffeePrices = CsvParser.ReadCoffeePrices("./Resources/coffee_prices.csv");
    }
}

public class CsvParserTests : IClassFixture<CsvParserFixture>
{
    private readonly CsvParserFixture _fixture;

    public CsvParserTests(CsvParserFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public void ReadsCorrectNumberOfRows()
    {
        Assert.Equal(1258, _fixture.CoffeePrices.Count);
    }
    
    [Theory]
    [InlineData(0, "2018-08-03", 1.0775)]
    [InlineData(31, "2018-09-18", 0.9585)]
    [InlineData(1257, "2023-08-02", 1.6695)]
    public void DataIsCorrect(int index, string expectedDateOnly, decimal expectedPrice)
    {
        var priceRow = _fixture.CoffeePrices[index];
        Assert.Equal(expectedDateOnly, priceRow.Date.ToString("yyyy-MM-dd")); 
        Assert.Equal(expectedPrice, priceRow.Price);
    }
}