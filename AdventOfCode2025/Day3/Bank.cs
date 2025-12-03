using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day3;

public class Bank
{
    public List<uint> Joltages { get; set; }

    public Bank(List<uint> joltages)
    {
        Joltages = joltages;
    }
}
