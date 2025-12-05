using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5;

public static class Day5
{
    public static void Solve()
    {
        // read file
        var fileName = "PuzzleInput.txt";
        var input = InputReader.GetInput(fileName);

        // create clean copies ?
        var inputPart1 = new Input(input.IdPairs.CreateCleanCopy(), input.Ingredients.CreateCleanCopy());
        var inputPart2 = new Input(input.IdPairs.CreateCleanCopy(), input.Ingredients.CreateCleanCopy());

        var solutionPart1 = Part1.Solve(inputPart1);

        // firstTry: 739 - correct
        Console.WriteLine($"Day5 Part1 Solution: {solutionPart1}");

        var solutionPart2 = Part2.Solve(inputPart2);

        // firstTry: 29059536185748 - too low
        // secondTry: 428252945940221 - too high
        // thirdTry: 344486348901788 - correct!
        Console.WriteLine($"Day5 Part2 Solution: {solutionPart2}");
    }

    private static List<IdPair> CreateCleanCopy(this List<IdPair> idPairs) // todo maybe move to (shared) extensions class
    {
        var cleanCopy = new List<IdPair>();

        foreach (var idPair in idPairs)
        {
            cleanCopy.Add(new IdPair(idPair.Id1, idPair.Id2));
        }

        return cleanCopy;
    }

    private static List<ulong> CreateCleanCopy(this List<ulong> ingredients)
    {
        var cleanCopy = new List<ulong>();

        foreach (var ingredient in ingredients)
        {
            cleanCopy.Add(ingredient);
        }

        return cleanCopy;
    }
}
