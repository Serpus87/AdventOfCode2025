using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day10;

public static class InputReader
{
    public static List<Machine> GetMachines(string[] lines)
    {
        var machines = new List<Machine>();

        foreach (var line in lines)
        {
            var strings = line.Split(" ");

            var indicatorLightdiagram = GetIndicatorLightDiagram(strings[0]);
            var joltageRequirements = GetJoltageRequirements(strings[strings.Length - 1]);
            var buttonWiringSchematics = new List<ButtonWiringSchematic>();

            for (int i = 1; i < (strings.Length-1); i++) 
            {
                var buttonWiringSchematic = GetButtonWiringSchematic(strings[i]);
                buttonWiringSchematics.Add(buttonWiringSchematic);
            }

            machines.Add(new Machine(indicatorLightdiagram,buttonWiringSchematics,joltageRequirements));
        }

        return machines;
    }

    private static List<bool> GetIndicatorLightDiagram(string indicatorLightDiagramString)
    {
        var indicatorLightDiagram = new List<bool>();

        foreach (var character in indicatorLightDiagramString)
        {
            if (character == '[' || character == ']')
            {
                continue;
            }

            if(character == '.')
            {
                indicatorLightDiagram.Add(false);
            }
            else
            {
                indicatorLightDiagram.Add(true);
            }
        }

        return indicatorLightDiagram;
    }

    private static List<uint> GetJoltageRequirements(string joltageRequirementsString)
    {
        var joltageRequirements = new List<uint>();

        var cleanStrings = joltageRequirementsString.Replace("{","").Replace("}","").Split(",");

        foreach (var cleanString in cleanStrings)
        {
            joltageRequirements.Add(uint.Parse(cleanString));
        }

        return joltageRequirements;
    }

    private static ButtonWiringSchematic GetButtonWiringSchematic(string buttonWiringSchematicString)
    {
        var buttonWirings = new List<uint>();

        var cleanStrings = buttonWiringSchematicString.Replace("(", "").Replace(")", "").Split(",");

        foreach (var cleanString in cleanStrings)
        {
            buttonWirings.Add(uint.Parse(cleanString));
        }

        return new ButtonWiringSchematic(buttonWirings);
    }
}
