using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day1;

public static class InputReader
{
    public static List<RotationInstruction> GetRotationInstructions(string fileName) {

        var rotationInstructions = new List<RotationInstruction>();
        string[] lines = File.ReadAllLines($"Day1\\{fileName}");

        foreach (var line in lines)
        {
            var directionChar = line.First();
            var directionCode = directionChar.ToDirectionCode();
            var numberOfDirectionsString = line.Substring(1);
            var numberOfDirections = uint.Parse(numberOfDirectionsString);

            rotationInstructions.Add(new RotationInstruction(directionCode, numberOfDirections));
        }

        return rotationInstructions;
    }
}
