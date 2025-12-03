using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2025.Day3;

public static class Day3
{
    public static void Solve()
    {
        // readInput
        var fileName = "PuzzleInput.txt";
        var banks = InputReader.GetBanks(fileName);

        // create clean copies for each part OR just read file again?
        var banksPart1 = CreateCleanCopy(banks);
        var banksPart2 = CreateCleanCopy(banks);

        var solutionPart1 = Part1.Solve(banksPart1);

        // firstTry: 17694 - correct!
        Console.WriteLine($"Day3 Part1 Solution: {solutionPart1}");

        //banks = InputReader.GetBanks(fileName);
        var solutionPart2 = Part2.Solve(banksPart2);

        // firstTry: 151121023258417 - your answer is too low
        // firstTry: 175659236361660 - correct!
        Console.WriteLine($"Day3 Part2 Solution: {solutionPart2}");
    }

    private static List<Bank> CreateCleanCopy(List<Bank> originalBanks) // todo maybe move to extensions class
    {
        var cleanCopyOfBanks = new List<Bank>();

        foreach (var bank in originalBanks)
        {
            var cleanCopyOfBank = bank.CreateCleanCopy();
            cleanCopyOfBanks.Add(cleanCopyOfBank);
        }

        return cleanCopyOfBanks;
    }

    private static Bank CreateCleanCopy(this Bank originalBank)
    {
        var cleanCopyOfBank = new Bank(new List<uint>());

        foreach (var joltage in originalBank.Joltages)
        {
            cleanCopyOfBank.Joltages.Add(joltage);
        }

        return cleanCopyOfBank;
    }
}
