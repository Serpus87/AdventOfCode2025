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
        var input = File.ReadAllLines($"Day7\\{fileName}");
        var map = MapService.GetMap(input);

        var solutionPart1 = Part1.Solve(map);

        // firstTry:  1633 - correct!
        Console.WriteLine($"Day7 Part1 Solution: {solutionPart1}");

        map = MapService.GetMap(input);
        var solutionPart2 = Part2.Solve(map);

        // firstTry: 939602039 - too low
        // secondTry: 34339203133559
        Console.WriteLine($"Day7 Part2 Solution: {solutionPart2}");
    }
}
