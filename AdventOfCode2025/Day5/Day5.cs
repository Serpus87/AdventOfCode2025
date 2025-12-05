using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day5;

public static class Day5
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = InputReader.GetInput(fileName);
        
        var solution = Part1.Solve(input);

        // firstTry: 739 - correct
        Console.WriteLine($"Day5 Part1 Solution: {solution}");

        solution = Part2.Solve(input);

        // firstTry: 
        Console.WriteLine($"Day5 Part2 Solution: {solution}");
    }
}
