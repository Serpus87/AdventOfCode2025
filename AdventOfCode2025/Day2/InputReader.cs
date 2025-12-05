using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day2;

public static class InputReader
{
    public static List<IdPair> GetIdPairs(string fileName) {

        var idPairs = new List<IdPair>();
 
        var input = File.ReadAllText($"Day2\\{fileName}");

        var idPairStrings = input.Split(',');

        foreach ( var idPairString in idPairStrings)
        {
            var idPairsList = idPairString.Split("-").Select(ulong.Parse).ToList();

            var idPair = new IdPair(idPairsList.First(), idPairsList.Last());
            idPairs.Add(idPair);
        }

        return idPairs;
    }
}
