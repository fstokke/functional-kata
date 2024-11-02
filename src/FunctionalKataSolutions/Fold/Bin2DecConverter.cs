namespace FunctionalKata.Fold;

public static class Bin2DecConverter
{
    public static int Convert(string binaryValue) =>
        binaryValue.Aggregate(0, (value, c) => (value << 1) | int.Parse(c.ToString()));
    
}