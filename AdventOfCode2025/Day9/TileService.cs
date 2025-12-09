using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day9;

public static class TileService
{
    public static List<Tile> GetRedTiles(string[] lines)
    {
        var tiles = new List<Tile>();

        foreach (var line in lines)
        {
            var splitString = line.Split(',');
            tiles.Add(new Tile(int.Parse(splitString[1]), int.Parse(splitString[0])));
        }

        return tiles;
    }

    public static ulong GetLargestRectangle(List<Tile> redTiles)
    {
        var largestRectangle = 0ul;

        foreach (var tile in redTiles)
        {
            var tileLargestRectangle = GetTileLargestRectangle(tile, redTiles);

            if (tileLargestRectangle > largestRectangle)
            {
                largestRectangle = tileLargestRectangle;
            }
        }

        return largestRectangle;
    }

    public static ulong GetLargestRectangle(List<Tile> redTiles, List<Tile> greenTiles)
    {
        var largestRectangle = 0ul;

        foreach (var tile in redTiles)
        {
            var tileLargestRectangle = GetTileLargestRectangle(tile, redTiles, greenTiles);

            if (tileLargestRectangle > largestRectangle)
            {
                largestRectangle = tileLargestRectangle;
            }
        }

        return largestRectangle;
    }

    private static ulong GetTileLargestRectangle(Tile tile, List<Tile> redTiles)
    {
        var largestRectangle = 0ul;

        foreach (var tile2 in redTiles)
        {
            var calculatedRectangle = CalculateRectangle(tile, tile2);

            if (calculatedRectangle > largestRectangle)
            {
                largestRectangle = calculatedRectangle;
            }
        }

        return largestRectangle;
    }

    private static ulong GetTileLargestRectangle(Tile tile, List<Tile> redTiles, List<Tile> greenTiles)
    {
        var largestRectangle = 0ul;

        foreach (var tile2 in redTiles)
        {
            var oppositeTiles = GetOppositeTiles(tile,tile2);
            var areOppositeTilesRedOrGreen = AreOppositeTilesRedOrGreen(oppositeTiles, redTiles, greenTiles);

            if (!areOppositeTilesRedOrGreen)
            {
                continue;
            }

            var calculatedRectangle = CalculateRectangle(tile, tile2);

            if (calculatedRectangle > largestRectangle)
            {
                largestRectangle = calculatedRectangle;
            }
        }

        return largestRectangle;
    }

    private static bool AreOppositeTilesRedOrGreen(List<Tile> oppositeTiles, List<Tile> redTiles, List<Tile> greenTiles)
    {
        var isTile1RedOrGreen = IsTileRedOrGreen(oppositeTiles.First(),redTiles,greenTiles);
        var isTile2RedOrGreen = IsTileRedOrGreen(oppositeTiles.Last(), redTiles, greenTiles);

        return isTile1RedOrGreen && isTile2RedOrGreen;
    }

    private static bool IsTileRedOrGreen(Tile tile, List<Tile> redTiles, List<Tile> greenTiles)
    {
        return redTiles.Any(x=>x.XCoordinate == tile.XCoordinate &&  x.YCoordinate == tile.YCoordinate) || greenTiles.Any(x => x.XCoordinate == tile.XCoordinate && x.YCoordinate == tile.YCoordinate);
    }

    private static List<Tile> GetOppositeTiles(Tile tile, Tile tile2)
    {
        return new List<Tile>
        {
            new Tile(tile.XCoordinate,tile2.YCoordinate),
            new Tile(tile2.XCoordinate,tile.YCoordinate),
        };
    }

    private static ulong CalculateRectangle(Tile tile, Tile tile2)
    {
        var xdistance = (ulong)(Math.Abs(tile.XCoordinate - tile2.XCoordinate) + 1);
        var ydistance = (ulong)(Math.Abs(tile.YCoordinate - tile2.YCoordinate) + 1);

        return xdistance * ydistance;
    }

