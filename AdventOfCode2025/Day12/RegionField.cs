using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public class RegionField // TODO abstract
{
    public AdventOfCode2025.Shared.Position Position { get; init; }
    public bool IsFilled { get; set; }
    public int AllPresentsId { get; set; }
    public string Fill {  get; set; } 

    public RegionField(AdventOfCode2025.Shared.Position position, string fill)
    {
        Position = position;
        Fill = ".";
    }
}
