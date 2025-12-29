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
        //var input = File.ReadAllLines($"Day10\\{fileName}");
        //var machines = InputReader.GetMachines(input);

        //Console.WriteLine(machines.Max(x=>x.IndicatorLightDiagram.Count));

        var solutionPart1 = Part1.Solve();

        // firstTry: 268 -- too low
        // secondTry: 527 -- correct!
        Console.WriteLine($"Day11 Part1 Solution: {solutionPart1}");

        //machines = InputReader.GetMachines(input);
        var solutionPart2 = Part2.Solve(); 

        // firstTry:
        Console.WriteLine($"Day11 Part2 Solution: {solutionPart2}");
    }
}
