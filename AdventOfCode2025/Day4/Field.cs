using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day4;

public class Field
{
    public Position Position { get; init; }
    public bool IsRollOfPaper { get; set; }
    public char Fill { get; init; }

    public Field(Position position, char fill)
    {
        Position = position;
        Fill = fill;
        IsRollOfPaper = fill == '@';
    }
}
