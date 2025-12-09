using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day7;

public static class Part1
{
    public static int Solve(Map map)
    {
        MapService.FireTachyons(map);

        var result = map.FieldsList.Count(x=>x.HasSplittedBeam);

        return result;
    }
}
