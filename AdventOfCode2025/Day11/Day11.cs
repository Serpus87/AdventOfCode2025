using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day11;

public static class Day11
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var devices = InputReader.GetDevices(fileName);

        var solutionPart1 = Part1.Solve(devices);

        // firstTry: 431 -- correct!
        Console.WriteLine($"Day11 Part1 Solution: {solutionPart1}");

        var solutionPart2 = Part2.Solve(devices); 

        // firstTry:
        Console.WriteLine($"Day11 Part2 Solution: {solutionPart2}");
    }
}
