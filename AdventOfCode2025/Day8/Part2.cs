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
        var circuits = new List<Circuit>();
        var shortestConnections = new List<Connection> ();
        var nextShortestConnection = new Connection(0, 0, 0);
        // get shortest connection
        // make circuit
        // keep doing this until circuits.Count == 1 && circuits.Ids contains all ids

        var shouldRun = true;

        while (shouldRun) 
        {
            nextShortestConnection = BoxService.GetNextShortestConnection(junctionBoxes, shortestConnections);
            shortestConnections.Add(nextShortestConnection);
            circuits = BoxService.AddShortestConnectionToCircuits(nextShortestConnection, circuits);

            //shouldRun = !(circuits.Count == 1 && circuits.FirstOrDefault()?.ConnectedBoxIds.Distinct() == junctionBoxes.Select(x => x.Id));
            shouldRun = !(circuits.FirstOrDefault()?.ConnectedBoxIds.Count == junctionBoxes.Count);
        }

        var x1 = junctionBoxes.First(x => x.Id == nextShortestConnection.JunctionBoxId1).Location.XCoordinate;
        var x2 = junctionBoxes.First(x => x.Id == nextShortestConnection.JunctionBoxId2).Location.XCoordinate;

        return (ulong)x1* (ulong)x2;
    }
}
