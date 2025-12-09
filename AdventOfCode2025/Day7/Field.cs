using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day7;

public class Field // TODO make base class or interface and put in Shared
{
    public Position Position { get; init; }
    public bool HasSplittedBeam { get; set; } = false;
    public char Fill { get; set; }
    public ulong NumberOfTimeLines { get; set; } = 1ul;

    public Field(Position position, char fill)
    {
        Position = position;
        Fill = fill;
    }
}
