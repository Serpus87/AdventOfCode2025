//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AdventOfCode2025.Day5;

//namespace AdventOfCode2025.Day7;

//public static class InputReader
//{
//    public static List<Problem> GetProblems(string fileName)
//    {
//        var lines = File.ReadAllLines($"Day6\\{fileName}");
//        var problems = new List<Problem>();

//        var lineCounter = 0;
//        foreach (var line in lines)
//        {
//            var lineStrings = line.Split(" ").ToList();
//            lineStrings.RemoveAll(x => x.Length == 0);

//            var lineStringCounter = 0;
//            foreach (var lineString in lineStrings)
//            {
//                if (lineCounter == 0)
//                {
//                    problems.Add(new Problem(lineStringCounter));
//                }

//                var problem = problems.Single(x => x.Id == lineStringCounter);

//                if (lineCounter < (lines.Length - 1))
//                {
//                    problem.Numbers.Add(ulong.Parse(lineString));
//                }
//                else
//                {
//                    problem.Operator = char.Parse(lineString);
//                }

//                lineStringCounter++;
//            }

//            lineCounter++;
//        }

//        return problems;
//    }

//    public static List<Problem> GetProblemsWithFields(string fileName)
//    {
//        var lines = File.ReadAllLines($"Day6\\{fileName}");
//        var problems = new List<Problem>();

//        var id = 0;
//        var lineCounter = 0;
//        foreach (var line in lines)
//        {
//            var characters = line.ToCharArray();

//            var numberHasEnded = false;
//            var numberHasStarted = false;
//            var column = 0;
//            var charCounter = 0;
//            foreach (var character in characters)
//            {
//                numberHasStarted = true;
//                if (charCounter == 0)
//                {
//                    id = 1;
//                    column = 0;

//                    if (lineCounter == 0)
//                    {
//                        problems.Add(new Problem(id));
//                    }
//                }
//                if (charCounter > 0 && character == ' ' && characters[charCounter - 1] != ' ')
//                {
//                    numberHasEnded = true;
//                    numberHasStarted = false;
//                }
//                if (numberHasEnded)
//                {
//                    numberHasEnded = false;
//                    id++;
//                    column = 0;

//                    if (lineCounter == 0)
//                    {
//                        problems.Add(new Problem(id));
//                    }
//                }

//                if (character != ' ')
//                {
//                    var problem = problems.Single(x => x.Id == id);
//                    if (lineCounter < (lines.Length - 1))
//                    {
//                        problem.FieldsList.Add(new Shared.Field(new Shared.Position(lineCounter, charCounter), character));
//                    }
//                    else
//                    {
//                        problem.Operator = character;
//                    }
//                }

//                column++;
//                charCounter++;
//            }

//            lineCounter++;
//        }

//        problems.RemoveAll(x => x.FieldsList.Count == 0);

//        return problems;
//    }
//}