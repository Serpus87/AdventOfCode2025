using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day8;

public static class BoxService
{
    public static List<JunctionBox> GetJunctionBoxes(string[] lines)
    {
        var junctionBoxes = new List<JunctionBox>();

        var counter = 0;
        foreach (var line in lines)
        {
            counter++;
            var coordinates = line.Split(',');
            junctionBoxes.Add(new JunctionBox(counter, new Location(int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2]))));
        }

        return junctionBoxes;
    }

    public static List<Connection> GetShortestConnections(List<JunctionBox> junctionBoxes, int numberOfConnectionsToMake)
    {
        var shortestConnections = new List<Connection>();

        // loop through boxes
        // calculate distance to all other boxes
        // if distance is within shortestConnections add or replace
        foreach (var junctionBox1 in junctionBoxes)
        {
            foreach (var junctionBox2 in junctionBoxes.Where(x => x.Id != junctionBox1.Id).ToList())
            {
                if (shortestConnections.Any(x => x.JunctionBoxId1 == junctionBox2.Id && x.JunctionBoxId2 == junctionBox1.Id))
                {
                    continue;
                }

                var distance = GetDistance(junctionBox1.Location, junctionBox2.Location);

                if (shortestConnections.Count < numberOfConnectionsToMake)
                {
                    shortestConnections.Add(new Connection(junctionBox1.Id, junctionBox2.Id, distance));
                    continue;
                }
                if (distance < shortestConnections.Max(x => x.Distance))
                {
                    shortestConnections.RemoveAt(shortestConnections.IndexOf(shortestConnections.MaxBy(x => x.Distance)!));
                    shortestConnections.Add(new Connection(junctionBox1.Id, junctionBox2.Id, distance));
                }
            }
        }

        return shortestConnections;
    }

    public static Connection GetNextShortestConnection(List<JunctionBox> junctionBoxes, List<Connection> connectionsToSkip)
    {
        var shortestDistance = double.MaxValue;
        var shortestConnection = new Connection(0, 0, 0);

        // loop through boxes
        // calculate distance to all other boxes
        // if distance is within shortestConnections add or replace
        foreach (var junctionBox1 in junctionBoxes)
        {
            foreach (var junctionBox2 in junctionBoxes.Where(x => x.Id != junctionBox1.Id).ToList())
            {
                if (connectionsToSkip.Any(x => (x.JunctionBoxId1 == junctionBox1.Id && x.JunctionBoxId2 == junctionBox2.Id) || (x.JunctionBoxId1 == junctionBox2.Id && x.JunctionBoxId2 == junctionBox1.Id)))
                {
                    continue;
                }

                var distance = GetDistance(junctionBox1.Location, junctionBox2.Location);


                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    shortestConnection = (new Connection(junctionBox1.Id, junctionBox2.Id, distance));
                }
            }
        }

        return shortestConnection;
    }

    public static void GetClosestLocations(List<JunctionBox> junctionBoxes)
    {
        foreach (var junctionBox in junctionBoxes)
        {
            junctionBox.FindClosestJunctionBox(junctionBoxes.Where(x => x.Id != junctionBox.Id).ToList());
        }
    }

    public static List<Circuit> GetCircuits(List<Connection> shortestConnections)
    {
        var circuits = new List<Circuit>();

        foreach (var connection in shortestConnections)
        {
            if (circuits.Any(x => x.ConnectedBoxIds.Contains(connection.JunctionBoxId1) && x.ConnectedBoxIds.Contains(connection.JunctionBoxId2)))
            {
                continue;
            }

            var circuitsToExpand = circuits.Where(x => x.ConnectedBoxIds.Contains(connection.JunctionBoxId1) || x.ConnectedBoxIds.Contains(connection.JunctionBoxId2)).ToList();

            if (circuitsToExpand.Count == 0)
            {
                circuits.Add(new Circuit([connection.JunctionBoxId1, connection.JunctionBoxId2]));
            }
            if (circuitsToExpand.Count == 1)
            {
                var circuitToExpand = circuitsToExpand.Single();

                //if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId))
                if (!circuitToExpand.ConnectedBoxIds.Contains(connection.JunctionBoxId2))
                {
                    circuitToExpand.ConnectedBoxIds.Add(connection.JunctionBoxId2);
                }
                //if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id))
                if (!circuitToExpand.ConnectedBoxIds.Contains(connection.JunctionBoxId1))
                {
                    circuitToExpand.ConnectedBoxIds.Add(connection.JunctionBoxId1);
                }
            }
            if (circuitsToExpand.Count > 1)
            {
                var distinctIds = circuitsToExpand.SelectMany(x => x.ConnectedBoxIds).Distinct().ToList();

                foreach (var circuitToRemove in circuitsToExpand)
                {
                    circuits.Remove(circuitToRemove);
                }

                circuits.Add(new Circuit(distinctIds));
            }

            // print for debug
            var threeLargestCircuits = circuits.OrderByDescending(x => x.ConnectedBoxIds.Count).Take(3).ToList();

            if (threeLargestCircuits.Count > 2)
            {
                var result = (ulong)threeLargestCircuits[0].ConnectedBoxIds.Count * (ulong)threeLargestCircuits[1].ConnectedBoxIds.Count * (ulong)threeLargestCircuits[2].ConnectedBoxIds.Count;

                Console.WriteLine($"Number of circuits: {circuits.Count}; Three largest circuits: {threeLargestCircuits[0].ConnectedBoxIds.Count},{threeLargestCircuits[1].ConnectedBoxIds.Count},{threeLargestCircuits[2].ConnectedBoxIds.Count}");

            }
            // end
        }

        return circuits;
    }

    public static List<Circuit> AddShortestConnectionToCircuits(Connection shortestConnection, List<Circuit> circuits)
    {
        var circuitsToExpand = circuits.Where(x => x.ConnectedBoxIds.Contains(shortestConnection.JunctionBoxId1) || x.ConnectedBoxIds.Contains(shortestConnection.JunctionBoxId2)).ToList();

        if (circuitsToExpand.Count == 0)
        {
            circuits.Add(new Circuit([shortestConnection.JunctionBoxId1, shortestConnection.JunctionBoxId2]));
        }
        if (circuitsToExpand.Count == 1)
        {
            var circuitToExpand = circuitsToExpand.Single();

            //if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId))
            if (!circuitToExpand.ConnectedBoxIds.Contains(shortestConnection.JunctionBoxId2))
            {
                circuitToExpand.ConnectedBoxIds.Add(shortestConnection.JunctionBoxId2);
            }
            //if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id))
            if (!circuitToExpand.ConnectedBoxIds.Contains(shortestConnection.JunctionBoxId1))
            {
                circuitToExpand.ConnectedBoxIds.Add(shortestConnection.JunctionBoxId1);
            }
        }
        if (circuitsToExpand.Count > 1)
        {
            var distinctIds = circuitsToExpand.SelectMany(x => x.ConnectedBoxIds).Distinct().ToList();

            foreach (var circuitToRemove in circuitsToExpand)
            {
                circuits.Remove(circuitToRemove);
            }

            circuits.Add(new Circuit(distinctIds));
        }

        return circuits;
    }

    public static List<Circuit> MakeShortestConnections(List<JunctionBox> junctionBoxes, int numberOfConnectionsToMake)
    {
        var circuits = new List<Circuit>();

        var closestJunctionBoxes = junctionBoxes.OrderBy(x => x.DistanceToClosestJunctionBox).Take(numberOfConnectionsToMake).ToList();

        foreach (var junctionBox in closestJunctionBoxes)
        {
            if (circuits.Any(x => x.ConnectedBoxIds.Contains(junctionBox.Id) && x.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId)))
            {
                continue;
            }

            var circuitsToExpand = circuits.Where(x => x.ConnectedBoxIds.Contains(junctionBox.Id) || x.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId)).ToList();

            if (circuitsToExpand.Count == 0)
            {
                circuits.Add(new Circuit([junctionBox.Id, junctionBox.ClosestJunctionBoxId]));
            }
            if (circuitsToExpand.Count == 1)
            {
                var circuitToExpand = circuitsToExpand.Single();

                //if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId))
                if (!circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId))
                {
                    circuitToExpand.ConnectedBoxIds.Add(junctionBox.ClosestJunctionBoxId);
                }
                //if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id))
                if (!circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id))
                {
                    circuitToExpand.ConnectedBoxIds.Add(junctionBox.Id);
                }
            }
            if (circuitsToExpand.Count > 1)
            {
                var distinctIds = circuitsToExpand.SelectMany(x => x.ConnectedBoxIds).Distinct().ToList();

                foreach (var circuitToRemove in circuitsToExpand)
                {
                    circuits.Remove(circuitToRemove);
                }

                circuits.Add(new Circuit(distinctIds));
            }

            // print for debug
            var threeLargestCircuits = circuits.OrderByDescending(x => x.ConnectedBoxIds.Count).Take(3).ToList();

            if (threeLargestCircuits.Count > 2)
            {
                var result = (ulong)threeLargestCircuits[0].ConnectedBoxIds.Count * (ulong)threeLargestCircuits[1].ConnectedBoxIds.Count * (ulong)threeLargestCircuits[2].ConnectedBoxIds.Count;

                Console.WriteLine($"Number of circuits: {circuits.Count}; Three largest circuits: {threeLargestCircuits[0].ConnectedBoxIds.Count},{threeLargestCircuits[1].ConnectedBoxIds.Count},{threeLargestCircuits[2].ConnectedBoxIds.Count}");

            }
            // end
        }

        return circuits;
    }

    private static void FindClosestJunctionBox(this JunctionBox junctionBox, List<JunctionBox> junctionBoxesToFind)
    {
        var closestDistance = double.MaxValue;
        var closestJunctionBox = junctionBox;

        foreach (var junctionBoxToFind in junctionBoxesToFind)
        {
            if (junctionBox.Id == junctionBoxToFind.ClosestJunctionBoxId)
            {
                continue;
            }

            var distance = GetDistance(junctionBox.Location, junctionBoxToFind.Location);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestJunctionBox = junctionBoxToFind;
            }
        }

        junctionBox.ClosestJunctionBox = closestJunctionBox;
        junctionBox.DistanceToClosestJunctionBox = closestDistance;
        junctionBox.ClosestJunctionBoxId = closestJunctionBox.Id;
    }

    private static double GetDistance(Location locationA, Location locationB)
    {
        var xDistance = (double)Math.Abs(locationA.XCoordinate - locationB.XCoordinate);
        var yDistance = (double)Math.Abs(locationA.YCoordinate - locationB.YCoordinate);
        var zDistance = (double)Math.Abs(locationA.ZCoordinate - locationB.ZCoordinate);

        var xyDistance = GetDistance(xDistance, yDistance);
        var xyzDstiance = GetDistance(xyDistance, zDistance);

        return xyzDstiance;
    }

    private static double GetDistance(double distanceA, double distanceB)
    {
        return Math.Sqrt(distanceA * distanceA + distanceB * distanceB);
    }

    internal static List<Connection> GetNextShortestConnections(List<JunctionBox> junctionBoxes, int minimumNumberOfConnectionsNecessary, List<Connection> shortestConnections)
    {
        var nextShortestConnections = new List<Connection>();

        foreach (var junctionBox1 in junctionBoxes)
        {
            foreach (var junctionBox2 in junctionBoxes.Where(x => x.Id != junctionBox1.Id).ToList())
            {
                if (shortestConnections.Any(x => (x.JunctionBoxId1 == junctionBox1.Id && x.JunctionBoxId2 == junctionBox2.Id) || (x.JunctionBoxId1 == junctionBox2.Id && x.JunctionBoxId2 == junctionBox1.Id)))
                {
                    continue;
                }

                var distance = GetDistance(junctionBox1.Location, junctionBox2.Location);

                if (nextShortestConnections.Count < minimumNumberOfConnectionsNecessary)
                {
                    nextShortestConnections.Add(new Connection(junctionBox1.Id, junctionBox2.Id, distance));
                    continue;
                }
                if (distance < nextShortestConnections.Max(x => x.Distance))
                {
                    nextShortestConnections.RemoveAt(nextShortestConnections.IndexOf(nextShortestConnections.MaxBy(x => x.Distance)!));
                    nextShortestConnections.Add(new Connection(junctionBox1.Id, junctionBox2.Id, distance));
                }
            }
        }

        return nextShortestConnections;
    }

    internal static List<Circuit> AddShortestConnectionsToCircuits(List<Connection> nextShortestConnections, List<Circuit> circuits)
    {
        foreach (var shortestConnection in nextShortestConnections)
        {
            var circuitsToExpand = circuits.Where(x => x.ConnectedBoxIds.Contains(shortestConnection.JunctionBoxId1) || x.ConnectedBoxIds.Contains(shortestConnection.JunctionBoxId2)).ToList();

            if (circuitsToExpand.Count == 0)
            {
                circuits.Add(new Circuit([shortestConnection.JunctionBoxId1, shortestConnection.JunctionBoxId2]));
            }
            if (circuitsToExpand.Count == 1)
            {
                var circuitToExpand = circuitsToExpand.Single();

                //if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId))
                if (!circuitToExpand.ConnectedBoxIds.Contains(shortestConnection.JunctionBoxId2))
                {
                    circuitToExpand.ConnectedBoxIds.Add(shortestConnection.JunctionBoxId2);
                }
                //if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id))
                if (!circuitToExpand.ConnectedBoxIds.Contains(shortestConnection.JunctionBoxId1))
                {
                    circuitToExpand.ConnectedBoxIds.Add(shortestConnection.JunctionBoxId1);
                }
            }
            if (circuitsToExpand.Count > 1)
            {
                var distinctIds = circuitsToExpand.SelectMany(x => x.ConnectedBoxIds).Distinct().ToList();

                foreach (var circuitToRemove in circuitsToExpand)
                {
                    circuits.Remove(circuitToRemove);
                }

                circuits.Add(new Circuit(distinctIds));
            }
        }

        return circuits;
    }
}
