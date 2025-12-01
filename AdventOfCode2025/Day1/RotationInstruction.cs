using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day1;

public class RotationInstruction
{
    public DirectionCode RotationDirection { get; init; }
    public uint NumberOfRotations { get; init; }

    public RotationInstruction(DirectionCode rotationDirection, uint numberOfRotations)
    {
        RotationDirection = rotationDirection;
        NumberOfRotations = numberOfRotations;
    }
}
