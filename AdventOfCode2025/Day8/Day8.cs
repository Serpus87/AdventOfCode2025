using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day8;

public static class Day8
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = File.ReadAllLines($"Day8\\{fileName}");
        var junctionBoxes = BoxService.GetJunctionBoxes(input);

        var solutionPart1 = Part1.Solve(junctionBoxes);

        // firstTry:  
        Console.WriteLine($"Day8 Part1 Solution: {solutionPart1}");

        junctionBoxes = BoxService.GetJunctionBoxes(input);
        var solutionPart2 = Part2.Solve(junctionBoxes);

        // firstTry: 
        Console.WriteLine($"Day8 Part2 Solution: {solutionPart2}");
    }
}
