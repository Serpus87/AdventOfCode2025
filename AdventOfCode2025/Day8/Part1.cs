using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day8;

public static class Part1
{
    public static ulong Solve(List<JunctionBox> junctionBoxes)
    {
        BoxService.GetClosestLocations(junctionBoxes);

        var junctionBoxesToMakeCircuitsWith = BoxService.RemoveDuplicates(junctionBoxes);
        var circuits = BoxService.MakeShortestConnections(junctionBoxesToMakeCircuitsWith, 10);

        var threeLargestCircuits = circuits.OrderByDescending(x=>x.ConnectedBoxIds.Count).Take(3).ToList();

        var result = (ulong)(threeLargestCircuits[0].ConnectedBoxIds.Count * threeLargestCircuits[1].ConnectedBoxIds.Count * threeLargestCircuits[2].ConnectedBoxIds.Count);

        return result;
    }
}
