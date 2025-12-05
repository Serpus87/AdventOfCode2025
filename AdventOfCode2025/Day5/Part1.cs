using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5;

public static class Part1
{
    public static int Solve(Input input)
    {
        // get list of fresh id's
        //var freshIds = GetFreshIds(input.IdPairs);

        // check ingredients
        var freshIngredients = GetFreshIngredients(input.Ingredients, input.IdPairs);

        return freshIngredients.Count;
    }

    private static List<IdPair> GetEffectiveIdPairs(IdPair idPair) // this would optimize code; but seems unnecessary
    {
        var effectiveIdPairs = new List<IdPair>();

        return effectiveIdPairs;
    }

    private static List<ulong> GetFreshIngredients(List<ulong> ingredients, List<IdPair> freshIdPairs)
    {
        var freshIngredients = new List<ulong>();

        foreach (var ingredient in ingredients)
        {
            if (freshIdPairs.Any(x=>x.Id1 <= ingredient && x.Id2 >= ingredient))
            {
                freshIngredients.Add(ingredient);
            }
        }

        return freshIngredients;
    }

    // Works - but is too slow
    private static List<ulong> GetFreshIngredients(List<ulong> ingredients, List<ulong> freshIds)
    {
        return ingredients.Where(x=>freshIds.Contains(x)).ToList();
    }

    // Works - but is too slow
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
