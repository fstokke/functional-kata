using System.Collections.Immutable;
using FunctionalKataLib;

namespace FunctionalKata.Maze;

using Maze = ImmutableList<string>;
using Path = ImmutableList<Pos>;

public record Dim(int Length, int Height);

public static class MazeSolver
{
    public static ImmutableList<Path> FindAllPaths(Maze maze)
    {
        var startPos = FindStartPos(maze);
        var dim = maze.Dim();
        var path = ImmutableList.Create(startPos);

        return FindAllPathsRecursive(maze, dim, path)
            .OrderBy(p => p.Count)
            .ThenBy(p => string.Join("|", p.Select(pos => $"{pos.X:D3}-{pos.Y:D3}")))
            .ToImmutableList();
    }

    private static Pos FindStartPos(Maze maze) => 
        maze.SelectMany((mazeLine, y) => mazeLine.Select((ch, x) => new {Pos = new Pos(x, y), C = ch}))
            .FirstOrDefault(charAtPos => charAtPos.C == '>')?.Pos ?? throw new Exception($"Char '>' not found in maze");
        

    private static IEnumerable<Path> FindAllPathsRecursive(Maze maze, Dim dim, Path path) =>
        AdjacentPositions(dim, path.Last())
            .Where(neighbour => IsFreePos(maze, neighbour) && !path.Contains(neighbour))
            .SelectMany(neighbour =>
                maze.IsTargetPos(neighbour)
                    ? ImmutableList.Create(path.Add(neighbour))
                    : FindAllPathsRecursive(maze, dim, path.Add(neighbour)));

    private static ImmutableList<Pos> AdjacentPositions(Dim dim, Pos pos)
        => new Pos[] {new(pos.X - 1, pos.Y), new(pos.X + 1, pos.Y), new(pos.X, pos.Y - 1), new(pos.X, pos.Y + 1)}
            .Where(p => IsWithinBounds(dim, p.X, p.Y))
            .ToImmutableList();

    private static bool IsWithinBounds(Dim dim, int x, int y) =>
        x >= 0 && x < dim.Length && y >= 0 && y < dim.Height;
    
    private static Dim Dim(this Maze maze) => new(maze[0].Length, maze.Count);
    
    private static bool IsFreePos(this Maze maze, Pos pos) => maze.CharAt(pos) is '.' or '>' or '*';
    
    private static bool IsTargetPos(this Maze maze, Pos pos) => maze.CharAt(pos) is '*';

    private static char CharAt(this Maze maze, Pos pos) => maze[pos.Y][pos.X];
}