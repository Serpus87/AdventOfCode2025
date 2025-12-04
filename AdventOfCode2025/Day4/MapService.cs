using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day4;

public static class MapService
{
    public static Map GetMap(string[] input)
    {
        var numberOfRows = input.Length;
        var numberOfColumns = input[0].Length;

        var map = new Map(numberOfRows, numberOfColumns);

        for (var row = 0; row < numberOfRows; row++)
        {
            for (var column = 0; column < numberOfColumns; column++)
            {
                var position = new Position(row, column);
                var fill = input[row][column];
                var field = new Field(position, fill);
                map.Fields[row, column] = field;
                map.FieldsList.Add(field);
            }
        }

        return map;
    }

    public static List<Position> GetAdjacentPositions(Map map, Position positionToCheck)
    {
        var adjacentPositions = new List<Position>();

        for (int row = -1; row < 2; row++)
        {
            var newPositionRow = positionToCheck.Row + row;
            if (newPositionRow < 0 || newPositionRow == map.NumberOfRows)
            {
                continue;
            }

            for (int column = -1; column < 2; column++)
            {
                if (row == 0 && column == 0)
                {
                    continue;
                }

                var newPositionColumn = positionToCheck.Column + column;
                if (newPositionColumn < 0 || newPositionColumn == map.NumberOfColumns)
                {
                    continue;
                }

                adjacentPositions.Add(new Position(newPositionRow, newPositionColumn));
            }
        }

        return adjacentPositions;
    }

    public static uint CountAdjacentRollsOfPaper(Map map, List<Position> positionsToCheck)
    {
        var numberOfRollsOfPaper = 0u;

        foreach (var position in positionsToCheck) 
        {
            if (map.Fields[position.Row, position.Column].IsRollOfPaper)
            {
                numberOfRollsOfPaper++;
            }
        }

        return numberOfRollsOfPaper;
    }
}
