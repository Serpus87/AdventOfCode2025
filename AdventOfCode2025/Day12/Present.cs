using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public class Present
{
    public int Id { get; init; }
    public int AllPresentsId { get; set; }
    public int NumberOfRows { get; init; }
    public int NumberOfColumns { get; init; }
    public PresentField[,] Fields { get; set; }
    public List<PresentField> FieldsList { get; set; } = new List<PresentField>();

    public Present(int id, int numberOfRows, int numberOfColumns)
    {
        Id = id;
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
        Fields = new PresentField[numberOfRows, numberOfColumns];
    }

    public Present Clone(int allPresentsId)
    {
        var clonedPresent = new Present(Id, NumberOfRows, NumberOfColumns);
        clonedPresent.AllPresentsId = allPresentsId;

        return clonedPresent;
    }
}
