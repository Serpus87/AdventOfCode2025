using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day3;

public static class Part2
{
    public static ulong Solve(List<Bank> banks)
    {
        var totalOutputJoltage = 0ul;

        //foreach (var bank in banks.Where(x=>x.Joltages.Count >= 12))
        foreach (var bank in banks)
        {
            var highestJoltages = new List<uint>();
            var joltagesToCheck = new List<uint>();
            joltagesToCheck.AddRange(bank.Joltages);

            while (highestJoltages.Count < 12)
            {
                var rangeToRemoveAndReAdd = bank.Joltages[(bank.Joltages.Count - (11 - highestJoltages.Count))..];
                joltagesToCheck.RemoveRange(joltagesToCheck.Count - (11 - highestJoltages.Count), 11 - highestJoltages.Count);

                var highestJoltage = joltagesToCheck.Max();
                var firstOccurrence = joltagesToCheck.IndexOf(highestJoltage);

                joltagesToCheck.AddRange(rangeToRemoveAndReAdd);

                if (joltagesToCheck.Count - 1 == (11 - highestJoltages.Count))
                {
                    highestJoltages.AddRange(joltagesToCheck);
                    break;
                }

                highestJoltages.Add(highestJoltage);

                joltagesToCheck.RemoveRange(0, firstOccurrence + 1);
            }

            var totalOutputStorageString = string.Concat(highestJoltages);
            totalOutputJoltage += ulong.Parse(totalOutputStorageString);
        }

        return totalOutputJoltage;
    }
}
