namespace FunctionalKata.Unfold;

public static class Fibonacci
{
    public static IEnumerable<int> Sequence()
    {
        var currVal = 0;
        var nextVal = 1; 
        for (;;)
        {
            yield return currVal;
            var oldNext = nextVal;
            nextVal = currVal + nextVal;
            currVal = oldNext;
        }
        // ReSharper disable once IteratorNeverReturns
    }
}