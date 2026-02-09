using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public class Region
{
    public int NumberOfRows { get; init; }
    public int NumberOfColumns { get; init; }
    public RegionField[,] Fields { get; set; }
    public List<RegionField> FieldsList { get; set; } = new List<RegionField>();

    public Region(int numberOfRows, int numberOfColumns)
    {
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
        Fields = new RegionField[numberOfRows, numberOfColumns];
    }
}
