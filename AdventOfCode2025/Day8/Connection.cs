using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day8;

public class Connection
{
    public int JunctionBoxId1 { get; init; }
    public int JunctionBoxId2 { get; init; }
    public double Distance { get; init; }

    public Connection(int junctionBoxId1, int junctionBoxId2, double distance)
    {
        JunctionBoxId1 = junctionBoxId1;
        JunctionBoxId2 = junctionBoxId2;
        Distance = distance;
    }
}
