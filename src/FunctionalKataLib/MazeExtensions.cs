using System.Collections.Immutable;

namespace FunctionalKataLib;

using Maze = ImmutableList<string>;

public record Pos(int X, int Y)
{
    public override string ToString() => $"({X}, {Y})";
}

public static class MazeStringExtensions
{
    public static string TrimLines(this string str) =>
        string.Join(Environment.NewLine, SplitAndTrimLines(str));

    public static Maze ParseMaze(this string str) => SplitAndTrimLines(str).ToImmutableList();

    private static IEnumerable<string> SplitAndTrimLines(this string str) =>
        str
            .Split('\n', '\r')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrEmpty(s));

    public static string SetCharAt(this string str, int idx, char c)
    {
        var charArray = str.ToCharArray();
        charArray[idx] = c;
        return new string(charArray);
    }
}

public static class MazeExtensions
{
    private static string PrintMaze(this Maze maze) => string.Join(Environment.NewLine, maze);

    public static string PrintMazePath(this Maze maze, ImmutableList<Pos> path) =>
        path
            .Aggregate(maze.Select(line => line.Replace('.', ' ')).ToImmutableList(),
                (maze1, pos) =>
                    maze1.SetItem(pos.Y, maze1[pos.Y].SetCharAt(pos.X, '.'))).PrintMaze();
}