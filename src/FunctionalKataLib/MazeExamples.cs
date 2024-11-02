using System.Collections.Immutable;

namespace FunctionalKataLib;

using Maze = ImmutableList<string>;

public static class MazeExamples
{
    public static readonly Maze MiniMaze = """
                                           #####
                                           >...#
                                           #.#.#
                                           #...*
                                           #####
                                           """.ParseMaze();


    public static readonly Maze LittleMaze = """
        ################
        >.###.....##...#
        #.....#.#....#.#
        #####.#.#.####.#
        #.....#.#...#..#
        #.####.###.##.##
        #..#.....#.#...#
        ##.#.###.#.#.###
        #.....#..#....##
        #.###.#.####..##
        #...#......#...#
        #.####.##.##.###
        #...#..#...#...#
        ###.##.###.#####
        #.......#......*
        ################
        """
        .ParseMaze();

  
}