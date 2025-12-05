using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day5
{
    public class Input
    {
        public List<IdPair> IdPairs { get; set; }
        public List<ulong> Ingredients { get; set; }

        public Input(List<IdPair> idPairs, List<ulong> ingredients)
        {
            IdPairs = idPairs;
            Ingredients = ingredients;
        }
    }
}
