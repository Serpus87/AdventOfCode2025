using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day2;

public static class IdService
{
    public static List<uint> GetIdRange(IdPair idPair)
    {
        var idRange = new List<uint>();

        var temp = Enumerable.Range((int)idPair.Id1, (int)idPair.Id2);

        return idRange;
    }

    public static uint IdentifyInvalidIds(List<IdPair> idPairs)
    {
        // get id range

        // loop through range

        // for each id in loop, check if invalid
        // if invalid then add to list of invalidIds

        // sum invalid Ids

        // return sum

        return 0;
    }
}
