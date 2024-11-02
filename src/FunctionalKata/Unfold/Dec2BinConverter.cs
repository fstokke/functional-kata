namespace FunctionalKata.Unfold;

public static class Dec2BinConverter
{
    public static string Convert(int value)
    {
        if (value == 0)
        {
            return "0";
        }
        
        var binValue = new List<char>();
        while (value > 0)
        {
            var v = (value & 0x01) > 0 ? '1' : '0';
            binValue.Add(v);
            value >>= 1;
        }

        binValue.Reverse();
        return new string(binValue.ToArray());
    }
}