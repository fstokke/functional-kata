namespace FunctionalKata.Closures;

public static class FizzBuzzSeqFunction
{
    private class FizzBuzzFunction
    {
        // ReSharper disable once RedundantDefaultMemberInitializer
        private int _i = 0;
        public string Next()
        {
            ++_i;
            if (_i % 3 == 0 && _i % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (_i % 3 == 0)
            {
                return "Fizz";
            }
            else if (_i % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return _i.ToString();
            }
        }
    }
    
    public static Func<string> NextFunc()
    {
        var f = new FizzBuzzFunction();
        return f.Next;
    } 
}