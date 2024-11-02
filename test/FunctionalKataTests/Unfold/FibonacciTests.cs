using FunctionalKata.Unfold;

namespace FunctionalKataTests.Unfold;

public class FibonacciTests
{
    [Fact]
    void ReturnsFirstFewNumbersOfFibonacciSequence()
    {
        var fibonacciSequence = string.Join(", ", Fibonacci.Sequence().Take(10));
        Assert.Equal("0, 1, 1, 2, 3, 5, 8, 13, 21, 34", fibonacciSequence);
    }
}