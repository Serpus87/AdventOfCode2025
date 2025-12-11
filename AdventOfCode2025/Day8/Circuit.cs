using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day8;

public class Circuit
{
    public List<int> ConnectedBoxIds { get; set; } = new List<int>();

    public Circuit(List<int> connectedBoxIds)
    {
        ConnectedBoxIds = connectedBoxIds;
    }
}
