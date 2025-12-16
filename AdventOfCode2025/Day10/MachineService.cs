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
        var stringKey = string.Join("", startState);
        var visitedStateDictionary = new Dictionary<string, uint>
        {
            { stringKey, 0 }
        };

        //PrintStateForDebug(startState);

        for (var i = 0; i < numberOfButtons; i++)
        {
            var level1StartState = startState.Clone();
            var level1EndState = level1StartState.Clone();

            // press button
            level1EndState.PressButton(machine.ButtonWiringSchematics[i]);
            stringKey = string.Join("", level1EndState);
            //PrintStateForDebug(level1EndState);

            // check answer
            if (level1EndState.SequenceEqual(machine.IndicatorLightDiagram))
            {
                numberOfButtonPressesNecessary.Add(1);
                fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                break; // but maybe continue?
            }

            // check if current state has already been achieved
            if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
            {
                if (visitedStateDictionary[stringKey] > 1)
                {
                    visitedStateDictionary[stringKey] = 1;
                }
                else
                {
                    continue; // maybe break?
                }
            }
            else
            {
                visitedStateDictionary.Add(stringKey, 1);
            }

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
                stringKey = string.Join("", level2EndState);
                //PrintStateForDebug(level2EndState);

                // check answer
                if (level2EndState.SequenceEqual(machine.IndicatorLightDiagram))
                {
                    numberOfButtonPressesNecessary.Add(2);
                    fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                    break; // but maybe continue?
                }

                // check if current state has already been achieved
                if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                {
                    if (visitedStateDictionary[stringKey] > 2)
                    {
                        visitedStateDictionary[stringKey] = 2;
                    }
                    else
                    {
                        continue; // maybe break?
                    }
                }
                else
                {
                    visitedStateDictionary.Add(stringKey, 2);
                }

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
                    stringKey = string.Join("", level3EndState);
                    //PrintStateForDebug(level3EndState);

                    // check answer
                    if (level3EndState.SequenceEqual(machine.IndicatorLightDiagram))
                    {
                        numberOfButtonPressesNecessary.Add(3);
                        fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                        break; // but maybe continue?
                    }

                    // check if current state has already been achieved
                    if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                    {
                        if (visitedStateDictionary[stringKey] > 3)
                        {
                            visitedStateDictionary[stringKey] = 3;
                        }
                        else
                        {
                            continue; // maybe break?
                        }
                    }
                    else
                    {
                        visitedStateDictionary.Add(stringKey, 3);
                    }

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
                        level4EndState.PressButton(machine.ButtonWiringSchematics[l]);
                        stringKey = string.Join("", level4EndState);
                        //PrintStateForDebug(level4EndState);

                        // check answer
                        if (level4EndState.SequenceEqual(machine.IndicatorLightDiagram))
                        {
                            numberOfButtonPressesNecessary.Add(4);
                            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                            break; // but maybe continue?
                        }

                        // check if current state has already been achieved
                        if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                        {
                            if (visitedStateDictionary[stringKey] > 4)
                            {
                                visitedStateDictionary[stringKey] = 4;
                            }
                            else
                            {
                                continue; // maybe break?
                            }
                        }
                        else
                        {
                            visitedStateDictionary.Add(stringKey, 4);
                        }

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
                            level5EndState.PressButton(machine.ButtonWiringSchematics[m]);
                            stringKey = string.Join("", level5EndState);
                            //PrintStateForDebug(level5EndState);

                            // check answer
                            if (level5EndState.SequenceEqual(machine.IndicatorLightDiagram))
                            {
                                numberOfButtonPressesNecessary.Add(5);
                                fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                break; // but maybe continue?
                            }

                            // check if current state has already been achieved
                            if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                            {
                                if (visitedStateDictionary[stringKey] > 5)
                                {
                                    visitedStateDictionary[stringKey] = 5;
                                }
                                else
                                {
                                    continue; // maybe break?
                                }
                            }
                            else
                            {
                                visitedStateDictionary.Add(stringKey, 5);
                            }

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
                                level6EndState.PressButton(machine.ButtonWiringSchematics[n]);
                                stringKey = string.Join("", level6EndState);
                                //PrintStateForDebug(level6EndState);

                                // check answer
                                if (level6EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                {
                                    numberOfButtonPressesNecessary.Add(6);
                                    fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                    break; // but maybe continue?
                                }

                                // check if current state has already been achieved
                                if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                                {
                                    if (visitedStateDictionary[stringKey] > 6)
                                    {
                                        visitedStateDictionary[stringKey] = 6;
                                    }
                                    else
                                    {
                                        continue; // maybe break?
                                    }
                                }
                                else
                                {
                                    visitedStateDictionary.Add(stringKey, 6);
                                }

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
                                    level7EndState.PressButton(machine.ButtonWiringSchematics[o]);
                                    stringKey = string.Join("", level7EndState);
                                    //PrintStateForDebug(level7EndState);

                                    // check answer
                                    if (level7EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                    {
                                        numberOfButtonPressesNecessary.Add(7);
                                        fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                        break; // but maybe continue?
                                    }

                                    // check if current state has already been achieved
                                    if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                                    {
                                        if (visitedStateDictionary[stringKey] > 7)
                                        {
                                            visitedStateDictionary[stringKey] = 7;
                                        }
                                        else
                                        {
                                            continue; // maybe break?
                                        }
                                    }
                                    else
                                    {
                                        visitedStateDictionary.Add(stringKey, 7);
                                    }

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
                                        level8EndState.PressButton(machine.ButtonWiringSchematics[p]);
                                        stringKey = string.Join("", level8EndState);
                                        //PrintStateForDebug(level8EndState);

                                        // check answer
                                        if (level8EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                        {
                                            numberOfButtonPressesNecessary.Add(8);
                                            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                            break; // but maybe continue?
                                        }

                                        // check if current state has already been achieved
                                        if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                                        {
                                            if (visitedStateDictionary[stringKey] > 8)
                                            {
                                                visitedStateDictionary[stringKey] = 8;
                                            }
                                            else
                                            {
                                                continue; // maybe break?
                                            }
                                        }
                                        else
                                        {
                                            visitedStateDictionary.Add(stringKey, 8);
                                        }

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
                                            level9EndState.PressButton(machine.ButtonWiringSchematics[q]);
                                            stringKey = string.Join("", level9EndState);
                                            //PrintStateForDebug(level9EndState);

                                            // check answer
                                            if (level9EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                            {
                                                numberOfButtonPressesNecessary.Add(9);
                                                fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                                break; // but maybe continue?
                                            }

                                            // check if current state has already been achieved
                                            if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                                            {
                                                if (visitedStateDictionary[stringKey] > 9)
                                                {
                                                    visitedStateDictionary[stringKey] = 9;
                                                }
                                                else
                                                {
                                                    continue; // maybe break?
                                                }
                                            }
                                            else
                                            {
                                                visitedStateDictionary.Add(stringKey, 9);
                                            }

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
                                                level10EndState.PressButton(machine.ButtonWiringSchematics[r]);
                                                stringKey = string.Join("", level10EndState);
                                                //PrintStateForDebug(level10EndState);

                                                // check answer
                                                if (level10EndState.SequenceEqual(machine.IndicatorLightDiagram))
                                                {
                                                    numberOfButtonPressesNecessary.Add(10);
                                                    fewestButtonPresses = numberOfButtonPressesNecessary.Min();
                                                    break; // but maybe continue?
                                                }

                                                // check if current state has already been achieved
                                                if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
                                                {
                                                    if (visitedStateDictionary[stringKey] > 10)
                                                    {
                                                        visitedStateDictionary[stringKey] = 10;
                                                    }
                                                    else
                                                    {
                                                        continue; // maybe break?
                                                    }
                                                }
                                                else
                                                {
                                                    visitedStateDictionary.Add(stringKey, 10);
                                                }

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

    private static void PrintStateForDebug(List<bool> startState)
    {
        var stringToPrint = "";
        foreach (var lightOn in startState)
        {
            if (lightOn)
            {
                stringToPrint += "#";
            }
            else
            {
                stringToPrint += ".";
            }
        }

        Console.WriteLine(stringToPrint);
    }

    private static void PressButton(this List<bool> lights, ButtonWiringSchematic buttonWiringSchematic)
    {
        foreach (var buttonWiring in buttonWiringSchematic.ButtonWirings)
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

    private static string ConvertToStringKey(List<bool> lights)
    {
        return string.Join("", lights);
    }
}
