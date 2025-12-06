using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day4;

public class Map
{
    public int NumberOfRows { get; set; }
    public int NumberOfColumns { get; set; }
    public Field[,] Fields { get; set; }
    public List<Field> FieldsList { get; set; } = new List<Field>();

    public Map(int numberOfRows, int numberOfColumns)
    {
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
        Fields = new Field[numberOfRows, numberOfColumns];
    }
}