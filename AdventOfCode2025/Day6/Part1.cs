using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day6;

public static class Part1
{
    public static ulong Solve(List<Problem> problems)
    {
        var grandTotal = 0ul;

        foreach (var problem in problems)
        {
            grandTotal += SolveProblem(problem);
        }

        return grandTotal;
    }

    private static ulong SolveProblem(Problem problem)
    {
        var solution = problem.Numbers.First();

        var numbersToApplyOperatorOn = problem.Numbers.Skip(1);

        foreach (var number in numbersToApplyOperatorOn)
        {
            solution = ApplyOperator(solution, number, problem.Operator);
        }

        return solution;
    }

    private static ulong ApplyOperator(ulong solution, ulong number, char @operator)
    {
        if (@operator == '+') 
        {
            return solution + number;
        }
        if (@operator == '*')
        {
            return solution * number;
        }

        throw new ArgumentException($"Unknown operator '{@operator}'");
    }
}
