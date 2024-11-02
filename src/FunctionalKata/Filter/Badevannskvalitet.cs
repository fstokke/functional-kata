using FunctionalKataLib;

namespace FunctionalKata.Filter;

public class Badevannskvalitet
{
    
    public static List<string> HvorBørJegIkkeBadeITrondheim()
    {
        var result = new List<string>();
        foreach (var måling in Vannkvalitetsmålinger.Trondheim)
        {
            if (måling.Kvalitet == Vannkvalitet.Dårlig)
            {
                result.Add(måling.Sted);
            }
        }

        return result;
    }
}