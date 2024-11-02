using System.Collections.Immutable;
using FunctionalKata.Transformations;
using FunctionalKataLib;
using Utlån = FunctionalKataLib.Utlån;

namespace FunctionalKataTests.Transformations;

public class PurringSenderTests
{
    [Fact]
    public void SenderPurringerForForfalteLån()
    {
        var epostSender = new MockEpostSender();
        var purringSender = new PurringSender(epostSender);
        purringSender.SendPurringer(TestData.LånerRegister, TestData.Utlånsregister, TestData.DagensDato);

        var messages = epostSender.Messages;
        var allMessages = string.Join(Environment.NewLine, messages);
        Assert.Equal(
            @"Message { Epost = per@epost.no, Title = Vennlig påminnelse: Varsel om manglende innlevering, Text = Dette er en annen påminnelse om at følgende lånemateriell ikke er blitt returnert, og lånet har nå forfalt med en uke eller mer:
   Carl Frode Tiller: Begynnelser
   Jo Nesbø: Snømannen
   Karl Ove Knausgård: Morgenstjernen
   Trude Marstein: Så mye hadde jeg
Purregebyr på 40 kroner betales på Mine Sider.
 }
Message { Epost = kari@epost.no, Title = Vennlig påminnelse: Varsel om manglende innlevering, Text = Dette er en annen påminnelse om at følgende lånemateriell ikke er blitt returnert, og lånet har nå forfalt med en uke eller mer:
   Erik Fosnes Hansen: Et hummerliv
Purregebyr på 40 kroner betales på Mine Sider.
 }", 
            allMessages);
    }

    private static class TestData
    {
        public static DateOnly DagensDato = new(2023, 08, 04);
        private static readonly Låner Per = new("1101", "Per", "per@epost.no");
        private static readonly Låner Kari = new("1102", "Kari", "kari@epost.no");
        private static readonly Låner Lisa = new("1103", "Lisa", "lisa@epost.no");

        public static readonly ImmutableDictionary<string, Låner> LånerRegister = new[]
        {
            Per, Kari, Lisa
        }.ToImmutableDictionary(låner => låner.Lånenummer);

        public static readonly ImmutableDictionary<string, ImmutableList<Utlån>> Utlånsregister =
            new Dictionary<string, ImmutableList<Utlån>>
            {
                {
                    Per.Lånenummer, ImmutableList.Create(new Utlån[]
                    {
                        new("Jo Nesbø: Snømannen", DagensDato.AddDays(-30)),
                        new("Per Petterson: Ut og stjele hester", DagensDato.AddDays(5)),
                        new("Tom Egeland: Den siste vikingkongen", DagensDato.AddDays(-5)),
                        new("Carl Frode Tiller: Begynnelser", DagensDato.AddDays(-8)),
                        new("Trude Marstein: Så mye hadde jeg", DagensDato.AddDays(-14)),
                        new("Karl Ove Knausgård: Morgenstjernen", DagensDato.AddDays(-21)),
                    })
                },
                {
                    Kari.Lånenummer, ImmutableList.Create(new Utlån[]
                    {
                        new("Erik Fosnes Hansen: Et hummerliv", DagensDato.AddDays(-8)),
                        new("Jo Nesbø: Kongeriket", DagensDato.AddDays(5)),
                    })
                },
                {
                    Lisa.Lånenummer, ImmutableList.Create(new Utlån[]
                    {
                        new("Erlend Loe: Dyrene i Afrika", DagensDato.AddDays(2)),
                    })
                }
            }.ToImmutableDictionary();
    }
}