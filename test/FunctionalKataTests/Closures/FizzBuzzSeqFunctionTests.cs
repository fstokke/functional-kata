using FunctionalKata.Closures;

namespace FunctionalKataTests.Closures;

public class FizzBuzzSeqFunctionTests
{
    [Fact]
    void ReturnsFizzBuzzSequenced()
    {
        var nextFunc = FizzBuzzSeqFunction.NextFunc();
        var fibonacciSequence = string.Join(", ", 
            Enumerable.Range(1, 31)
                .Select(_ => nextFunc()));
        Assert.Equal("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz, " +
                     "16, 17, Fizz, 19, Buzz, Fizz, 22, 23, Fizz, Buzz, 26, Fizz, 28, 29, FizzBuzz, 31", fibonacciSequence);
    }
}