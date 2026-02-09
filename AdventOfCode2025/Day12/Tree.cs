using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public class Tree
{
    public Region Region { get; init; }
    public List<int> RequiredPresentIds { get; init; }
    public List<Present> Presents { get; set; } = new List<Present>();

    public Tree(Region region, List<int> requiredPresentIds)
    {
        Region = region;
        RequiredPresentIds = requiredPresentIds;
    }
}
