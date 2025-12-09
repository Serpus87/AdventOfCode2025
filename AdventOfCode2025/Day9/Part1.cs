using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day9;

public static class Part1
{
    public static ulong Solve(List<Tile> tiles)
    {
        return TileService.GetLargestRectangle(tiles);
    }
}
