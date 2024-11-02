namespace FunctionalKataLib;

public static class Seq
{
    public static IEnumerable<TSeq> Unfold<TState, TSeq>(TState seed, Func<TState, (TSeq, TState)?> generatorFunc)
    {
        var nextStateOrNull = generatorFunc(seed);
        while (nextStateOrNull != null) 
        {
            var (nextVal, nextState) = nextStateOrNull.Value;
            yield return nextVal;
            nextStateOrNull = generatorFunc(nextState);
        }
    }
}