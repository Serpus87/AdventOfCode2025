using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Position = AdventOfCode2025.Shared.Position;

namespace AdventOfCode2025.Day7;

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

    public static void FireTachyons(Map map)
    {
        for (var row = 1; row < map.NumberOfRows; row++)
        {
            for (var column = 0; column < map.NumberOfColumns; column++)
            {
                if (map.Fields[row - 1, column].Fill == '.' || map.Fields[row - 1, column].Fill == '^')
                {
                    continue;
                }

                if (map.Fields[row, column].Fill == '.')
                {
                    map.Fields[row, column].Fill = '|';
                    continue;
                }

                if (map.Fields[row, column].Fill == '^')
                {
                    if (column > 0 && map.Fields[row, column - 1].Fill == '.')
                    {
                        map.Fields[row, column - 1].Fill = '|';
                        map.Fields[row, column].HasSplittedBeam = true;
                    }

                    if (column < map.NumberOfColumns && map.Fields[row, column + 1].Fill == '.')
                    {
                        map.Fields[row, column + 1].Fill = '|';
                        map.Fields[row, column].HasSplittedBeam = true;
                    }
                }
            }
        }
    }

    private static Map CreateNewTimeLine(Map originalTimeLineMap)
    {
        var numberOfRows = originalTimeLineMap.NumberOfRows;
        var numberOfColumns = originalTimeLineMap.NumberOfColumns;
        var newTimeLineMap = new Map(numberOfRows, numberOfColumns);
        newTimeLineMap.Fields = new Field[numberOfRows, numberOfColumns];
        newTimeLineMap.Fields.Clone(originalTimeLineMap.Fields, numberOfRows, numberOfColumns);
        newTimeLineMap.FieldsList = originalTimeLineMap.FieldsList.Clone();

        return newTimeLineMap;
    }

    private static void Clone(this Field[,] newTimeLineFields, Field[,] originalTimeLineFields, int numberOfRows, int numberOfColumns)
    {
        for (var row = 0; row < numberOfRows; row++)
        {
            for (var column = 0; column < numberOfColumns; column++)
            {
                var newTimeLineField = new Field(new Position(row, column), originalTimeLineFields[row, column].Fill);
                if (originalTimeLineFields[row, column].HasSplittedBeam)
                {
                    newTimeLineField.HasSplittedBeam = true;
                }
                newTimeLineFields[row, column] = newTimeLineField;
            }
        }
    }

    private static List<Field> Clone(this List<Field> originalTimeLineFieldsList)
    {
        var newTimeLineFieldsList = new List<Field>();

        foreach (var originalTimeLineField in originalTimeLineFieldsList)
        {
            var newTimeLineField = new Field(new Position(originalTimeLineField.Position.Row, originalTimeLineField.Position.Column), originalTimeLineField.Fill);
            if (originalTimeLineField.HasSplittedBeam)
            {
                newTimeLineField.HasSplittedBeam = true;
            }

            newTimeLineFieldsList.Add(newTimeLineField);
        }

        return newTimeLineFieldsList;
    }
}
