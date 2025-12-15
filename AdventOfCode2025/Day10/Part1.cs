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

        var counter = 0;

        foreach (var machine in machines)
        {
            var fewestButtonPresses = MachineService.GetFewestButtonPressesWithTooManyForLoops(machine);
            result += fewestButtonPresses;
            counter++;
            Console.WriteLine($"{counter} out of {machines.Count} fewest button presses found!");
        }

        return result;
    }
}
