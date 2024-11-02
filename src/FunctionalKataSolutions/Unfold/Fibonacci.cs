using FunctionalKataLib;

namespace FunctionalKata.Unfold;

public static class Fibonacci
{
    public static IEnumerable<string> Squares() => 
        Seq.Unfold<int, string>(1, x => ($"{x}*{x} = {x*x}", x+1));

    public static IEnumerable<int> CountDown(int n) => 
        Seq.Unfold<int, int>(n, x => x >= 0 ? (x, x - 1) : null);

    public static IEnumerable<int> Sequence()
    {
        return Seq.Unfold<(int, int), int>((0, 1), tuple =>
        {
            var (vCurr, vNext) = tuple;
            return (vCurr, (vNext, vCurr + vNext));
        });
    }
}