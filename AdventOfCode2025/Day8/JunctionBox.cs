using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day8;

public class JunctionBox
{
    public int XCoordinate { get; init; }
    public int YCoordinate { get; init; }
    public int ZCoordinate { get; init; }
    public JunctionBox ClosestJunctionBox { get; set; } = default!;
    public decimal DistanceToClosestJunctionBox { get; set; } = default!;

    public JunctionBox(int xCoordinate, int yCoordinate, int zCoordinate)
    {
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
        ZCoordinate = zCoordinate;
    }
}
