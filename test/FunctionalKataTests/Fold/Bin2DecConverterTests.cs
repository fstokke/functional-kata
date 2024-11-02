using FunctionalKata.Fold;

namespace FunctionalKataTests.Fold;

public class Bin2DecConverterTests
{
    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("1010", 10)]
    [InlineData("11011100111001", 14137)]
    public void CanConvertFromBinaryToDecimal(string binaryValue, int expectedValue)
    {
        var value = Bin2DecConverter.Convert(binaryValue);
        Assert.Equal(expectedValue, value);
    }
}