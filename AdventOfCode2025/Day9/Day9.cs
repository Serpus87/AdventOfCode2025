using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day9;

public static class Day9
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = File.ReadAllLines($"Day9\\{fileName}");
        var tiles = TileService.GetTiles(input);

        var solutionPart1 = Part1.Solve(tiles);

        // firstTry: 2147314224 -- too low
        // secondTry: 4754955192
        Console.WriteLine($"Day9 Part1 Solution: {solutionPart1}");

        tiles = TileService.GetTiles(input);
        var solutionPart2 = Part2.Solve(tiles);

        // firstTry: 
        Console.WriteLine($"Day9 Part2 Solution: {solutionPart2}");
    }
}
