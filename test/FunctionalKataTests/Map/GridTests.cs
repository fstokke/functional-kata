using FunctionalKata.Map;
using FunctionalKataLib;

namespace FunctionalKataTests.Map;

public class GridTests
{
    [Theory]
    [InlineData(-10, -10, "")]
    [InlineData(-2, -3, "(-1, -2)")]
    [InlineData(3, -3, "(2, -2), (3, -2), (4, -2)")]
    [InlineData(-1, -2, "(0, -2), (-1, -1), (0, -1)")]
    [InlineData(0, 0, "(-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1)")]
    [InlineData(8, 7, "(7, 6), (8, 6), (7, 7)")]
    [InlineData(9, 5, "(8, 4), (8, 5), (8, 6)")]
    [InlineData(10, 10, "")]
    public void CanReturnAdjacentCoords(int x, int y, string expectedAdjacentCoords)
    {
        var grid = new Grid(-1, -2, 8, 7);
        var printer = new MockPrinter<Coord>();
        grid.PrintAdjacentCoords(printer, x, y);
        var adjacentCoords = string.Join(", ",
            printer.Objects
                .OrderBy(coord => coord.Y)
                .ThenBy(coord => coord.X));
        Assert.Equal(expectedAdjacentCoords, adjacentCoords);
    }
}