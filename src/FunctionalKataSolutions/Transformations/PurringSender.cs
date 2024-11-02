using System.Collections.Immutable;
using FunctionalKataLib;

namespace FunctionalKata.Transformations;

using Lånerregister = ImmutableDictionary<string, Låner>;
using Utlånsregister = ImmutableDictionary<string, ImmutableList<Utlån>>;

// Demonstrerer hvordan en dypt nøsten funksjon kan flates ut i operasjoner som gjøres i sekvens
// Limit mutability 
public static class UtlånsregisterExtensions
{
    public static IEnumerable<(string Lånenummer, IEnumerable<Utlån> Forfall)> FinnForfalteUtlån(this Utlånsregister utlånsregister, DateOnly dagensDato) =>
        utlånsregister
            .Select(pair => (Lånenummer: pair.Key,
                Forfall: pair.Value
                    .Where(utlån => dagensDato > utlån.Lånefrist.AddDays(7))
                    .OrderBy(utlån => utlån.Lånemateriale)
                    .AsEnumerable()
                ))
            .Where(tuple => tuple.Forfall.Any())
            .OrderBy(tuple => tuple.Lånenummer)
        ;
}

public class PurringSender(IEpostSender epostSender)
{
    public void SendPurringer(Lånerregister lånerregister, Utlånsregister utlånsregister, DateOnly dagensDato)
    {
        var purremeldinger = utlånsregister 
            .FinnForfalteUtlån(dagensDato)
            .Select(tuple => LagPurreMelding(lånerregister[tuple.Lånenummer], tuple.Forfall));

        foreach (var purremelding in purremeldinger)
        {
            epostSender.SendEpost(purremelding.Epost, purremelding.Tittel, purremelding.Melding);
        }
    }

    private static (string Epost, string Tittel, string Melding) LagPurreMelding(Låner låner,
        IEnumerable<Utlån> utlånSomHarForfalt)
    {
        const string tittel = "Vennlig påminnelse: Varsel om manglende innlevering";
        var tekst = 
            "Dette er en annen påminnelse om at følgende lånemateriell ikke er blitt returnert, og lånet har nå forfalt med en uke eller mer:" 
            + Environment.NewLine
            + string.Join(Environment.NewLine, utlånSomHarForfalt.Select(utlån => "   " + utlån.Lånemateriale))
            + Environment.NewLine
            + "Purregebyr på 40 kroner betales på Mine Sider."
            + Environment.NewLine;

        return (låner.Epost, tittel, tekst);
    }
}