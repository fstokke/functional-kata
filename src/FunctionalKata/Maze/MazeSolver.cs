using System.Collections.Immutable;
using FunctionalKataLib;

namespace FunctionalKata.Maze;

using Maze = ImmutableList<string>;
using Path = ImmutableList<Pos>;

public record Dim(int Length, int Height);

public static class MazeSolver
{
    // Finds all possible paths from start to goal in maze
    public static ImmutableList<Path> FindAllPaths(Maze maze)
    {
        var startPos = FindStartPos(maze);
        var dim = maze.Dim();
        var path = new List<Pos> {startPos};

        return FindAllPathsRecursive(maze, dim, path)
            .OrderBy(p => p.Count)
            .ThenBy(p => string.Join("|", p.Select(pos => $"{pos.X:D3}-{pos.Y:D3}")))
            .ToImmutableList();
    }

    // Searches the maze to find the coordinates for the start position (>) and the end position (*)
    private static Pos FindStartPos(this Maze maze)
    {
        Pos? startPos = null;
        for (var y = 0; y < maze.Count; y++)
        {
            var mazeLine = maze[y];
            for (var x = 0; x < mazeLine.Length; x++)
            {
                var c = mazeLine[x];
                switch (c)
                {
                    case '>':
                        startPos = new Pos(x, y);
                        break;
                }
            }
        }

        if (startPos == null) throw new Exception("Char '>' not found in maze");
        return startPos;
    }

    // Note: Mutable list as input parameter. Replace it with the immutable "Path" type
    private static IEnumerable<Path> FindAllPathsRecursive(Maze maze, Dim dim, List<Pos> path)
    {
        var currentPos = path.Last();
        var result = new List<Path>();
        
        if (maze.IsTargetPos(currentPos))
        {
            result.Add(path.ToImmutableList());
            return result.ToImmutableList();
        }
        
        var neighbours = AdjacentPositions(dim, currentPos);
        foreach (var neighbour in neighbours)
        {
            if (maze.IsFreePos(neighbour) && !path.Contains(neighbour))
            {
                var newPath = new List<Pos>(path) {neighbour};
                result.AddRange(FindAllPathsRecursive(maze, dim, newPath));
            }
        }

        return result;
    }

    // Find all adjacent positions within maze bounds
    private static ImmutableList<Pos> AdjacentPositions(Dim dim, Pos pos)
    {
        var adjacentCoords = new List<Pos>();
        AddIfWithinBounds(adjacentCoords, dim, pos.X - 1, pos.Y);
        AddIfWithinBounds(adjacentCoords, dim, pos.X + 1, pos.Y);
        AddIfWithinBounds(adjacentCoords, dim, pos.X, pos.Y - 1);
        AddIfWithinBounds(adjacentCoords, dim, pos.X,  pos.Y + 1);

        return adjacentCoords.ToImmutableList();
    }

    private static void AddIfWithinBounds(List<Pos> adjacentCoords, Dim dim, int x, int y)
    {
        if (IsWithinBounds(dim, x, y))
        {
            adjacentCoords.Add(new Pos(x, y));
        }
    }

    private static bool IsWithinBounds(Dim dim, int x, int y) =>
        x >= 0 && x < dim.Length && y >= 0 && y < dim.Height;
    
    private static Dim Dim(this Maze maze) => new(maze[0].Length, maze.Count);

    private static bool IsFreePos(this Maze maze, Pos pos) => maze.CharAt(pos) is '.' or '>' or '*';
    
    private static bool IsTargetPos(this Maze maze, Pos pos) => maze.CharAt(pos) is '*';

    private static char CharAt(this Maze maze, Pos pos) => maze[pos.Y][pos.X];
    
    
}