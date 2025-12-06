using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day6;

public static class Part2
{
    public static ulong Solve(List<Problem> problems)
    {
        var grandTotal = 0ul;

        foreach (var problem in problems)
        {
            ProblemService.GetNumbersFromFields(problem);
            grandTotal += ProblemService.SolveProblem(problem);
        }

        return grandTotal;
    }
}
