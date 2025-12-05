using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5;

public static class Part2
{
    public static ulong Solve(Input input)
    {
        var nonOverlappingIdPairs = IdService.CreateNonOverlappingIdPairs(input.IdPairs);

        var freshIdCount = CountFreshIds(nonOverlappingIdPairs);

        return freshIdCount;
    }

    private static ulong CountFreshIds(List<IdPair> nonOverlappingIdPairs)
    {
        var count = 0ul;

        foreach (var idPair in nonOverlappingIdPairs)
        {
            count += idPair.Id2 - idPair.Id1 + 1;
        }

        return count;
    }
}
