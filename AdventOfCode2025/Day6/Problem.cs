using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day6;

public class Problem
{
    public int Id { get; init; }
    public List<ulong> Numbers { get; set; } = new List<ulong>();
    public char Operator { get; set; }
    public List<Field> FieldsList { get; set; } = new List<Field>();
    public Problem(int id)
    {
        Id = id;
    }
}
