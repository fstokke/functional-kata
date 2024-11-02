namespace FunctionalKataLib;


public record Låner(string Lånenummer, string Navn, string Epost);

public record Utlån(string Lånemateriale, DateOnly Lånefrist);
