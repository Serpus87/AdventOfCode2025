using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5;

public static class IdService
{
    public static List<IdPair> CreateNonOverlappingIdPairs(List<IdPair> idPairs) 
    {
        var nonOverlappingIdPairs = new List<IdPair>();

        foreach (var idPair in idPairs) 
        {
            var newPair = new IdPair(idPair.Id1,idPair.Id2);

            var id1OverlappingPair = nonOverlappingIdPairs.FirstOrDefault(x => x.Id1 <= idPair.Id1 && x.Id2 >= idPair.Id1);
            var id2OverlappingPair = nonOverlappingIdPairs.FirstOrDefault(x => x.Id1 <= idPair.Id2 && x.Id2 >= idPair.Id2);

            // if Id1 overlaps, set id1 in newPair
            if (id1OverlappingPair != null)
            {
                newPair.Id1 = id1OverlappingPair.Id1;
            }

            // if Id2 overlaps, set id2 in newPair
            if (id2OverlappingPair != null)
            {
                newPair.Id2 = id2OverlappingPair.Id2;
            }

            // remove all overlapping idPairs
            nonOverlappingIdPairs.RemoveAll(x => x.Id1 >= newPair.Id1 && x.Id2 <= newPair.Id2);
            nonOverlappingIdPairs.Add(newPair);
        }

        return nonOverlappingIdPairs;
    }
}
