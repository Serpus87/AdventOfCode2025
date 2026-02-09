using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day12;

public static class Part1
{
    public static ulong Solve(List<Tree> trees, List<Present> presents)
    {
        var result = 0u;

        foreach (var tree in trees)
        {
            var relevantPresents = new List<Present>();
            var allShapesId = 0; 
            foreach (var presentId in tree.RequiredPresentIds) 
            {
                var relevantPresent = presents.First(x=>x.Id == presentId).Clone(allShapesId);
                relevantPresents.Add(relevantPresent);
                allShapesId++;
            }

            var canTreeFitAllPresents = TreeService.CanPresentsFit(tree, relevantPresents);

            if (canTreeFitAllPresents)
            {
                result++;
            }
        }

        return result;
    }
}
