using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5;

public static class InputReader
{
    public static Input GetInput(string fileName)
    {
        var lines = File.ReadAllLines($"Day5\\{fileName}");

        var idPairs = new List<IdPair>();
        var ingredients = new List<ulong>();

        var hasWhiteLineBeenEncountered = false;
        foreach ( var line in lines)
        {
            if (line.Length == 0)
            {
                hasWhiteLineBeenEncountered = true;
                continue;
            }

            if (!hasWhiteLineBeenEncountered)
            {
                var idPairsList = line.Split("-").Select(ulong.Parse).ToList();
                var idPair = new IdPair(idPairsList.First(), idPairsList.Last());
                idPairs.Add(idPair);
                continue;
            }
            
            ingredients.Add(ulong.Parse(line));
        }

        return new Input(idPairs,ingredients);
    }
}
