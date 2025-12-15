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
            var level1EndState = level1StartState.Clone();

            // press button
            level1EndState.PressButton(machine.ButtonWiringSchematics[i]);

            // check answer
            if (level1EndState.SequenceEqual(machine.IndicatorLightDiagram))
            {
                numberOfButtonPressesNecessary.Add(1);
                fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                break;
            }

            // check if current state has already been achieved
            if (visitedStates.Contains(level1EndState))
            {
                break; // maybe continue?
            }

            // add to visitedStates
            visitedStates.Add(level1EndState);

            // check if possible to go deeper
            if (machine.IndicatorLightDiagram.Count < 2 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 2))
            {
                continue;
            }

            for (var j = 0; j < numberOfButtons; j++)
            {
                if (j == i)
                {
                    continue;
                }

                var level2StartState = level1EndState.Clone();
                var level2EndState = level2StartState.Clone();

                // press button
                level2EndState.PressButton(machine.ButtonWiringSchematics[j]);

                // check answer
                if (level2EndState.SequenceEqual(machine.IndicatorLightDiagram))
                {
                    numberOfButtonPressesNecessary.Add(2);
                    fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                    break;
                }

                // check if current state has already been achieved
                if (visitedStates.Contains(level2EndState))
                {
                    break; // maybe continue?
                }

                // add to visitedStates
                visitedStates.Add(level2EndState);

                // check if possible to go deeper
                if (machine.IndicatorLightDiagram.Count < 3 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 3))
                {
                    continue;
                }

                for (var k = 0; k < numberOfButtons; k++)
                {
                    if (k == j)
                    {
                        continue;
                    }

                    var level3StartState = level2EndState.Clone();
                    var level3EndState = level3StartState.Clone();

                    // press button
                    level3EndState.PressButton(machine.ButtonWiringSchematics[k]);

                    // check answer
                    if (level3EndState.SequenceEqual(machine.IndicatorLightDiagram))
                    {
                        numberOfButtonPressesNecessary.Add(3);
                        fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                        break;
                    }

                    // check if current state has already been achieved
                    if (visitedStates.Contains(level3EndState))
                    {
                        break; // maybe continue?
                    }

                    // add to visitedStates
                    visitedStates.Add(level3EndState);

                    // check if possible to go deeper
                    if (machine.IndicatorLightDiagram.Count < 4 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 4))
                    {
                        continue;
                    }

                    for (var l = 0; l < numberOfButtons; l++)
                    {
                        if (l == k)
                        {
                            continue;
                        }

                        var level4StartState = level3EndState.Clone();
                        var level4EndState = level4StartState.Clone();

                        // press button
                        level4EndState.PressButton(machine.ButtonWiringSchematics[k]);

                        // check answer
                        if (level4EndState.SequenceEqual(machine.IndicatorLightDiagram))
                        {
                            numberOfButtonPressesNecessary.Add(4);
                            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                            break;
                        }

                        // check if current state has already been achieved
                        if (visitedStates.Contains(level4EndState))
                        {
                            break; // maybe continue?
                        }

                        // add to visitedStates
                        visitedStates.Add(level4EndState);

                        // check if possible to go deeper
                        if (machine.IndicatorLightDiagram.Count < 5 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 5))
                        {
                            continue;
                        }

                        for (var m = 0; m < numberOfButtons; m++)
                        {
                            if (m == l)
                            {
                                continue;
                            }

                            var level5StartState = level4EndState.Clone();
                            var level5EndState = level5StartState.Clone();

                            // press button
                            level5EndState.PressButton(machine.ButtonWiringSchematics[k]);

                            // check answer
                            if (level5EndState.SequenceEqual(machine.IndicatorLightDiagram))
                            {
                                numberOfButtonPressesNecessary.Add(5);
                                fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                break;
                            }

                            // check if current state has already been achieved
                            if (visitedStates.Contains(level5EndState))
                            {
                                break; // maybe continue?
                            }

                            // add to visitedStates
                            visitedStates.Add(level5EndState);

                            // check if possible to go deeper
                            if (machine.IndicatorLightDiagram.Count < 6 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 6))
                            {
                                continue;
                            }

                            for (var n = 0; n < numberOfButtons; n++)
                            {
                                if (n == m)
                                {
                                    continue;
                                }

                                var level6StartState = level5EndState.Clone();
                                var level6EndState = level6StartState.Clone();

                                // press button
                                level6EndState.PressButton(machine.ButtonWiringSchematics[k]);

                                // check answer
                                if (level6EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                {
                                    numberOfButtonPressesNecessary.Add(6);
                                    fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                    break;
                                }

                                // check if current state has already been achieved
                                if (visitedStates.Contains(level6EndState))
                                {
                                    break; // maybe continue?
                                }

                                // add to visitedStates
                                visitedStates.Add(level6EndState);

                                // check if possible to go deeper
                                if (machine.IndicatorLightDiagram.Count < 7 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 7))
                                {
                                    continue;
                                }

                                for (var o = 0; o < numberOfButtons; o++)
                                {
                                    if (o == n)
                                    {
                                        continue;
                                    }

                                    var level7StartState = level6EndState.Clone();
                                    var level7EndState = level7StartState.Clone();

                                    // press button
                                    level7EndState.PressButton(machine.ButtonWiringSchematics[k]);

                                    // check answer
                                    if (level7EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                    {
                                        numberOfButtonPressesNecessary.Add(7);
                                        fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                        break;
                                    }

                                    // check if current state has already been achieved
                                    if (visitedStates.Contains(level7EndState))
                                    {
                                        break; // maybe continue?
                                    }

                                    // add to visitedStates
                                    visitedStates.Add(level7EndState);

                                    // check if possible to go deeper
                                    if (machine.IndicatorLightDiagram.Count < 8 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 8))
                                    {
                                        continue;
                                    }

                                    for (var p = 0; p < numberOfButtons; p++)
                                    {
                                        if (p == o)
                                        {
                                            continue;
                                        }

                                        var level8StartState = level7EndState.Clone();
                                        var level8EndState = level8StartState.Clone();

                                        // press button
                                        level8EndState.PressButton(machine.ButtonWiringSchematics[k]);

                                        // check answer
                                        if (level8EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                        {
                                            numberOfButtonPressesNecessary.Add(8);
                                            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                            break;
                                        }

                                        // check if current state has already been achieved
                                        if (visitedStates.Contains(level8EndState))
                                        {
                                            break; // maybe continue?
                                        }

                                        // add to visitedStates
                                        visitedStates.Add(level8EndState);

                                        // check if possible to go deeper
                                        if (machine.IndicatorLightDiagram.Count < 9 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 9))
                                        {
                                            continue;
                                        }

                                        for (var q = 0; q < numberOfButtons; q++)
                                        {
                                            if (q == p)
                                            {
                                                continue;
                                            }

                                            var level9StartState = level8EndState.Clone();
                                            var level9EndState = level9StartState.Clone();

                                            // press button
                                            level9EndState.PressButton(machine.ButtonWiringSchematics[k]);

                                            // check answer
                                            if (level9EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                            {
                                                numberOfButtonPressesNecessary.Add(9);
                                                fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                                break;
                                            }

                                            // check if current state has already been achieved
                                            if (visitedStates.Contains(level9EndState))
                                            {
                                                break; // maybe continue?
                                            }

                                            // add to visitedStates
                                            visitedStates.Add(level9EndState);

                                            // check if possible to go deeper
                                            if (machine.IndicatorLightDiagram.Count < 10 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 10))
                                            {
                                                continue;
                                            }

                                            for (var r = 0; r < numberOfButtons; r++)
                                            {
                                                if (r == q)
                                                {
                                                    continue;
                                                }

                                                var level10StartState = level9EndState.Clone();
                                                var level10EndState = level10StartState.Clone();

                                                // press button
                                                level10EndState.PressButton(machine.ButtonWiringSchematics[k]);

                                                // check answer
                                                if (level10EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                                {
                                                    numberOfButtonPressesNecessary.Add(10);
                                                    fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                                    break;
                                                }

                                                // check if current state has already been achieved
                                                if (visitedStates.Contains(level10EndState))
                                                {
                                                    break; // maybe continue?
                                                }

                                                // add to visitedStates
                                                visitedStates.Add(level10EndState);

                                                // check if possible to go deeper
                                                if (machine.IndicatorLightDiagram.Count < 11 || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < 11))
                                                {
                                                    continue;
                                                }

                                                throw new ArgumentException("need to go deeper?!?!");
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
                continue;
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
