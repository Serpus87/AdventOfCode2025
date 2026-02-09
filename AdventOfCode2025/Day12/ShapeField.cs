using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public class PresentField // TODO abstract
{
    public AdventOfCode2025.Shared.Position Position { get; init; }
    public bool IsPartOfPresent { get; init; }
    public char Fill { get; init; }

    public PresentField(AdventOfCode2025.Shared.Position position, char fill)
    {
        Position = position;
        Fill = fill;
        IsPartOfPresent = fill == '@';
    }
}
