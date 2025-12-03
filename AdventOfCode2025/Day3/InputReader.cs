using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day1;

namespace AdventOfCode2025.Day3;

public static class InputReader
{
    public static List<Bank> GetBanks(string fileName)
    {
        var banks = new List<Bank>();
        string[] lines = File.ReadAllLines($"Day3\\{fileName}");

        foreach (var line in lines)
        {
            var chars = line.ToCharArray();
            var joltages = chars.Select(x => uint.Parse(x.ToString())).ToList();
            var bank = new Bank(joltages);

            banks.Add(bank);
        }

        return banks;
    }
}
