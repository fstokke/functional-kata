using FunctionalKataLib;

namespace FunctionalKata.Filter;

public static class Badevannskvalitet
{

    public static IEnumerable<string> HvorBørJegIkkeBadeITrondheim() =>
        Vannkvalitetsmålinger.Trondheim
            .Where(måling => måling is { Kvalitet: Vannkvalitet.Dårlig })
            .Select(måling => måling.Sted);

}