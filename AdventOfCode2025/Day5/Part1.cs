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
        // get nonoverlapping idPairs (not necessary, because fast enough)
        var nonOverlappingIdPairs = IdService.CreateNonOverlappingIdPairs(input.IdPairs);

        // check ingredients
        var freshIngredients = GetFreshIngredients(input.Ingredients, nonOverlappingIdPairs);
        //var freshIngredients = GetFreshIngredients(input.Ingredients, input.IdPairs);

        return freshIngredients.Count;
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
}
