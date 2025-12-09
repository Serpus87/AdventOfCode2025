using System;
using System.Collections.Generic;
using System.Linq;
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

    public static void GetClosestLocations(List<JunctionBox> junctionBoxes)
    {
        foreach (var junctionBox in junctionBoxes)
        {
            junctionBox.FindClosestJunctionBox(junctionBoxes.Where(x => x.Id != junctionBox.Id).ToList());
        }
    }

    public static List<Circuit> MakeShortestConnections(List<JunctionBox> junctionBoxes, int numberOfConnectionsToMake)
    {
        var circuits = new List<Circuit>();

        var closestJunctionBoxes = junctionBoxes.OrderBy(x => x.DistanceToClosestJunctionBox).Take(numberOfConnectionsToMake).ToList();

        foreach (var junctionBox in closestJunctionBoxes)
        {
            var circuitsToExpand = circuits.Where(x => x.ConnectedBoxIds.Contains(junctionBox.Id) || x.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId)).ToList();

            if (circuitsToExpand.Count == 0)
            {
                circuits.Add(new Circuit([junctionBox.Id, junctionBox.ClosestJunctionBoxId]));
                continue;
            }

            // add all connected ids
            if (circuitsToExpand.Count == 1)
            {
                var circuitToExpand = circuitsToExpand.First();

                if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId))
                {
                    circuitToExpand.ConnectedBoxIds.Add(junctionBox.ClosestJunctionBoxId);
                }
                if (circuitToExpand.ConnectedBoxIds.Contains(junctionBox.ClosestJunctionBoxId) && !circuitToExpand.ConnectedBoxIds.Contains(junctionBox.Id))
                {
                    circuitToExpand.ConnectedBoxIds.Add(junctionBox.Id);
                }
            }
            else 
            {
                foreach (var circuitToRemove in circuitsToExpand)
                {
                    circuits.Remove(circuitToRemove);
                }

                var distinctIds = circuitsToExpand.SelectMany(x => x.ConnectedBoxIds).Distinct().ToList();

                circuits.Add(new Circuit(distinctIds));
            }
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
}
