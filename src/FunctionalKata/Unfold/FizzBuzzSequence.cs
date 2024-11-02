namespace FunctionalKata.Unfold;

public static class FizzBuzzSequence
{
    public static IEnumerable<string> New()
    {
        for (var i = 1;; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                yield return "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                yield return "Fizz";
            }
            else if (i % 5 == 0)
            {
                yield return "Buzz";
            }
            else
            {
                yield return i.ToString();
            }
        }
        // ReSharper disable once IteratorNeverReturns
    }
}