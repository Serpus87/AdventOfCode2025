using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day10;

public static class MachineService
{
    // just to get the ball rolling
    public static ulong GetFewestButtonPressesWithTooManyForLoops(Machine machine)
    {
        var fewestButtonPresses = 0ul;
        var numberOfButtonPressesNecessary = new List<ulong>();

        var numberOfButtons = machine.ButtonWiringSchematics.Count;
        var startState = machine.IndicatorLightDiagram.CreateStartState();
        var visitedStates = new List<List<bool>> { startState };


        for (var i = 0; i< numberOfButtons; i++) 
        {
            var level1StartState = startState.Clone();
            var stateToPressButton = level1StartState.Clone();

            // press button
            stateToPressButton.PressButton(machine.ButtonWiringSchematics[i]);

            // check answer
            if (stateToPressButton.SequenceEqual(machine.IndicatorLightDiagram))
            {
                numberOfButtonPressesNecessary.Add(1);
                break;
            }

            // check if current state has already been achieved
            if (visitedStates.Contains(stateToPressButton))
            {
                break; // maybe continue?
            }

            // add to visitedStates
            visitedStates.Add(stateToPressButton);

            // check if possible to go deeper
            if (machine.IndicatorLightDiagram.Count < 2)
            {
                continue;
            }

            for (var j = 0; j < numberOfButtons; j++)
            {
                if (j == i)
                {
                    continue;
                }

                // press button

                // check if current state has already been achieved

                // check answer

                // check if possible to go deeper

                for (var k = 0; k < numberOfButtons; k++)
                {
                    if (k == j)
                    {
                        continue;
                    }

                    for (var l = 0; l < numberOfButtons; l++)
                    {
                        if (l == k)
                        {
                            continue;
                        }

                        for (var m = 0; m < numberOfButtons; m++) 
                        {
                            if (m == l)
                            {
                                continue;
                            }

                            for (var n = 0; n < numberOfButtons; n++) 
                            {
                                if (n == m)
                                {
                                    continue;
                                }

                                for (var o = 0; o < numberOfButtons; o++) 
                                {
                                    if (o == n)
                                    {
                                        continue;
                                    }

                                    for (var p = 0; p < numberOfButtons; p++) 
                                    {
                                        if (p == o)
                                        {
                                            continue;
                                        }

                                        for (var q = 0; q < numberOfButtons; q++) 
                                        {
                                            if (q == p)
                                            {
                                                continue;
                                            }

                                            for (var r = 0; r < numberOfButtons; r++) 
                                            {
                                                if (r == q)
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (numberOfButtonPressesNecessary.Count > 0)
        {
            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
        }

        return fewestButtonPresses;
    }

    private static void PressButton(this List<bool> lights, ButtonWiringSchematic buttonWiringSchematic)
    {
        foreach(var buttonWiring in buttonWiringSchematic.ButtonWirings)
        {
            if (lights[(int)buttonWiring] == true)
            {
                lights[(int)buttonWiring] = false;
            }
            if (lights[(int)buttonWiring] == false)
            {
                lights[(int)buttonWiring] = true;
            }
        }
    }

    private static List<bool> Clone(this List<bool> original)
    {
        var clone = new List<bool>();

        foreach (var light in original)
        {
            clone.Add(light);
        }

        return clone;
    }

    private static List<bool> CreateStartState(this List<bool> original)
    {
        var startState = new List<bool>();

        foreach (var light in original)
        {
            startState.Add(false);
        }

        return startState;
    }
}
