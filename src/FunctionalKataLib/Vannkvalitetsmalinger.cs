using static FunctionalKataLib.Vannkvalitet;
using static FunctionalKataLib.Vanntype;

namespace FunctionalKataLib;

public enum Vanntype
{
    Ferskvann,
    Saltvann
}
public enum Vannkvalitet
{
    Utmerket,
    Tilstrekkelig,
    God,
    Dårlig
}

// ReSharper disable once NotAccessedPositionalProperty.Global
public record Vannkvalitetsmåling(string Sted, Vanntype Vanntype, Vannkvalitet Kvalitet);


public static class Vannkvalitetsmålinger
{
    
    public static readonly Vannkvalitetsmåling[] Trondheim =
    [
        new("Baklidammen", Ferskvann, Utmerket),
        new("Brøttem", Ferskvann, Utmerket),
        new("Estendstaddammen", Ferskvann, Utmerket),
        new("Haukvatnet", Ferskvann, Utmerket),
        new("Hestsjøen", Ferskvann, Utmerket),
        new("Kyvatnet", Ferskvann, Utmerket),
        new("Lianvatnet", Ferskvann, Utmerket),
        new("Theisendammen", Ferskvann, Utmerket),
        new("Tømmerholtdammen", Ferskvann, Utmerket),
        new("Brennebukta", Saltvann, Utmerket),
        new("Devlebukta", Saltvann, Utmerket),
        new("Djupvika", Saltvann, Utmerket),
        new("Flakk", Saltvann, Utmerket),
        new("Grillstadfjæra v/ indre brygge", Saltvann, Utmerket),
        new("Havnsbakkfjæra", Saltvann, Utmerket),
        new("Korsvika", Saltvann, Utmerket),
        new("Leangenbukta", Saltvann, God),
        new("Munkholmen vest", Saltvann, Utmerket),
        new("Munkholmen øst", Saltvann, Utmerket),
        new("Ringvebukta", Saltvann, Tilstrekkelig),
        new("Strandveikaia (Nyhavna)", Saltvann, Dårlig),
        new("St. Olav pir", Saltvann, Utmerket),
        new("Tømmerstranda", Saltvann, Tilstrekkelig),
        new("Væreholmen", Saltvann, Utmerket)
    ];

}