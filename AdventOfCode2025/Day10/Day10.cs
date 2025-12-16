using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day10;

public static class Day10
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = File.ReadAllLines($"Day10\\{fileName}");
        var machines = InputReader.GetMachines(input);

        //Console.WriteLine(machines.Max(x=>x.IndicatorLightDiagram.Count));

        var solutionPart1 = Part1.Solve(machines);

        // firstTry: 268 -- too low
        Console.WriteLine($"Day9 Part1 Solution: {solutionPart1}");

        var solutionPart2 = Part2.Solve(machines);

        // firstTry:
        Console.WriteLine($"Day9 Part2 Solution: {solutionPart2}");
    }
}
