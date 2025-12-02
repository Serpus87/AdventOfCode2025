using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day2;

public static class Part2
{
    public static ulong Solve(List<IdPair> idPairs)
    {
        var sumInValidIds = 0ul;
        var invalidIds = new List<uint>();

        foreach (var idPair in idPairs)
        {
            for (ulong id = idPair.Id1; id <= idPair.Id2; id++)
            {
                var idString = id.ToString();
                var idLength = idString.Length;

                if (idLength < 2) // todo filter these before the loop;
                {
                    continue;
                }

                // get splittable lengths
                var splittableLengths = idLength.GetSplittableLengths().OrderDescending();

                // loop through splittable lengths
                var idIsInvalid = true;
                foreach (var splittableLength in splittableLengths)
                {
                    // get splittedIds
                    var idToMatch = ulong.Parse(idString.Substring(0, splittableLength));

                    var stringToCheck = idString.Substring(splittableLength);

                    if (stringToCheck.Length != ulong.Parse(stringToCheck).ToString().Length)
                    {
                        continue;
                    }

                    idIsInvalid = true;
                    while (stringToCheck.Length > 0)
                    {
                        var idToCheck = ulong.Parse(stringToCheck.Substring(0, splittableLength));
                        if (idToCheck != idToMatch)
                        {
                            idIsInvalid = false;
                            break;
                        }

                        stringToCheck = stringToCheck.Substring(splittableLength);
                    }

                    // if all splittedIds are equal add id to invalidIds and continue
                    if (idIsInvalid)
                    {
                        sumInValidIds += id;
                        break;
                    }

                }
            }
        }
        // return sum
        return sumInValidIds;
    }

    private static List<int> GetSplittableLengths(this int lengthToCheck) // todo move to extensions class OR make public for testing
    {
        var splittableLengths = new List<int> { 1 };

        if (lengthToCheck == 2)
        {
            return splittableLengths;
        }

        for (int i = 2; i <= (lengthToCheck / 2); i++)
        {
            if (lengthToCheck % i == 0)
            {
                splittableLengths.Add(i);
            }
        }

        return splittableLengths;
    }
}
