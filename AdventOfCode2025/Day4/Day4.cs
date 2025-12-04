using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day4;

public static class Day4
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = File.ReadAllLines($"Day4\\{fileName}");
        var map = MapService.GetMap(input);

        var solution = Part1.Solve(map);
        Console.WriteLine($"Day4 Part1 Solution: {solution}");

        solution = Part2.Solve(map);
        Console.WriteLine($"Day4 Part2 Solution: {solution}");
    }
}
