using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day12;

public class Present
{
    public int Id { get; init; }
    public int AllPresentsId { get; set; }
    public int NumberOfRows { get; init; }
    public int NumberOfColumns { get; init; }
    public PresentField[,] Fields { get; set; }
    public List<PresentField> FieldsList { get; set; } = new List<PresentField>();

    public Present(int id, int numberOfRows, int numberOfColumns)
    {
        Id = id;
        NumberOfRows = numberOfRows;
        NumberOfColumns = numberOfColumns;
        Fields = new PresentField[numberOfRows, numberOfColumns];
    }

    public Present Clone(int allPresentsId)
    {
        var clonedPresent = new Present(Id, NumberOfRows, NumberOfColumns);
        clonedPresent.AllPresentsId = allPresentsId;

        return clonedPresent;
    }

    public List<Present> GetVariants()
    {
        var variants = new List<Present> {Clone(AllPresentsId)};

        for (int i = 0; i < 3; i++)
        {
            var numberOfTimesToRotate = i + 1;
            var rotatedVariant = Rotate(numberOfTimesToRotate);

            if (true) // evaluate if new
            {
                variants.Add(rotatedVariant);
            }
        }

        foreach(var variant in variants)
        {
            var flippedVariant = variant.Flip();

            if (true) // evaluate if new
            {
                variants.Add(flippedVariant);
            }
        }

        return variants;
    }

    public Present Rotate(int numberOfTimesToRotate)
    {
        var clone = Clone(AllPresentsId);

        // do rotation x number of times

        return clone;
    }

    public Present Flip()
    {
        var clone = Clone(AllPresentsId);

        // flip

        return clone;
    }
}
