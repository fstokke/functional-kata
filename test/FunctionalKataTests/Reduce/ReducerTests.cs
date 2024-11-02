using FunctionalKata.Reduce;

namespace FunctionalKataTests.Reduce;

public class ReducerTests
{
    [Theory]
    [InlineData(new[] {1, 3, 7, 9}, 20)]
    [InlineData(new[] {3}, 3)]
    [InlineData(new int[0], 0)]
    public void SumReturnsSumOfInputSequence(IEnumerable<int> input, int expectedSum)
    {
        var sum = Reducer.Sum(input);
        Assert.Equal(expectedSum, sum);
    }
    
    
    [Theory]
    [InlineData(new[] {""}, "")]
    [InlineData(new[] {"This", "is", "an", "array", "of", "word"}, "array")]
    [InlineData(new[] {"The", "first", "long", "word", "is"}, "first")]
    public void FindLongestWordReturnsLongestWord(IEnumerable<string> words, string expectedResult)
    {
        var longest = Reducer.FindLongestWord(words);
        Assert.Equal(expectedResult, longest);
    }
    
    [Theory]
    [InlineData(new[] {1, 3, 7, 9}, 20)]
    [InlineData(new[] {3}, 3)]
    public void ReduceCanCalculateSum(IEnumerable<int> input, int expectedResult)
    {
        var sum = Reducer.Reduce(input, (accum, x) => accum + x);
        Assert.Equal(expectedResult, sum);
    }
    
    [Theory]
    [InlineData(new[] {1, 3, 7, 9}, 189)]
    [InlineData(new[] {3}, 3)]
    public void ReduceCanCalculateProduct(IEnumerable<int> input, int expectedResult)
    {
        var sum = Reducer.Reduce(input, (accum, x) => accum * x);
        Assert.Equal(expectedResult, sum);
    }
    
    [Theory]
    [InlineData(new[] {"Ole", "Dole", "Doffen"}, "Ole, Dole, Doffen")]
    public void ReduceCanConcatenateStrings(IEnumerable<string> input, string expectedResult)
    {
        var sum = Reducer.Reduce(input, (accum, s) => accum + ", " + s);
        Assert.Equal(expectedResult, sum);
    }
    
}