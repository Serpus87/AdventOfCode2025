using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day8;

public static class Part2
{
    public static ulong Solve(List<JunctionBox> junctionBoxes)
    {
        var connections = BoxService.GetAllConnections(junctionBoxes);
        var orderedConnections = connections.OrderBy(x => x.Distance).ToList();

        var minimumNumberOfConnectionsNecessary = junctionBoxes.Count - 1;
        var shortestConnections = orderedConnections.Take(minimumNumberOfConnectionsNecessary).ToList();
        var circuits = BoxService.GetCircuits(shortestConnections);

        var nextShortestConnections = new List<Connection>();
        var numberOfConnectionsMade = shortestConnections.Count;

        var shouldRun = true;
        while (shouldRun)
        {
            minimumNumberOfConnectionsNecessary = Math.Max(circuits.Count - 1, 1);
            nextShortestConnections = orderedConnections.Skip(numberOfConnectionsMade).Take(minimumNumberOfConnectionsNecessary).ToList();
            numberOfConnectionsMade += nextShortestConnections.Count;

            shortestConnections.AddRange(nextShortestConnections);
            circuits = BoxService.AddShortestConnectionsToCircuits(nextShortestConnections, circuits);

            shouldRun = !(circuits.FirstOrDefault()?.ConnectedBoxIds.Count == junctionBoxes.Count); // while loop can actually stop before last connection is made; but this is more fun
            Console.WriteLine($"Number of circuits: {circuits.Count}; Number of connections left to add: {junctionBoxes.Count - circuits.First(x => x.ConnectedBoxIds.Count == circuits.Max(x => x.ConnectedBoxIds.Count)).ConnectedBoxIds.Count}");
        }

        var x1 = (ulong)junctionBoxes.First(x => x.Id == nextShortestConnections.Single().JunctionBoxId1).Location.XCoordinate;
        var x2 = (ulong)junctionBoxes.First(x => x.Id == nextShortestConnections.Single().JunctionBoxId2).Location.XCoordinate;

        return x1 * x2;
    }
}
