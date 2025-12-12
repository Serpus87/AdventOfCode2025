using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day9;

public static class Part2
{
    public static ulong Solve(List<Tile> redTiles)
    {
        var greenTileWrapper = TileService.GetGreenTileWrapper(redTiles);
        var greenTiles = TileService.GetGreenTilesFromWrapper(greenTileWrapper, redTiles);
        var largestRectangle = TileService.GetLargestRectangle(redTiles, greenTiles);

        return largestRectangle;
    }
}
