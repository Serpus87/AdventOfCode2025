using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day7;

public static class Part2
{
    public static ulong Solve(Map map)
    {
        MapService.FireTachyonsWithTimeLines(map);

        var result = map.NumberOfTimeLines;

        var timeLines = map.FieldsList.Where(x => x.Position.Row == map.NumberOfRows - 1 && x.Fill == '|');

        foreach ( var line in timeLines)
        {
            result += line.NumberOfTimeLines;
        }

        return result;
    }
}
