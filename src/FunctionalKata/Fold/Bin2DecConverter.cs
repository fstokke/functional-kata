namespace FunctionalKata.Fold;

public static class Bin2DecConverter
{
    public static int Convert(string binaryValue)
    {
        int value = 0;
        var chars = binaryValue.ToCharArray();
        foreach (var c in chars)
        {
            value = (value << 1) | int.Parse(c.ToString());
        }

        return value;
    }
}