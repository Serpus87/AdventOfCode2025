using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day7;

public static class Day7
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        //var input = InputReader.GetProblems(fileName);

        var solutionPart1 = Part1.Solve();

        // firstTry: 
        Console.WriteLine($"Day6 Part1 Solution: {solutionPart1}");

        // firstTry:
        var solutionPart2 = Part2.Solve();

        // firstTry: 
        Console.WriteLine($"Day6 Part2 Solution: {solutionPart2}");
    }
}
