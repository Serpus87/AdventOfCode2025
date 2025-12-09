using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day9;

public class Tile
{
    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }

    public Tile(int xCoordinate, int yCoordinate)
    {
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
    }
}
