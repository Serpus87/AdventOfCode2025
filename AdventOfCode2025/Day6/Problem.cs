using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day6;

public class Problem
{
    public int Id { get; init; }
    public List<ulong> Numbers { get; set; } = new List<ulong>();
    public char Operator { get; set; }

    public Problem(int id)
    {
        Id = id;
    }
}
