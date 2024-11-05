using System.Globalization;
using FunctionalKataLib;

namespace FunctionalKata.Map;

public record Coord(int X, int Y)
{
    public override string ToString() => 
        $"({X.ToString(CultureInfo.InvariantCulture)}, {Y.ToString(CultureInfo.InvariantCulture)})";
}

public class Grid
{
    private readonly int _minX;
    private readonly int _minY;
    private readonly int _maxX;
    private readonly int _maxY;

    private IPrinter<Coord>? _printer;

    public Grid(int minX, int minY, int maxX, int maxY)
    {
        _minX = minX;
        _minY = minY;
        _maxX = maxX;
        _maxY = maxY;
    }   

    public void PrintAdjacentCoords(IPrinter<Coord> printer, int x, int y)
    {
        _printer = printer; // Remember? Don't do this! Better to pass printer as parameter to PrintIfWithinBounds
        PrintIfWithinBounds(x - 1, y - 1);
        PrintIfWithinBounds(x, y - 1);
        PrintIfWithinBounds(x + 1, y - 1);
        PrintIfWithinBounds(x - 1, y);
        PrintIfWithinBounds(x + 1, y);
        PrintIfWithinBounds(x - 1, y + 1);
        PrintIfWithinBounds(x, y + 1);
        PrintIfWithinBounds(x + 1, y + 1);
    }

    private void PrintIfWithinBounds(int x, int y)
    {
        if (IsWithinBounds(x, y))
        {
            _printer!.PrintObject(new Coord(x,y));
        }
    }
    
    private bool IsWithinBounds(int x, int y) => (x >= _minX && x <= _maxX) && (y >= _minY && y <= _maxY);
    
}

