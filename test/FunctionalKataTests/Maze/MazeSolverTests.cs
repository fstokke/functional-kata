using FunctionalKata.Maze;
using FunctionalKataLib;

namespace FunctionalKataTests.Maze;

public class MazeSolverTests
{
    [Fact]
    public void FindsAllPathsToTargetInMiniMaze()
    {
        var maze = MazeExamples.MiniMaze;
        
        var paths = MazeSolver.FindAllPaths(maze);
        Assert.Equal(2, paths.Count);

        var mazePaths = string.Join(Environment.NewLine + "---" + Environment.NewLine, paths
            .Select(maze.PrintMazePath));
        Assert.Equal(@"
#####
..  #
#.# #
#....
#####
---
#####
....#
# #.#
#  ..
#####
".TrimLines(), mazePaths);
    }
    
    [Fact]
    public void FindsAllPathsToTargetInLittleMaze()
    {
        var maze = MazeExamples.LittleMaze;
        
        var paths = MazeSolver.FindAllPaths(maze);
        Assert.Equal(4, paths.Count);
        
        var mazePaths = string.Join(Environment.NewLine + "---" + Environment.NewLine, paths
            .Select(maze.PrintMazePath));
        Assert.Equal(@"
################
..###     ##   #
#.....# #    # #
#####.# # #### #
#.....# #   #  #
#.#### ### ## ##
#..#     # #   #
##.# ### # # ###
# ....#  #    ##
# ###.# ####  ##
#   #..... #   #
# #### ##.## ###
#   #  # ..#   #
### ## ###.#####
#       # ......
################
---
################
..###     ##   #
#.....# #    # #
#####.# # #### #
#.....# #   #  #
#.#### ### ## ##
#..#.....# #   #
##.#.###.# # ###
# ... #..#    ##
# ### #.####  ##
#   #  ... #   #
# #### ##.## ###
#   #  # ..#   #
### ## ###.#####
#       # ......
################
---
################
..###     ##   #
#.....# #    # #
#####.# # #### #
#.....# #   #  #
#.#### ### ## ##
#..#     # #   #
##.# ### # # ###
#..   #  #    ##
#.### # ####  ##
#.  # .... #   #
#.####.##.## ###
#...# .# ..#   #
###.##.###.#####
#  .... # ......
################
---
################
..###     ##   #
#.....# #    # #
#####.# # #### #
#.....# #   #  #
#.#### ### ## ##
#..#.....# #   #
##.#.###.# # ###
#.. ..#..#    ##
#.###.#.####  ##
#.  #..... #   #
#.####.##.## ###
#...# .# ..#   #
###.##.###.#####
#  .... # ......
################
".TrimLines(), mazePaths);
    }
}