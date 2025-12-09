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
}
