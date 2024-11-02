using FunctionalKata.Unfold;

namespace FunctionalKataTests.Unfold;

public class Dec2BinConverterTests
{
    
    [Theory]
    [InlineData(0, "0")]
    [InlineData(1, "1")]
    [InlineData(10, "1010")]
    [InlineData(14137, "11011100111001")]
    public void CanConvertFromDecimalToBinary(int value, string expectedBinaryValue)
    {
        var binaryValue = Dec2BinConverter.Convert(value);
        Assert.Equal(expectedBinaryValue, binaryValue);
    }
}