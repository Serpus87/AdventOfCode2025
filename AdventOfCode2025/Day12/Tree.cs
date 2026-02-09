using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public class Tree
{
    public Region Region { get; set; }
    public List<int> RequiredPresentIds { get; set; }
    public List<Present> Presents { get; set; }
}
