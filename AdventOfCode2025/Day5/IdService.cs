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
        var nonOverlappingIdPairs = new List<IdPair> { idPairs.First() };

        foreach (var idPair in idPairs) 
        {
            var newPair = new IdPair(idPair.Id1,idPair.Id2);

            var id1OverlappingPair = nonOverlappingIdPairs.FirstOrDefault(x => x.Id1 <= idPair.Id1 && x.Id2 >= idPair.Id1);
            var id2OverlappingPair = nonOverlappingIdPairs.FirstOrDefault(x => x.Id1 <= idPair.Id2 && x.Id2 >= idPair.Id2);

            //// if idPair has no overlap, add
            //if (id1OverlappingPair == null && id2OverlappingPair == null)
            //{
            //    nonOverlappingIdPairs.Add(newPair);
            //    continue;
            //}

            // if only Id1 overlaps, set id2 in overlapping pair
            if (id1OverlappingPair != null && id2OverlappingPair == null)
            {
                //id1OverlappingPair.Id2 = idPair.Id2;
                newPair.Id1 = id1OverlappingPair.Id1;
                //nonOverlappingIdPairs.Add(newPair);
                //continue;
            }

            // if only Id2 overlaps, set id1 in overlapping pair
            if (id1OverlappingPair == null && id2OverlappingPair != null)
            {
                //id2OverlappingPair.Id1 = idPair.Id1;
                newPair.Id2 = id2OverlappingPair.Id2;
                //nonOverlappingIdPairs.Add(newPair);
                //continue;
            }

            // if both Id1 and Id2 overlap, remove 2 (and everything in between?) and replace with 1
            if (id1OverlappingPair != null && id2OverlappingPair != null)
            {
                newPair = new IdPair(id1OverlappingPair.Id1, id2OverlappingPair.Id2);
                //nonOverlappingIdPairs.RemoveAll(x => x.Id1 >= newPair.Id1 && x.Id2 <= newPair.Id2);
                //nonOverlappingIdPairs.Add(newPair);
                //continue;
            }

            //// if idPair overlaps existing pairs, remove them and add idPair
            //if (idPair.Id1 <= nonOverlappingIdPairs.Min(x => x.Id1) && idPair.Id2 >= nonOverlappingIdPairs.Max(x => x.Id2))
            //{
            //    nonOverlappingIdPairs.RemoveAll(x => x.Id1 >= idPair.Id1 || x.Id2 <= idPair.Id2);
            //    nonOverlappingIdPairs.Add(newPair);
            //    continue;

            nonOverlappingIdPairs.RemoveAll(x => x.Id1 >= newPair.Id1 && x.Id2 <= newPair.Id2);
            nonOverlappingIdPairs.Add(newPair);

          
        }

        // checks
        if (nonOverlappingIdPairs.Select(x=>x.Id1).Count() != nonOverlappingIdPairs.Select(x => x.Id1).Distinct().Count())
        {
            // wut?!?!
            var bla = true;
        }
        if (nonOverlappingIdPairs.Select(x => x.Id2).Count() != nonOverlappingIdPairs.Select(x => x.Id2).Distinct().Count())
        {
            var bla = true;
            // wut?!?!
        }
        // end

        return nonOverlappingIdPairs;
    }
}
