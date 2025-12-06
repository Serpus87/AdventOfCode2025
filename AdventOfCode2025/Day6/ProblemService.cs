using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day6;

public static class ProblemService
{
    public static ulong SolveProblem(Problem problem)
    {
        var solution = problem.Numbers.First();

        var numbersToApplyOperatorOn = problem.Numbers.Skip(1);

        foreach (var number in numbersToApplyOperatorOn)
        {
            solution = ApplyOperator(solution, number, problem.Operator);
        }

        return solution;
    }

    public static void GetNumbersFromFields(Problem problem)
    {
        var maxColumn = problem.FieldsList.Select(x=>x.Position).Max(y=>y.Column);
        var minColumn = problem.FieldsList.Select(x=>x.Position).Min(y=>y.Column);

        for (var column = maxColumn; column >= minColumn; column--)
        {
            var numberString = "";

            var minRow = problem.FieldsList.Select(x=>x.Position).Where(y=>y.Column == column).Min(z=>z.Row);
            var maxRow = problem.FieldsList.Select(x=>x.Position).Where(y=>y.Column == column).Max(z=>z.Row);
            for (int row = minRow; row <= maxRow; row++)
            {
                numberString += problem.FieldsList.Single(x => x.Position.Column == column && x.Position.Row == row).Fill.ToString();
            }

            problem.Numbers.Add(ulong.Parse(numberString));
        }
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
