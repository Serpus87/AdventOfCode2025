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
        var minimumNumberOfConnectionsNecessary = junctionBoxes.Count - 1;
        var nextShortestConnections = new List<Connection>();
        var shortestConnections = BoxService.GetShortestConnections(junctionBoxes, minimumNumberOfConnectionsNecessary);
        var circuits = BoxService.GetCircuits(shortestConnections);

        // get shortest connection
        // make circuit
        // keep doing this until circuits.Count == 1 && circuits.Ids contains all ids
        var shouldRun = true;

        while (shouldRun) 
        {
            minimumNumberOfConnectionsNecessary = Math.Max(circuits.Count - 1,1);
            nextShortestConnections = BoxService.GetNextShortestConnections(junctionBoxes, minimumNumberOfConnectionsNecessary, shortestConnections);

            //nextShortestConnection = BoxService.GetNextShortestConnection(junctionBoxes, shortestConnections);
            shortestConnections.AddRange(nextShortestConnections);
            //circuits = BoxService.AddShortestConnectionToCircuits(nextShortestConnection, circuits);
            circuits = BoxService.AddShortestConnectionsToCircuits(nextShortestConnections, circuits);

            //shouldRun = !(circuits.Count == 1 && circuits.FirstOrDefault()?.ConnectedBoxIds.Distinct() == junctionBoxes.Select(x => x.Id));
            shouldRun = !(circuits.FirstOrDefault()?.ConnectedBoxIds.Count == junctionBoxes.Count);
            Console.WriteLine($"Number of circuits: {circuits.Count}; Number of connections left to add: {junctionBoxes.Count - circuits.First(x=>x.ConnectedBoxIds.Count == circuits.Max(x=>x.ConnectedBoxIds.Count)).ConnectedBoxIds.Count}");
        }

        var x1 = junctionBoxes.First(x => x.Id == nextShortestConnections.Single().JunctionBoxId1).Location.XCoordinate;
        var x2 = junctionBoxes.First(x => x.Id == nextShortestConnections.Single().JunctionBoxId2).Location.XCoordinate;

        return (ulong)x1* (ulong)x2;
    }
}
