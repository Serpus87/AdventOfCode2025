using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day6;

public static class Day6
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = InputReader.GetProblems(fileName);

        var solutionPart1 = Part1.Solve(input);

        // firstTry: 6169101504608 - correct!
        Console.WriteLine($"Day6 Part1 Solution: {solutionPart1}");

        var solutionPart2 = Part2.Solve(input);

        // firstTry: 
        Console.WriteLine($"Day6 Part2 Solution: {solutionPart2}");
    }
}
