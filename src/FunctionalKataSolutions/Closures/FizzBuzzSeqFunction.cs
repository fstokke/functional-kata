namespace FunctionalKata.Closures;

public static class FizzBuzzSeqFunction
{
    public static Func<string> NextFunc()
    {
        var i = 0;
        return () =>
        {
            ++i;
            return (i % 3 == 0, i % 5 == 0) switch
            {
                (true, true) => "FizzBuzz",
                (true, false) => "Fizz",
                (false, true) => "Buzz",
                _ => i.ToString()
            };
        };
    } 
}