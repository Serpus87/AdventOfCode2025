using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2025.Day3;

public static class Day3
{
    public static void Solve()
    {
        // readInput
        var fileName = "PuzzleInput.txt";
        var banks = InputReader.GetBanks(fileName);

        var solutionPart1 = Part1.Solve(banks);

        // firstTry: 17694 - correct!
        Console.WriteLine($"Day3 Part1 Solution: {solutionPart1}");

        var solutionPart2 = Part2.Solve(banks);

        // firstTry: 
        Console.WriteLine($"Day3 Part2 Solution: {solutionPart2}");
    }
}
