using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day3;

public static class Part1
{
    public static uint Solve(List<Bank> banks)
    {
        var totalOutputJoltage = 0u;

        foreach (var bank in banks)
        {
            // find highest Joltages
            var highestJoltage = bank.Joltages.Max();
            var secondHighestJoltage = 0u;

            // find first occurence of highest Joltage
            var firstOccurrence = bank.Joltages.IndexOf(highestJoltage);

            // if firstOccurence is also the last, then it is the secondHighestJoltage
            if (firstOccurrence == (bank.Joltages.Count - 1))
            {
                secondHighestJoltage = highestJoltage;

                bank.Joltages.RemoveAt(firstOccurrence);
                highestJoltage = bank.Joltages.Max();

                totalOutputJoltage += uint.Parse(highestJoltage.ToString() + secondHighestJoltage.ToString());
                continue;
            }

            bank.Joltages.RemoveRange(0, firstOccurrence + 1);
            secondHighestJoltage = bank.Joltages.Max();

            totalOutputJoltage += uint.Parse(highestJoltage.ToString() + secondHighestJoltage.ToString());
        }

        return totalOutputJoltage;
    }
}
