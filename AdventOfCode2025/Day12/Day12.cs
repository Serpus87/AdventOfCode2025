using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public static class Day12
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = InputReader.GetTreesAndPresents(fileName);

        var solutionPart1 = Part1.Solve(input.Trees, input.Presents);

        // firstTry: 
        Console.WriteLine($"Day11 Part1 Solution: {solutionPart1}");

        input = InputReader.GetTreesAndPresents(fileName);
        var solutionPart2 = Part2.Solve(input.Trees, input.Presents); 

        // firstTry:
        Console.WriteLine($"Day11 Part2 Solution: {solutionPart2}");
    }
}
