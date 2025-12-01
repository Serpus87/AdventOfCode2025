using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day1;

public static class Day1
{
    public static void Solve()
    {
        var inputFileName = "PuzzleInput.txt";
        var rotationInstructions = InputReader.GetRotationInstructions(inputFileName);

        var dial = new Dial();

        var dialPositionZeroCounter = 0u;

        foreach (var rotationInstruction in rotationInstructions)
        {
            dial.Rotate(rotationInstruction);

            if (dial.Position == 0)
            {
                dialPositionZeroCounter++;
            }
        }

        Console.WriteLine($"Day1 Part1 Solution: {dialPositionZeroCounter}");

        // previous try: 5861
        // previous try: 5674 -- That's not the right answer; your answer is too low.
        // 5872 -- correct
        Console.WriteLine($"Day1 Part2 Solution: {dial.ZeroCounter}"); 
    }
}
