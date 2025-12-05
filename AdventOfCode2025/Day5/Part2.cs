using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5;

public static class Part2
{
    public static int Solve(Input input)
    {
        var freshIds = GetFreshIds(input.IdPairs);

        return freshIds.Count;
    }

    private static List<ulong> GetFreshIds(List<IdPair> idPairs)
    {
        var freshIds = new List<ulong>();

        foreach (var idPair in idPairs)
        {
            for (ulong id = idPair.Id1; id <= idPair.Id2; id++)
            {
                freshIds.Add(id);
            }
        }

        return freshIds.Distinct().ToList();
    }
}
