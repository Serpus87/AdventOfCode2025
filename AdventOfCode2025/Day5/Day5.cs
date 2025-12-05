using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5;

public static class Day5
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = InputReader.GetInput(fileName);

        var solutionPart1 = Part1.Solve(input);

        // firstTry: 739 - correct
        Console.WriteLine($"Day5 Part1 Solution: {solutionPart1}");

        var solutionPart2 = Part2.Solve(input);

        // firstTry: 29059536185748 - too low
        // secondTry: 428252945940221 - too high
        // thirdTry: 344486348901788 - correct!
        Console.WriteLine($"Day5 Part2 Solution: {solutionPart2}");
    }
}