    public static List<Tile> GetGreenTiles(List<Tile> redTiles)
    {
        var greenTiles = new List<Tile>();

        var greenTileWrapper = GetGreenTileWrapper(redTiles);
        greenTiles = GetGreenTilesFromWrapper(greenTileWrapper, redTiles);

        return greenTiles;
    }

    private static List<Tile> GetGreenTileWrapper(List<Tile> redTiles)
    {
        var greenTileWrapper = new List<Tile>();

        var redTileXCoordinates = redTiles.Select(x=> x.XCoordinate).Distinct();

        foreach (var xCoordinate in redTileXCoordinates)
        {
            var redTilesOnXCoordinate = redTiles.Where(x=>x.XCoordinate == xCoordinate);

            for (var yCoordinate = redTilesOnXCoordinate.Min(x => x.YCoordinate) + 1; yCoordinate < redTilesOnXCoordinate.Max(x => x.YCoordinate); yCoordinate++)
            {
                if (redTiles.Any(x=>x.XCoordinate == xCoordinate && x.YCoordinate == yCoordinate))
                {
                    continue;
                }

                greenTileWrapper.Add(new Tile(xCoordinate, yCoordinate));
            }
        }

        var redTileYCoordinates = redTiles.Select(x => x.YCoordinate).Distinct();

        foreach (var yCoordinate in redTileYCoordinates)
        {
            var redTilesOnYCoordinate = redTiles.Where(x => x.YCoordinate == yCoordinate);

            for (var xCoordinate = redTilesOnYCoordinate.Min(x => x.XCoordinate) + 1; xCoordinate < redTilesOnYCoordinate.Max(x => x.XCoordinate); xCoordinate++)
            {
                if (redTiles.Any(x => x.XCoordinate == xCoordinate && x.YCoordinate == yCoordinate))
                {
                    continue;
                }

                greenTileWrapper.Add(new Tile(xCoordinate, yCoordinate));
            }
        }

        return greenTileWrapper;
    }

    private static List<Tile> GetGreenTilesFromWrapper(List<Tile> greenTiles, List<Tile> redTiles)
    {
        for (int xCoordinate = redTiles.Min(x=>x.XCoordinate); xCoordinate < redTiles.Max(x => x.XCoordinate); xCoordinate++)
        {
            int? minRedYCoordinate = null;
            int? maxRedYCoordinate = null;
            int? minGreenYCoordinate = null;
            int? maxGreenYCoordinate = null;

            if (redTiles.Any(x => x.XCoordinate == xCoordinate))
            {
                minRedYCoordinate = redTiles.Where(x => x.XCoordinate == xCoordinate).Min(x => x.YCoordinate);
                maxRedYCoordinate = redTiles.Where(x => x.XCoordinate == xCoordinate).Max(x => x.YCoordinate);
            }

            if (greenTiles.Any(x => x.XCoordinate == xCoordinate))
            {
                minGreenYCoordinate = greenTiles.Where(x => x.XCoordinate == xCoordinate).Min(x => x.YCoordinate);
                maxGreenYCoordinate = greenTiles.Where(x => x.XCoordinate == xCoordinate).Max(x => x.YCoordinate);
            }

            var minYCoordinate = minRedYCoordinate < minGreenYCoordinate ? minRedYCoordinate : minGreenYCoordinate;
            var maxYCoordinate = maxRedYCoordinate > maxGreenYCoordinate ? maxRedYCoordinate : maxGreenYCoordinate;

            for (int yCoordinate = (int)minYCoordinate!; yCoordinate < maxYCoordinate; yCoordinate++)
            {
                var greenTile = new Tile(xCoordinate, yCoordinate);

                if (IsTileRedOrGreen(greenTile, redTiles, greenTiles)) // commented out for speed
                {
                    continue;
                }

                greenTiles.Add(greenTile);
            }
        }

        return greenTiles;
    }

}
