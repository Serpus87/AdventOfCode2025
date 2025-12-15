using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day10;

public static class Part1
{
    public static ulong Solve(List<Machine> machines)
    {
        var result = 0ul;

        foreach (var machine in machines)
        {
            var fewestButtonPresses = MachineService.GetFewestButtonPressesWithTooManyForLoops(machine);
            result += fewestButtonPresses;
        }

        return result;
    }
}
