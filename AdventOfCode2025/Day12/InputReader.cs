using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day12;

public static class InputReader
{
    public static Input GetTreesAndPresents(string fileName)
    {
        var presents = new List<Present>();
        var trees = new List<Tree>();

        string[] lines = File.ReadAllLines($"Day12\\{fileName}");

        var presentId = -1;
        var nrows = 0;
        var ncols = 0;
        var fieldsList = new List<PresentField>();
        foreach (var line in lines)
        {
            if (line.Length == 0)
            {
                var present = CreatePresent(presentId,fieldsList);
                presents.Add(present);

                nrows = 0;
                ncols = 0;
                fieldsList = new List<PresentField>();
                continue;
            }

            ncols = 0;
            if (!line.Contains('x'))
            {
                if (line.Contains(':'))
                {
                    presentId = int.Parse(line.Split(':')[0]);
                    continue;
                }

                foreach(var character in line)
                {
                    var position = new Position(nrows, ncols);

                    fieldsList.Add(new PresentField(position,character));
                    ncols++;
                }

                nrows++;
            }
        }

        return new Input(presents, trees);
    }

    private static Present CreatePresent(int presentId, List<PresentField> fieldsList) // TODO improve this by moving to class and simplifyS
    {
        var nrows = fieldsList.Select(x => x.Position).Max(x => x.Row) + 1;
        var ncols = fieldsList.Select(x => x.Position).Max(x => x.Column) + 1;

        var present = new Present(presentId, nrows, ncols);

        for (var row = 0; row < nrows; row++)
        {
            for (var column = 0; column < ncols; column++)
            {
                present.Fields[row, column] = fieldsList.Single(x=>x.Position.Row == row && x.Position.Column == column);
            }
        }

        present.FieldsList = fieldsList;

        return present;
    }
}
