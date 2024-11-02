namespace FunctionalKata.Reduce;

public static class Reducer
{
    public static int Sum(IEnumerable<int> xs)
    {
        var sum = 0;
        foreach (var x in xs)
        {
            sum += x;
        }
        return sum;
    }
    
    public static string FindLongestWord(IEnumerable<string> words)
    {
        var input = words.ToList();
        var longest = "";
        foreach (var word in input)
        {
            if (word.Length > longest.Length)
            {
                longest = word;
            }
        }
        return longest;
    }
    
    public static T Reduce<T>(IEnumerable<T> xs, Func<T, T, T> f)
    {
        var input = xs.ToArray();
        if (input.Length == 0)
        {
            throw new ArgumentException("Input cannot be empty");
        }

        var accum = input[0];
        for (var i = 1; i < input.Length; i++)
        {
            accum = f(accum, input[i]);
        }
        return accum;
    }
    
}