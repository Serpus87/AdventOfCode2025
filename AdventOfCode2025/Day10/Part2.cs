using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day10;

public static class Part2
{
    public static ulong Solve(List<Machine> machines)
    {
        var result = 0ul;

        var maxJoltageRequirement = machines.SelectMany(x => x.JoltageRequirements).Max();
        var maxNumberOfButtons = machines.Max(x => x.ButtonWiringSchematics.Count);

        // debug to get some insights
        var joltageRequirements = machines.SelectMany(x => x.JoltageRequirements).Distinct().OrderDescending().ToList();
        var numberOfButtons = machines.Select(x=>x.ButtonWiringSchematics.Count).Distinct().OrderDescending().ToList();
        var temp = machines.MaxBy(x => x.ButtonWiringSchematics.Count);
        // debug

        //var superDuperDictionary = MachineService.GetSuperDuperDictionary(maxJoltageRequirement, maxNumberOfButtons);
        //var superDuperDictionary = MachineService.GetSuperDuperDictionary(maxJoltageRequirement, 6);
        var superDuperDictionary = MachineService.GetSuperDuperDictionary(100, 6);

        var counter = 0;

        foreach (var machine in machines)
        {
            var fewestButtonPresses = MachineService.GetFewestButtonPressesForJoltageRequirementsV2(machine);
            result += fewestButtonPresses;
            counter++;
            Console.WriteLine($"{counter} out of {machines.Count} fewest button presses found!");
        }

        return result;
    }
}
