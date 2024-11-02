using FunctionalKataLib;

namespace FunctionalKata.Unfold;

public static class FizzBuzzSequence
{
    public static IEnumerable<string> New()
    {
        string FizzBuzzValue(int i)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                return "FizzBuzz";
            }
            if (i % 3 == 0)
            {
                return "Fizz";
            }
            if (i % 5 == 0)
            {
                return "Buzz";
            }
            
            return i.ToString();
        }

        return Seq.Unfold<int, string>(1, i => (FizzBuzzValue(i), i + 1));
    }
}