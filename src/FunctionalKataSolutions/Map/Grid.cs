using System.Collections.Immutable;
using System.Globalization;
using FunctionalKataLib;

namespace FunctionalKata.Map;

public record Coord(int X, int Y)
{
    public override string ToString() => 
        $"({X.ToString(CultureInfo.InvariantCulture)}, {Y.ToString(CultureInfo.InvariantCulture)})";
}

public class Grid(int minX, int minY, int maxX, int maxY)
{
    public void PrintAdjacentCoords(IPrinter<Coord> printer, int x, int y)
    {
        var adjacentCoords = FindAdjacentCoords(x, y);
        PrintCoords(printer, adjacentCoords);
    }

    private ImmutableList<Coord> FindAdjacentCoords(int x, int y) =>
        new[] {(-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1)}
            .Select(tuple => new Coord(x + tuple.Item1, y + tuple.Item2))
            .Where(coord => IsWithinBounds(coord.X, coord.Y))
            .ToImmutableList();
    
    // Alternative
    private ImmutableList<Coord> FindAdjacentCoords2(int x, int y) =>
        Enumerable.Range(-1, 3).SelectMany(dx
                => Enumerable.Range(-1, 3)
                    .Select(dy => (dx, dy)))
            .Where(dxdy => dxdy is not {dx: 0, dy: 0})
            .Select(dxdy => new Coord(x + dxdy.dx, y + dxdy.dy))
            .Where(coord => IsWithinBounds(coord.X, coord.Y))
            .ToImmutableList();

    private bool IsWithinBounds(int x, int y) => x >= minX && x <= maxX && y >= minY && y <= maxY;

    private static void PrintCoords(IPrinter<Coord> printer, ImmutableList<Coord> adjacentCoords)
    {
        foreach (var coord in adjacentCoords)
        {
            printer.PrintObject(coord);
        }
    }
}