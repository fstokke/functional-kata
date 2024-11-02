using FunctionalKataLib;

namespace FunctionalKata.Unfold;

public static class Dec2BinConverter
{
    public static string Convert(int? value)
    {
        return new string(Seq.Unfold(value, NextVal).Reverse().ToArray());

        (char, int?)? NextVal(int? currVal)
        {
            if (currVal == null)
            {
                return null;
            }

            var binDigit = (currVal & 0x01) > 0 ? '1' : '0';
            var nextVal = currVal >> 1;
            return nextVal == 0
                ? (binDigit, null)
                : (binDigit, nextVal);
        }
    }
    
}