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

    public static ulong GetLargestRectangle(List<Tile> redTiles, List<Tile> greenTileWrapper)
    {
        var largestRectangle = 0ul;

        // debug
        //Print(redTiles, greenTileWrapper);
        // debug

        var counter = 0;
        foreach (var tile in redTiles)
        {
            //var redTilesToCheck = redTiles.Where(x => x.XCoordinate != tile.XCoordinate || x.YCoordinate != tile.YCoordinate).ToList();
            var tileLargestRectangle = GetTileLargestRectangle(tile, redTiles, greenTileWrapper, largestRectangle);

            if (tileLargestRectangle > largestRectangle)
            {
                largestRectangle = tileLargestRectangle;
            }

            counter++;
            Console.WriteLine($"tile {counter} of {redTiles.Count}; LargestRectangle: {largestRectangle}");
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

    private static ulong GetTileLargestRectangle(Tile tile, List<Tile> redTiles, List<Tile> greenTiles, ulong largestRectangle)
    {
        foreach (var tile2 in redTiles)
        {
            if (tile.XCoordinate == tile2.XCoordinate || tile.YCoordinate == tile2.YCoordinate) // todo improve this
            {
                continue;
            }

            var initialRectangle = CalculateRectangle(tile, tile2);
            if (initialRectangle < largestRectangle)
            {
                continue;
            }

            var oppositeTiles = GetOppositeTiles(tile, tile2);
            var areOppositeTilesWithinBoundaries = AreOppositeTilesWithinBoundaries(oppositeTiles, redTiles, greenTiles);

            if (!areOppositeTilesWithinBoundaries)
            {
                continue;
            }

            //var areTilesWithinBoundaries = AreTilesWithinBoundaries(tile, tile2, oppositeTiles[0], oppositeTiles[1], greenTiles);
            //if (!areTilesWithinBoundaries)
            //{
            //    continue;
            //}

            var calculatedRectangle = CalculateRectangle(tile, tile2);

            if (calculatedRectangle > largestRectangle)
            {
                largestRectangle = calculatedRectangle;
            }
        }

        return largestRectangle;
    }

    //private static bool AreTilesWithinBoundaries(Tile tile1, Tile tile2, Tile tile3, Tile tile4, List<Tile> greenTiles)
    //{
    //    var greenTilesWithXCoordinate1 = greenTiles.Where(x=>x.XCoordinate == tile1.XCoordinate).ToList();
    //    var greenTilesWithXCoordinate2 = greenTiles.Where(x=>x.XCoordinate == tile2.XCoordinate).ToList();
    //    var greenTilesWithYCoordinate1 = greenTiles.Where(x => x.YCoordinate == tile1.YCoordinate).ToList();
    //    var greenTilesWithYCoordinate2 = greenTiles.Where(x => x.YCoordinate == tile2.YCoordinate).ToList();

    //    var check1 = greenTilesWithXCoordinate1.Any(x => x.YCoordinate > tile1.YCoordinate && x.YCoordinate < tile4.YCoordinate);

    //    return check1;
    //}

    private static bool AreOppositeTilesWithinBoundaries(List<Tile> oppositeTiles, List<Tile> redTiles, List<Tile> greenTiles)
    {
        var isTile1RedOrGreen = IsTileWithinBoundaries(oppositeTiles.First(), redTiles, greenTiles);
        var isTile2RedOrGreen = IsTileWithinBoundaries(oppositeTiles.Last(), redTiles, greenTiles);

        return isTile1RedOrGreen && isTile2RedOrGreen;
    }

    private static bool IsTileWithinBoundaries(Tile tile, List<Tile> redTiles, List<Tile> greenTiles)
    {
        var tileXCoordinate = tile.XCoordinate;
        var tileYCoordinate = tile.YCoordinate;

        int? minRedXCoordinate = null;
        int? maxRedXCoordinate = null;
        int? minGreenXCoordinate = null;
        int? maxGreenXCoordinate = null;
        int? minRedYCoordinate = null;
        int? maxRedYCoordinate = null;
        int? minGreenYCoordinate = null;
        int? maxGreenYCoordinate = null;

        if (redTiles.Any(x => x.XCoordinate == tileXCoordinate))
        {
            minRedXCoordinate = redTiles.Min(x => x.XCoordinate);
            maxRedXCoordinate = redTiles.Max(x => x.XCoordinate);
            minRedYCoordinate = redTiles.Where(x => x.XCoordinate == tileXCoordinate).Min(x => x.YCoordinate);
            maxRedYCoordinate = redTiles.Where(x => x.XCoordinate == tileXCoordinate).Max(x => x.YCoordinate);
        }

        if (greenTiles.Any(x => x.XCoordinate == tileXCoordinate))
        {
            minGreenXCoordinate = greenTiles.Min(x => x.XCoordinate);
            maxGreenXCoordinate = greenTiles.Max(x => x.XCoordinate);
            minGreenYCoordinate = greenTiles.Where(x => x.XCoordinate == tileXCoordinate).Min(x => x.YCoordinate);
            maxGreenYCoordinate = greenTiles.Where(x => x.XCoordinate == tileXCoordinate).Max(x => x.YCoordinate);
        }

        var minXCoordinate = minRedXCoordinate < minGreenXCoordinate ? minRedXCoordinate : minGreenXCoordinate;
        var maxXCoordinate = maxRedXCoordinate > maxGreenXCoordinate ? maxRedXCoordinate : maxGreenXCoordinate;
        var minYCoordinate = minRedYCoordinate < minGreenYCoordinate ? minRedYCoordinate : minGreenYCoordinate;
        var maxYCoordinate = maxRedYCoordinate > maxGreenYCoordinate ? maxRedYCoordinate : maxGreenYCoordinate;

        return tileXCoordinate <= maxXCoordinate && tileXCoordinate >= minXCoordinate && tileYCoordinate <= maxYCoordinate && tileYCoordinate >= minYCoordinate;
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

    //public static List<Tile> GetGreenTiles(List<Tile> redTiles)
    //{
    //    var greenTiles = new List<Tile>();

    //    var greenTileWrapper = GetGreenTileWrapper(redTiles);
    //    greenTiles = GetGreenTilesFromWrapper(greenTileWrapper, redTiles);

    //    return greenTiles;
    //}

    public static List<Tile> GetGreenTileWrapper(List<Tile> redTiles)
    {
        var greenTileWrapper = new List<Tile>();

        var redTileXCoordinates = redTiles.Select(x => x.XCoordinate).Distinct();

        foreach (var xCoordinate in redTileXCoordinates)
        {
            var redTilesOnXCoordinate = redTiles.Where(x => x.XCoordinate == xCoordinate);

            for (var yCoordinate = redTilesOnXCoordinate.Min(x => x.YCoordinate) + 1; yCoordinate < redTilesOnXCoordinate.Max(x => x.YCoordinate); yCoordinate++)
            {
                if (redTiles.Any(x => x.XCoordinate == xCoordinate && x.YCoordinate == yCoordinate))
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

    // don't actually need all this, 
    //private static List<Tile> GetGreenTilesFromWrapper(List<Tile> greenTiles, List<Tile> redTiles)
    //{
    //    for (int xCoordinate = redTiles.Min(x=>x.XCoordinate); xCoordinate < redTiles.Max(x => x.XCoordinate); xCoordinate++)
    //    {
    //        int? minRedYCoordinate = null;
    //        int? maxRedYCoordinate = null;
    //        int? minGreenYCoordinate = null;
    //        int? maxGreenYCoordinate = null;

    //        if (redTiles.Any(x => x.XCoordinate == xCoordinate))
    //        {
    //            minRedYCoordinate = redTiles.Where(x => x.XCoordinate == xCoordinate).Min(x => x.YCoordinate);
    //            maxRedYCoordinate = redTiles.Where(x => x.XCoordinate == xCoordinate).Max(x => x.YCoordinate);
    //        }

    //        if (greenTiles.Any(x => x.XCoordinate == xCoordinate))
    //        {
    //            minGreenYCoordinate = greenTiles.Where(x => x.XCoordinate == xCoordinate).Min(x => x.YCoordinate);
    //            maxGreenYCoordinate = greenTiles.Where(x => x.XCoordinate == xCoordinate).Max(x => x.YCoordinate);
    //        }

    //        var minYCoordinate = minRedYCoordinate < minGreenYCoordinate ? minRedYCoordinate : minGreenYCoordinate;
    //        var maxYCoordinate = maxRedYCoordinate > maxGreenYCoordinate ? maxRedYCoordinate : maxGreenYCoordinate;

    //        for (int yCoordinate = (int)minYCoordinate!; yCoordinate < maxYCoordinate; yCoordinate++)
    //        {
    //            var greenTile = new Tile(xCoordinate, yCoordinate);

    //            if (IsTileRedOrGreen(greenTile, redTiles, greenTiles)) // commented out for speed
    //            {
    //                continue;
    //            }

    //            greenTiles.Add(greenTile);
    //        }
    //    }

    //    return greenTiles;
    //}

    private static void Print(List<Tile> redTiles, List<Tile> greenTileWrapper)
    {
        for (var i = redTiles.Min(x => x.XCoordinate); i <= redTiles.Max(x => x.XCoordinate); i++)
        {
            var stringToPrint = "";
            for (int j = redTiles.Min(x => x.YCoordinate); j <= redTiles.Max(x => x.YCoordinate); j++)
            {
                if (redTiles.Any(x => x.XCoordinate == i && x.YCoordinate == j))
                {
                    stringToPrint += "#";
                    continue;
                }
                if (greenTileWrapper.Any(x => x.XCoordinate == i && x.YCoordinate == j))
                {
                    stringToPrint += "X";
                    continue;
                }
                stringToPrint += ".";
            }

            Console.WriteLine(stringToPrint);
        }
    }
}
