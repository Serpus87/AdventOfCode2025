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
        //var result = OldAndSlow(junctionBoxes);
        BoxService.GetClosestLocations(junctionBoxes);
        var connections = BoxService.GetAllConnections(junctionBoxes);
        var orderedConnections = connections.OrderBy(x => x.Distance).ToList();

        var minimumNumberOfConnectionsNecessary = junctionBoxes.Count - 1;
        var nextShortestConnections = new List<Connection>();
        var shortestConnections = orderedConnections.Take(minimumNumberOfConnectionsNecessary).ToList();
        var numberOfConnectionsMade = shortestConnections.Count;
        var circuits = BoxService.GetCircuits(shortestConnections);

        ulong? result = null;

        var shouldRun = true;
        while (shouldRun)
        {
            minimumNumberOfConnectionsNecessary = Math.Max(circuits.Count - 1, 1);
            nextShortestConnections = orderedConnections.Skip(numberOfConnectionsMade).Take(minimumNumberOfConnectionsNecessary).ToList();
            numberOfConnectionsMade += nextShortestConnections.Count;

            shortestConnections.AddRange(nextShortestConnections);
            circuits = BoxService.AddShortestConnectionsToCircuits(nextShortestConnections, circuits);

            shouldRun = !(circuits.FirstOrDefault()?.ConnectedBoxIds.Count == junctionBoxes.Count);
            Console.WriteLine($"Number of circuits: {circuits.Count}; Number of connections left to add: {junctionBoxes.Count - circuits.First(x => x.ConnectedBoxIds.Count == circuits.Max(x => x.ConnectedBoxIds.Count)).ConnectedBoxIds.Count}");

            if (circuits.FirstOrDefault()?.ConnectedBoxIds.Count == (junctionBoxes.Count - 1))
            {
                var lastBoxToConnectId = junctionBoxes.First(x => circuits.First().ConnectedBoxIds.All(y => y != x.Id)).Id;
                var lastBoxToConnect = junctionBoxes.First(x => x.Id == lastBoxToConnectId);
                Console.WriteLine($"Last box to connect: {lastBoxToConnectId}");
                var altX1 = (ulong)lastBoxToConnect.Location.XCoordinate;
                var altX2 = (ulong)junctionBoxes.First(x => x.Id == lastBoxToConnect.ClosestJunctionBoxId).Location.XCoordinate;
                result = altX1 * altX2;

                Console.WriteLine($"{result}");
            }
        }

        return result!.Value;
    }

    private static ulong OldAndSlow(List<JunctionBox> junctionBoxes)
    {
        // todo improve this!
        // 1) calculate all distances between all nodes
        // 2) when expanding circuits, only add new nodes instead of edging within circuit

        var minimumNumberOfConnectionsNecessary = junctionBoxes.Count - 1; // this is how it should be done
        //var minimumNumberOfConnectionsNecessary = junctionBoxes.Count * 2; // this is to check something out
        //var minimumNumberOfConnectionsNecessary = junctionBoxes.Count * 3; // this is to check something out
        //var minimumNumberOfConnectionsNecessary = junctionBoxes.Count * 4; // this is to check something out
        var nextShortestConnections = new List<Connection>();
        var shortestConnections = BoxService.GetShortestConnections(junctionBoxes, minimumNumberOfConnectionsNecessary);
        var circuits = BoxService.GetCircuits(shortestConnections);


        // temp for answer:
        BoxService.GetClosestLocations(junctionBoxes);
        // temp

        // get shortest connection
        // make circuit
        // keep doing this until circuits.Count == 1 && circuits.Ids contains all ids
        var shouldRun = true;

        while (shouldRun)
        {
            minimumNumberOfConnectionsNecessary = Math.Max(circuits.Count - 1, 1);
            nextShortestConnections = BoxService.GetNextShortestConnections(junctionBoxes, minimumNumberOfConnectionsNecessary, shortestConnections);

            //nextShortestConnection = BoxService.GetNextShortestConnection(junctionBoxes, shortestConnections);
            shortestConnections.AddRange(nextShortestConnections);
            //circuits = BoxService.AddShortestConnectionToCircuits(nextShortestConnection, circuits);
            circuits = BoxService.AddShortestConnectionsToCircuits(nextShortestConnections, circuits);

            //shouldRun = !(circuits.Count == 1 && circuits.FirstOrDefault()?.ConnectedBoxIds.Distinct() == junctionBoxes.Select(x => x.Id));
            shouldRun = !(circuits.FirstOrDefault()?.ConnectedBoxIds.Count == junctionBoxes.Count);
            Console.WriteLine($"Number of circuits: {circuits.Count}; Number of connections left to add: {junctionBoxes.Count - circuits.First(x => x.ConnectedBoxIds.Count == circuits.Max(x => x.ConnectedBoxIds.Count)).ConnectedBoxIds.Count}");

            if (circuits.FirstOrDefault()?.ConnectedBoxIds.Count == (junctionBoxes.Count - 1))
            {
                //var lastBoxToConnectId = circuits.First().ConnectedBoxIds.First(x=>junctionBoxes.All(y => y.Id != x));
                var lastBoxToConnectId = junctionBoxes.First(x => circuits.First().ConnectedBoxIds.All(y => y != x.Id)).Id;
                //var result = peopleList2.Where(p => peopleList1.All(p2 => p2.ID != p.ID));

                var lastBoxToConnect = junctionBoxes.First(x => x.Id == lastBoxToConnectId);
                Console.WriteLine($"Last box to connect: {lastBoxToConnectId}");
                var altX1 = (ulong)lastBoxToConnect.Location.XCoordinate;
                var altX2 = (ulong)junctionBoxes.First(x => x.Id == lastBoxToConnect.ClosestJunctionBoxId).Location.XCoordinate;
                var altAnswer = altX1 * altX2;

                Console.WriteLine($"{altAnswer}");
            }
        }

        var x1 = junctionBoxes.First(x => x.Id == nextShortestConnections.Single().JunctionBoxId1).Location.XCoordinate;
        var x2 = junctionBoxes.First(x => x.Id == nextShortestConnections.Single().JunctionBoxId2).Location.XCoordinate;

        return (ulong)x1 * (ulong)x2;
    }
}
