using System.Collections.Immutable;

namespace FunctionalKata.Reduce;

public static class Reducer
{
    public static int Sum(IEnumerable<int> xs)
    {
        var list = xs.ToImmutableList();
        return !list.IsEmpty ? list.First() + Sum(list.Skip(1)) : 0;
    }

    public static string FindLongestWord(IEnumerable<string> xs)
    {
        var input = xs.ToImmutableList();

        return FindLongestWordTailRec("", input);
    }

    private static string FindLongestWordTailRec(string longest, ImmutableList<string> words)
    {
        if (words.IsEmpty)
        {
            return longest;
        }
        var (head, tail) = (words.First(), words.RemoveAt(0));
        return FindLongestWordTailRec(head.Length > longest.Length ? head : longest, tail);
    }

    public static T Reduce<T>(IEnumerable<T> xs, Func<T, T, T> f)
    {
        var input = xs.ToImmutableList();
        if (input.IsEmpty)
        {
            throw new ArgumentException("Input cannot be empty");
        }
        
        var accum = input.First();

        return ReduceTailRec(accum, input.RemoveAt(0), f);
    }
    
    private static T ReduceTailRec<T>(T accum, ImmutableList<T> xs, Func<T, T, T> f) =>
        !xs.IsEmpty
            ? ReduceTailRec(f(accum, xs.First()), xs.RemoveAt(0), f)
            : accum;
    
}