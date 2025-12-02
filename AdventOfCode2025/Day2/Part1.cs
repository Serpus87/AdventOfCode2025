using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day2;

public static class Part1
{
    public static ulong Solve(List<IdPair> idPairs)
    {
        var sumInValidIds = 0ul;
        var invalidIds = new List<uint>();

        foreach (var idPair in idPairs)
        {
            for (ulong id = idPair.Id1; id <= idPair.Id2; id++)
            {
                var idString = id.ToString();
                var idLength = idString.Length; // todo skip if uneven

                if (idLength % 2 != 0)
                {
                    continue;
                }

                var halfIdLength = idLength / 2;
                var firstHalfId = ulong.Parse(idString.Substring(0, halfIdLength));
                var secondHalfId = ulong.Parse(idString.Substring(halfIdLength));

                if (firstHalfId == secondHalfId)
                {
                    //invalidIds.Add(firstHalfId);
                    sumInValidIds += id;
                }
            }
        }
        // return sum
        return sumInValidIds;
    }
}
