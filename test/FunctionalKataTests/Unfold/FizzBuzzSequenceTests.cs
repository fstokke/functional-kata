using FunctionalKata.Unfold;

namespace FunctionalKataTests.Unfold;

public class FizzBuzzSequenceTests
{
    [Fact]
    void ReturnsFizzBuzzSequenced()
    {
        var fibonacciSequence = string.Join(", ", FizzBuzzSequence.New().Take(31));
        Assert.Equal("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz, " +
                     "16, 17, Fizz, 19, Buzz, Fizz, 22, 23, Fizz, Buzz, 26, Fizz, 28, 29, FizzBuzz, 31", fibonacciSequence);
    }
}