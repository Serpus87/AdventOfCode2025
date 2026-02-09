using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public static class InputReader
{
    public static Input GetTreesAndPresents(string fileName)
    {
        var presents = new List<Present>();
        var trees = new List<Tree>();

        string[] lines = File.ReadAllLines($"Day12\\{fileName}");

        foreach (var line in lines)
        {
            if (!line.Contains('x'))
            {

            }
        }

        return new Input(presents, trees);
    }
}
