using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2025.Day2;

public static class Day2
{
    public static void Solve()
    {
        // readInput
        var fileName = "PuzzleInput.txt";
        var idPairs = InputReader.GetIdPairs(fileName);

        var solutionPart1 = Part1.Solve(idPairs);

        // firstTry: 28844599675 - correct!
        Console.WriteLine($"Day2 Part1 Solution: {solutionPart1}");

        var solutionPart2 = Part2.Solve(idPairs);

        // firstTre: 48778605167 - correct!
        Console.WriteLine($"Day2 Part2 Solution: {solutionPart2}");
    }
}
