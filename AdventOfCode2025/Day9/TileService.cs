using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day9;

public static class TileService
{
    public static List<Tile> GetTiles(string[] lines)
    {
        var tiles = new List<Tile>();

        foreach (var line in lines)
        {
            var splitString = line.Split(',');
            tiles.Add(new Tile(int.Parse(splitString[0]), int.Parse(splitString[1])));
        }

        return tiles;
    }

    public static ulong GetLargestRectangle(List<Tile> tiles)
    {
        var largestRectangle = 0ul;

        foreach (var tile in tiles)
        {
            var tileLargestRectangle = GetTileLargestRectangle(tile, tiles);

            if (tileLargestRectangle > largestRectangle)
            {
                largestRectangle = tileLargestRectangle;
            }
        }

        return largestRectangle;
    }

    private static ulong GetTileLargestRectangle(Tile tile, List<Tile> tiles)
    {
        var largestRectangle = 0ul;

        foreach (var tile2 in tiles)
        {
            var calculatedRectangle = CalculateRectangle(tile, tile2);

            if (calculatedRectangle > largestRectangle)
            {
                largestRectangle = calculatedRectangle;
            }
        }

        return largestRectangle;
    }

    private static ulong CalculateRectangle(Tile tile, Tile tile2)
    {
        var xdistance = (ulong)(Math.Abs(tile.XCoordinate - tile2.XCoordinate) + 1);
        var ydistance = (ulong)(Math.Abs(tile.YCoordinate - tile2.YCoordinate) + 1);

        return xdistance * ydistance;
    }
}
