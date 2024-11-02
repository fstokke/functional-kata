
using FunctionalKata.Filter;

namespace FunctionalKataTests.Filter;

public class BadevannskvalitetTests
{

    [Fact]
    public void HvorBørJegIkkeBadeITrondheimReturnererBadevannMedDårligVannkvalitet()
    {
        var result = string.Join(", ", Badevannskvalitet.HvorBørJegIkkeBadeITrondheim());
        Assert.Equal("Strandveikaia (Nyhavna)", result);
    }
}