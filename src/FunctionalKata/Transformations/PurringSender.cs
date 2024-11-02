using System.Collections.Immutable;
using System.Text;
using FunctionalKataLib;

namespace FunctionalKata.Transformations;

using Lånerregister = ImmutableDictionary<string, Låner>;
using Utlånsregister = ImmutableDictionary<string, ImmutableList<Utlån>>;

public class PurringSender
{
    private readonly IEpostSender _epostSender;

    public PurringSender(IEpostSender epostSender)
    {
        _epostSender = epostSender;
    }

    public void SendPurringer(Lånerregister lånerregister, Utlånsregister utlånsregister, DateOnly dagensDato)
    {
        foreach (var (lånenummer, utlånsregistreringer) in utlånsregister.OrderBy(pair => pair.Key))
        {
            var låner = lånerregister[lånenummer];
            SendPurringerForLåner(låner, utlånsregistreringer, dagensDato);
        }
    }

    private void SendPurringerForLåner(Låner låner, ImmutableList<Utlån> utlånsregistreringer, DateOnly dagensDato)
    {
        var purringer = new List<Utlån>();
        foreach (var utlån in utlånsregistreringer.OrderBy(utlån => utlån.Lånemateriale))
        {
            if (dagensDato.AddDays(-7) > utlån.Lånefrist)
            {
                purringer.Add(utlån);
            }
        }

        if (purringer.Count > 0)
        {
            SendPurring(låner, purringer);
        }
        
    }

    private void SendPurring(Låner låner, List<Utlån> utlånSomHarForfalt)
    {
        var tittel = "Vennlig påminnelse: Varsel om manglende innlevering";
        var tekst = new StringBuilder(
            "Dette er en annen påminnelse om at følgende lånemateriell ikke er blitt returnert, og lånet har nå forfalt med en uke eller mer:");
        tekst.AppendLine();
        foreach (var utlån in utlånSomHarForfalt)
        {
            tekst.AppendLine("   " + utlån.Lånemateriale);
        }
        tekst.AppendLine(
            "Purregebyr på 40 kroner betales på Mine Sider.");

        
        _epostSender.SendEpost(låner.Epost, tittel, tekst.ToString());
    }
}