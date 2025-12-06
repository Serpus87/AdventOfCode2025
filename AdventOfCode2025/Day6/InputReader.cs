using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day5;

namespace AdventOfCode2025.Day6;

public static class InputReader
{
    public static List<Problem> GetProblems(string fileName)
    {
        var lines = File.ReadAllLines($"Day6\\{fileName}");
        var problems = new List<Problem>();

        var lineCounter = 0;
        foreach (var line in lines)
        {
            var lineStrings = line.Split(" ").ToList();
            lineStrings.RemoveAll(x => x.Length == 0);

            var lineStringCounter = 0;
            foreach (var lineString in lineStrings)
            {
                if (lineCounter == 0)
                {
                    problems.Add(new Problem(lineStringCounter));
                }

                var problem = problems.Single(x => x.Id == lineStringCounter);

                if (lineCounter < (lines.Length - 1))
                {
                    problem.Numbers.Add(ulong.Parse(lineString));
                }
                else
                {
                    problem.Operator = char.Parse(lineString);
                }

                lineStringCounter++;
            }

            lineCounter++;
        }

        return problems;
    }
}