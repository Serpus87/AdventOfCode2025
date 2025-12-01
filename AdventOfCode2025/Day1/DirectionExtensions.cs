using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day1;

public static class DirectionExtensions
{
    public static DirectionCode ToDirectionCode(this char directionChar)
    {
        if (directionChar == 'L')
        {
            return DirectionCode.Left;
        }
        if (directionChar == 'R')
        {
            return DirectionCode.Right;
        }

        throw new ArgumentException($"DirectionChar '{directionChar}' cannot be mapped to DirectionCode");
    }
}
