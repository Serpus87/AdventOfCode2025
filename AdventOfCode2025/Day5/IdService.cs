using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5;

public static class IdService
{
    public static List<IdPair> CreateNonOverlappingIdPairs(List<IdPair> idPairs) // this would optimize code; but seems unnecessary for part1; seems useful for part2 though
    {
        var nonOverlappingIdPairs = new List<IdPair>();

        foreach (var idPair in idPairs) 
        {
            var newPair = new IdPair(idPair.Id1,idPair.Id2);

            var id1OverlappingPair = nonOverlappingIdPairs.FirstOrDefault(x => x.Id1 <= idPair.Id1 && x.Id2 >= idPair.Id1);
            var id2OverlappingPair = nonOverlappingIdPairs.FirstOrDefault(x => x.Id1 <= idPair.Id2 && x.Id2 >= idPair.Id2);

            // if only Id1 overlaps, set id1 in newPair
            if (id1OverlappingPair != null && id2OverlappingPair == null)
            {
                newPair.Id1 = id1OverlappingPair.Id1;
            }

            // if only Id2 overlaps, set id2 in newPair
            if (id1OverlappingPair == null && id2OverlappingPair != null)
            {
                newPair.Id2 = id2OverlappingPair.Id2;
            }

            // if both Id1 and Id2 overlap, set Id1 and Id2 in newPair
            if (id1OverlappingPair != null && id2OverlappingPair != null)
            {
                //newPair = new IdPair(id1OverlappingPair.Id1, id2OverlappingPair.Id2);
                newPair.Id1 = id1OverlappingPair.Id1;
                newPair.Id2 = id2OverlappingPair.Id2;
            }

            // remove all overlapping idPairs
            nonOverlappingIdPairs.RemoveAll(x => x.Id1 >= newPair.Id1 && x.Id2 <= newPair.Id2);
            nonOverlappingIdPairs.Add(newPair);
        }

        return nonOverlappingIdPairs;
    }
}
