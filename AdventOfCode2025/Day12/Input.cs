using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public class Input
{
    public List<Present> Presents { get; set; }
    public List<Tree> Trees { get; set; }

    public Input(List<Present> presents, List<Tree> trees)
    {
        Presents = presents;
        Trees = trees;
    }
}
