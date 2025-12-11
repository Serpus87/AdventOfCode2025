using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day8;

public class Location
{
    public int XCoordinate { get; init; }
    public int YCoordinate { get; init; }
    public int ZCoordinate { get; init; }

    public Location(int xCoordinate, int yCoordinate, int zCoordinate)
    {
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
        ZCoordinate = zCoordinate;
    }
}
