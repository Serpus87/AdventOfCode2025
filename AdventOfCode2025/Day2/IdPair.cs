using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day2;

public class IdPair
{
    public ulong Id1 { get; set; }
    public ulong Id2 { get; set; }

    public IdPair(ulong id1, ulong id2)
    {
        Id1 = id1;
        Id2 = id2;
    }
}
