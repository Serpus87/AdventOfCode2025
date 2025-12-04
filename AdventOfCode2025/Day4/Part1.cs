using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day4;

public static class Part1
{
    public static uint Solve(Map map)
    {
        var accessableRollsOfPaper = 0u;

        var rollsOfPaperPositions = map.FieldsList.Where(x=>x.IsRollOfPaper).Select(x=>x.Position);

        // foreach RollOfPaper check adjacent Fields
        foreach (var position in rollsOfPaperPositions)
        {
            var adjacentPositions = MapService.GetAdjacentPositions(map, position);
            var countAdjacentRollsOfPaper = MapService.CountAdjacentRollsOfPaper(map, adjacentPositions);

            if (countAdjacentRollsOfPaper < 4)
            {
                accessableRollsOfPaper++;
            }
        }

        return accessableRollsOfPaper;
    }
}
