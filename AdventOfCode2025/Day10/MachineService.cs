using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


    public static ulong GetFewestButtonPressesWithRecursion(Machine machine)
    {
        var fewestButtonPresses = ulong.MaxValue;
        var numberOfButtonPressesNecessary = new List<ulong>();

        var numberOfButtons = machine.ButtonWiringSchematics.Count;
        var startState = machine.IndicatorLightDiagram.CreateStartState();
        var stringKey = string.Join("", startState);
        var visitedStateDictionary = new Dictionary<string, uint>
        {
            { stringKey, 0 }
        };

        fewestButtonPresses = GetFewestButtonPresses(machine, startState, numberOfButtonPressesNecessary, fewestButtonPresses, visitedStateDictionary, 0u);

        return fewestButtonPresses;

        //PrintStateForDebug(startState);


    }

    public static ulong GetFewestButtonPressesForJoltageRequirements(Machine machine)
    {
        var fewestButtonPresses = ulong.MaxValue;
        var numberOfButtonPressesNecessary = new List<ulong>();

        var numberOfButtons = machine.ButtonWiringSchematics.Count;
        var startState = machine.JoltageRequirements.CreateStartState();
        var stringKey = string.Join(",", startState);
        var visitedStateDictionary = new Dictionary<string, uint>
        {
            { stringKey, 0 }
        };

        //Console.WriteLine(stringKey);
        //fewestButtonPresses = GetFewestButtonPresses(machine, startState, numberOfButtonPressesNecessary, fewestButtonPresses, visitedStateDictionary, 0u);
        fewestButtonPresses = GetMachineFewestButtonPresses(machine, startState, numberOfButtonPressesNecessary, fewestButtonPresses, visitedStateDictionary, 0u);

        return fewestButtonPresses;
    }

    public static ulong GetFewestButtonPressesForJoltageRequirementsV2(Machine machine)
    {
        var fewestButtonPresses = ulong.MaxValue;
        var numberOfButtonPressesNecessary = new List<ulong>();

        var numberOfButtons = machine.ButtonWiringSchematics.Count;
        var startState = machine.JoltageRequirements.CreateStartState();
        var stringKey = string.Join(",", startState);
        var visitedStateDictionary = new Dictionary<string, uint>
        {
            { stringKey, 0 }
        };

        var visitedStringKeys = new List<string> { stringKey };

        //Console.WriteLine(stringKey);
        //fewestButtonPresses = GetMachineFewestButtonPressesV2(machine, startState, numberOfButtonPressesNecessary, fewestButtonPresses, visitedStateDictionary, 0u);
        //fewestButtonPresses = GetMachineFewestButtonPressesV3(machine, startState, numberOfButtonPressesNecessary, fewestButtonPresses, 0u, 0);
        fewestButtonPresses = GetMachineFewestButtonPressesWithoutRecursion(machine, startState, numberOfButtonPressesNecessary, fewestButtonPresses, 0u);

        return fewestButtonPresses;
    }

    private static ulong GetFewestButtonPresses(Machine machine, List<bool> startState, List<ulong> numberOfButtonPressesNecessary, ulong fewestButtonPresses, Dictionary<string, uint> visitedStateDictionary, uint recursionCounter)
    {
        recursionCounter++;
        var numberOfButtons = machine.ButtonWiringSchematics.Count;

        for (var i = 0; i < numberOfButtons; i++)
        {
            var levelStartState = startState.Clone();
            var levelEndState = levelStartState.Clone();

            // press button
            levelEndState.PressButton(machine.ButtonWiringSchematics[i]);
            var stringKey = string.Join("", levelEndState);
            //PrintStateForDebug(level1EndState);

            // check answer
            if (levelEndState.SequenceEqual(machine.IndicatorLightDiagram))
            {
                return recursionCounter;
            }

            // check if current state has already been achieved
            if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
            {
                if (visitedStateDictionary[stringKey] > recursionCounter)
                {
                    visitedStateDictionary[stringKey] = recursionCounter;
                }
                else
                {
                    continue; // maybe break?
                }
            }
            else
            {
                visitedStateDictionary.Add(stringKey, recursionCounter);
            }

            // check if possible to go deeper
            if (machine.IndicatorLightDiagram.Count < (recursionCounter + 1) || (numberOfButtonPressesNecessary.Count > 0 && fewestButtonPresses < (recursionCounter + 1)))
            {
                continue;
            }

            numberOfButtonPressesNecessary.Add(GetFewestButtonPresses(machine, levelEndState, numberOfButtonPressesNecessary, fewestButtonPresses, visitedStateDictionary, recursionCounter));
        }

        if (numberOfButtonPressesNecessary.Count > 0)
        {
            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
        }

        return fewestButtonPresses;
    }

    private static ulong GetFewestButtonPresses(Machine machine, List<uint> startState, List<ulong> numberOfButtonPressesNecessary, ulong fewestButtonPresses, Dictionary<string, uint> visitedStateDictionary, uint recursionCounter)
    {
        recursionCounter++;
        var numberOfButtons = machine.ButtonWiringSchematics.Count;

        for (var i = 0; i < numberOfButtons; i++)
        {
            var levelStartState = startState.Clone();
            var levelEndState = levelStartState.Clone();

            // press button
            levelEndState.PressButton(machine.ButtonWiringSchematics[i]);
            var stringKey = string.Join(",", levelEndState);
            //Console.WriteLine(stringKey);

            // check answer
            if (levelEndState.SequenceEqual(machine.JoltageRequirements))
            {
                return recursionCounter;
            }

            // check if current state has already been achieved
            if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
            {
                if (visitedStateDictionary[stringKey] > recursionCounter)
                {
                    visitedStateDictionary[stringKey] = recursionCounter;
                }
                else
                {
                    continue; // maybe break?
                }
            }
            else
            {
                visitedStateDictionary.Add(stringKey, recursionCounter);
            }

            // check if possible to go deeper
            if (levelEndState.AreAnyJoltageRequirementsTooBig(machine.JoltageRequirements))
            {
                continue;
            }

            numberOfButtonPressesNecessary.Add(GetFewestButtonPresses(machine, levelEndState, numberOfButtonPressesNecessary, fewestButtonPresses, visitedStateDictionary, recursionCounter));
        }

        if (numberOfButtonPressesNecessary.Count > 0)
        {
            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
        }

        return fewestButtonPresses;
    }

    // just to get the vball rolling
    private static ulong GetMachineFewestButtonPresses(Machine machine, List<uint> startState, List<ulong> numberOfButtonPressesNecessary, ulong fewestButtonPresses, Dictionary<string, uint> visitedStateDictionary, uint numberOfButtonsPressed)
    {
        var numberOfButtons = machine.ButtonWiringSchematics.Count;

        var levelStartState = startState.Clone();
        var levelEndState = levelStartState.Clone();

        for (var i = 0; i < numberOfButtons; i++)
        {
            // start with max button presses first button, then next, etc, until impossible then -1
            var buttonMaxPressesPossible = GetMaxButtonPressesPossible(machine.ButtonWiringSchematics[i], levelEndState, machine.JoltageRequirements);

            // press button
            levelEndState.PressButton(machine.ButtonWiringSchematics[0], buttonMaxPressesPossible);
            var stringKey = string.Join("", levelEndState);

            // check answer
            if (levelEndState.SequenceEqual(machine.JoltageRequirements))
            {
                return numberOfButtonsPressed + (uint)buttonMaxPressesPossible;
            }

            // check if current state has already been achieved
            if (visitedStateDictionary.Any(x => x.Key.Equals(stringKey)))
            {
                if (visitedStateDictionary[stringKey] > numberOfButtonsPressed)
                {
                    visitedStateDictionary[stringKey] = numberOfButtonsPressed;
                }
                else
                {
                    continue; // maybe break?
                }
            }
            else
            {
                visitedStateDictionary.Add(stringKey, numberOfButtonsPressed);
            }

            // use recursion to decrease the max button presses
            //numberOfButtonPressesNecessary.Add(GetFewestButtonPressesV2(machine, levelEndState, numberOfButtonPressesNecessary, fewestButtonPresses, visitedStateDictionary, numberOfButtonsPressed));
        }

        if (numberOfButtonPressesNecessary.Count > 0)
        {
            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
        }

        return fewestButtonPresses;
    }

    private static ulong GetMachineFewestButtonPressesV2(Machine machine, List<uint> startState, List<ulong> numberOfButtonPressesNecessary, ulong fewestButtonPresses, Dictionary<string, uint> visitedStateDictionary, uint numberOfButtonsPressed)
    {
        var numberOfButtons = machine.ButtonWiringSchematics.Count;

        var levelStartState = startState.Clone();
        var levelEndState = levelStartState.Clone();

        for (var i = 0; i < machine.JoltageRequirements.Count; i++)
        {
            var joltageRequirement = machine.JoltageRequirements[i];
            var relevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(i)).ToList();
            var buttonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(joltageRequirement, relevantButtons.Count);

            foreach (var buttonPressCombination in buttonPressCombinations)
            {
                for (int j = 0; j < relevantButtons.Count; j++)
                {
                    levelEndState.PressButton(relevantButtons[j], buttonPressCombination[j]);
                    Console.WriteLine(string.Join(",", levelEndState));
                }

                // check answer
                if (levelEndState.SequenceEqual(machine.JoltageRequirements))
                {
                    numberOfButtonPressesNecessary.Add(numberOfButtonsPressed + joltageRequirement);
                }

                // check if surpassed joltage reqs
                if (AreAnyJoltageRequirementsTooBig(levelEndState, machine.JoltageRequirements))
                {
                    continue;
                }

                // check if surpassed fewest button presses
            }
        }

        if (numberOfButtonPressesNecessary.Count > 0)
        {
            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
        }

        return fewestButtonPresses;
    }

    private static ulong GetMachineFewestButtonPressesV3(Machine machine, List<uint> startState, List<ulong> numberOfButtonPressesNecessary, ulong fewestButtonPresses, uint numberOfButtonsPressed, int i)
    {
        var levelStartState = startState.Clone();

        var joltageRequirement = machine.JoltageRequirements[i] - startState[i];
        var relevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(i)).ToList();
        var buttonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(joltageRequirement, relevantButtons.Count);

        foreach (var buttonPressCombination in buttonPressCombinations)
        {
            var levelEndState = levelStartState.Clone();

            for (int j = 0; j < relevantButtons.Count; j++)
            {
                levelEndState.PressButton(relevantButtons[j], buttonPressCombination[j]);
            }

            //Console.WriteLine(string.Join(",", levelEndState));

            // check answer
            if (levelEndState.SequenceEqual(machine.JoltageRequirements))
            {
                return numberOfButtonsPressed + joltageRequirement;
            }

            // check if surpassed joltage reqs OR recursion is impossible
            if (AreAnyJoltageRequirementsTooBig(levelEndState, machine.JoltageRequirements) || i == machine.JoltageRequirements.Count - 1)
            {
                continue;
            }

            // recurse forward
            var nextI = i + 1;
            var nextJoltageRequirementToMeet = machine.JoltageRequirements[nextI] - levelEndState[nextI];
            var nextRelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(nextI)).ToList();
            numberOfButtonPressesNecessary.Add(GetMachineFewestButtonPressesV3(machine, levelEndState, numberOfButtonPressesNecessary, fewestButtonPresses, numberOfButtonsPressed + joltageRequirement, nextI));
        }

        if (numberOfButtonPressesNecessary.Count > 0)
        {
            fewestButtonPresses = numberOfButtonPressesNecessary.Min();
            return fewestButtonPresses;
        }

        // recurse backward
        var previousI = i - 1;
        return GetMachineFewestButtonPressesV3(machine, startState, numberOfButtonPressesNecessary, fewestButtonPresses, numberOfButtonsPressed, previousI);
    }

    private static ulong GetMachineFewestButtonPressesWithoutRecursion(Machine machine, List<uint> startState, List<ulong> numberOfButtonPressesNecessary, ulong fewestButtonPresses, uint numberOfButtonsPressed)
    {
        var level1NumberOfButtonsPressed = numberOfButtonsPressed;
        var level1StartState = startState.Clone();
        var level1JoltageRequirement = machine.JoltageRequirements[0] - startState[0];
        //var level1RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(0)).ToList();
        var level1RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 0);
        var maxButtonsPresses = GetMaxButtonsPressesPossible(level1RelevantButtons, level1StartState, machine.JoltageRequirements,level1JoltageRequirement);
        var level1ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level1JoltageRequirement, maxButtonsPresses);

        foreach (var level1ButtonPressCombination in level1ButtonPressCombinations)
        {
            var level1EndState = level1StartState.Clone();

            for (int relevantButtonsCounter = 0; relevantButtonsCounter < level1RelevantButtons.Count; relevantButtonsCounter++)
            {
                level1EndState.PressButton(level1RelevantButtons[relevantButtonsCounter], level1ButtonPressCombination[relevantButtonsCounter]);
            }

            //Console.WriteLine(string.Join(",", level1EndState));

            // check answer
            if (level1EndState.SequenceEqual(machine.JoltageRequirements))
            {
                numberOfButtonPressesNecessary.Add(level1NumberOfButtonsPressed + level1JoltageRequirement);
            }

            // check if surpassed joltage reqs OR recursion is impossible
            if (AreAnyJoltageRequirementsTooBig(level1EndState, machine.JoltageRequirements) || 0 == machine.JoltageRequirements.Count - 1)
            {
                continue;
            }

            // go deeper
            var level2NumberOfButtonsPressed = level1NumberOfButtonsPressed + level1JoltageRequirement;
            var level2StartState = level1EndState.Clone();
            var level2JoltageRequirement = machine.JoltageRequirements[1] - level2StartState[1];
            //var level2RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(1)).ToList();
            var level2RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 1);
            maxButtonsPresses = GetMaxButtonsPressesPossible(level2RelevantButtons, level2StartState, machine.JoltageRequirements, level2JoltageRequirement);
            var level2ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level2JoltageRequirement, maxButtonsPresses);

            foreach (var level2ButtonPressCombination in level2ButtonPressCombinations)
            {
                var level2EndState = level2StartState.Clone();

                for (int relevantButtonsCounter = 0; relevantButtonsCounter < level2RelevantButtons.Count; relevantButtonsCounter++)
                {
                    level2EndState.PressButton(level2RelevantButtons[relevantButtonsCounter], level2ButtonPressCombination[relevantButtonsCounter]);
                }

                //Console.WriteLine(string.Join(",", level2EndState));

                // check answer
                if (level2EndState.SequenceEqual(machine.JoltageRequirements))
                {
                    numberOfButtonPressesNecessary.Add(level2NumberOfButtonsPressed + level2JoltageRequirement);
                }

                // check if surpassed joltage reqs OR recursion is impossible
                if (AreAnyJoltageRequirementsTooBig(level2EndState, machine.JoltageRequirements) || 1 == machine.JoltageRequirements.Count - 1)
                {
                    continue;
                }

                // go deeper
                var level3NumberOfButtonsPressed = level2NumberOfButtonsPressed + level2JoltageRequirement;
                var level3StartState = level2EndState.Clone();
                var level3JoltageRequirement = machine.JoltageRequirements[2] - level3StartState[2];
                //var level3RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(2)).ToList();
                var level3RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 2);
                maxButtonsPresses = GetMaxButtonsPressesPossible(level3RelevantButtons, level3StartState, machine.JoltageRequirements, level3JoltageRequirement);
                var level3ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level3JoltageRequirement, maxButtonsPresses);

                foreach (var level3ButtonPressCombination in level3ButtonPressCombinations)
                {
                    var level3EndState = level3StartState.Clone();

                    for (int relevantButtonsCounter = 0; relevantButtonsCounter < level3RelevantButtons.Count; relevantButtonsCounter++)
                    {
                        level3EndState.PressButton(level3RelevantButtons[relevantButtonsCounter], level3ButtonPressCombination[relevantButtonsCounter]);
                    }

                    //Console.WriteLine(string.Join(",", level3EndState));

                    // check answer
                    if (level3EndState.SequenceEqual(machine.JoltageRequirements))
                    {
                        numberOfButtonPressesNecessary.Add(level3NumberOfButtonsPressed + level3JoltageRequirement);
                    }

                    // check if surpassed joltage reqs OR recursion is impossible
                    if (AreAnyJoltageRequirementsTooBig(level3EndState, machine.JoltageRequirements) || 2 == machine.JoltageRequirements.Count - 1)
                    {
                        continue;
                    }

                    // go deeper
                    var level4NumberOfButtonsPressed = level3NumberOfButtonsPressed + level3JoltageRequirement;
                    var level4StartState = level3EndState.Clone();
                    var level4JoltageRequirement = machine.JoltageRequirements[3] - level4StartState[3];
                    //var level4RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(3)).ToList();
                    var level4RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 3);
                    maxButtonsPresses = GetMaxButtonsPressesPossible(level4RelevantButtons, level4StartState, machine.JoltageRequirements, level4JoltageRequirement);
                    var level4ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level4JoltageRequirement, maxButtonsPresses);

                    foreach (var level4ButtonPressCombination in level4ButtonPressCombinations)
                    {
                        var level4EndState = level4StartState.Clone();

                        for (int relevantButtonsCounter = 0; relevantButtonsCounter < level4RelevantButtons.Count; relevantButtonsCounter++)
                        {
                            level4EndState.PressButton(level4RelevantButtons[relevantButtonsCounter], level4ButtonPressCombination[relevantButtonsCounter]);
                        }

                        //Console.WriteLine(string.Join(",", level4EndState));

                        // check answer
                        if (level4EndState.SequenceEqual(machine.JoltageRequirements))
                        {
                            numberOfButtonPressesNecessary.Add(level4NumberOfButtonsPressed + level4JoltageRequirement);
                        }

                        // check if surpassed joltage reqs OR recursion is impossible
                        if (AreAnyJoltageRequirementsTooBig(level4EndState, machine.JoltageRequirements) || 3 == machine.JoltageRequirements.Count - 1)
                        {
                            continue;
                        }

                        // go deeper
                        var level5NumberOfButtonsPressed = level4NumberOfButtonsPressed + level4JoltageRequirement;
                        var level5StartState = level4EndState.Clone();
                        var level5JoltageRequirement = machine.JoltageRequirements[4] - level5StartState[4];
                        //var level5RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(4)).ToList();
                        var level5RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 4);
                        maxButtonsPresses = GetMaxButtonsPressesPossible(level5RelevantButtons, level5StartState, machine.JoltageRequirements, level5JoltageRequirement);
                        var level5ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level5JoltageRequirement, maxButtonsPresses);

                        foreach (var level5ButtonPressCombination in level5ButtonPressCombinations)
                        {
                            var level5EndState = level5StartState.Clone();

                            for (int relevantButtonsCounter = 0; relevantButtonsCounter < level5RelevantButtons.Count; relevantButtonsCounter++)
                            {
                                level5EndState.PressButton(level5RelevantButtons[relevantButtonsCounter], level5ButtonPressCombination[relevantButtonsCounter]);
                            }

                            //Console.WriteLine(string.Join(",", level5EndState));

                            // check answer
                            if (level5EndState.SequenceEqual(machine.JoltageRequirements))
                            {
                                numberOfButtonPressesNecessary.Add(level5NumberOfButtonsPressed + level5JoltageRequirement);
                            }

                            // check if surpassed joltage reqs OR recursion is impossible
                            if (AreAnyJoltageRequirementsTooBig(level5EndState, machine.JoltageRequirements) || 4 == machine.JoltageRequirements.Count - 1)
                            {
                                continue;
                            }

                            // go deeper
                            var level6NumberOfButtonsPressed = level5NumberOfButtonsPressed + level5JoltageRequirement;
                            var level6StartState = level5EndState.Clone();
                            var level6JoltageRequirement = machine.JoltageRequirements[5] - level6StartState[5];
                            //var level6RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(5)).ToList();
                            var level6RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 5);
                            maxButtonsPresses = GetMaxButtonsPressesPossible(level6RelevantButtons, level6StartState, machine.JoltageRequirements, level6JoltageRequirement);
                            var level6ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level6JoltageRequirement, maxButtonsPresses);

                            foreach (var level6ButtonPressCombination in level6ButtonPressCombinations)
                            {
                                var level6EndState = level6StartState.Clone();

                                for (int relevantButtonsCounter = 0; relevantButtonsCounter < level6RelevantButtons.Count; relevantButtonsCounter++)
                                {
                                    level6EndState.PressButton(level6RelevantButtons[relevantButtonsCounter], level6ButtonPressCombination[relevantButtonsCounter]);
                                }

                                //Console.WriteLine(string.Join(",", level6EndState));

                                // check answer
                                if (level6EndState.SequenceEqual(machine.JoltageRequirements))
                                {
                                    numberOfButtonPressesNecessary.Add(level6NumberOfButtonsPressed + level6JoltageRequirement);
                                }

                                // check if surpassed joltage reqs OR recursion is impossible
                                if (AreAnyJoltageRequirementsTooBig(level6EndState, machine.JoltageRequirements) || 5 == machine.JoltageRequirements.Count - 1)
                                {
                                    continue;
                                }

                                // go deeper
                                var level7NumberOfButtonsPressed = level6NumberOfButtonsPressed + level6JoltageRequirement;
                                var level7StartState = level6EndState.Clone();
                                var level7JoltageRequirement = machine.JoltageRequirements[6] - level7StartState[6];
                                //var level7RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(6)).ToList();
                                var level7RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 6);
                                maxButtonsPresses = GetMaxButtonsPressesPossible(level7RelevantButtons, level7StartState, machine.JoltageRequirements, level7JoltageRequirement);
                                var level7ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level7JoltageRequirement, maxButtonsPresses);

                                foreach (var level7ButtonPressCombination in level7ButtonPressCombinations)
                                {
                                    var level7EndState = level7StartState.Clone();

                                    for (int relevantButtonsCounter = 0; relevantButtonsCounter < level7RelevantButtons.Count; relevantButtonsCounter++)
                                    {
                                        level7EndState.PressButton(level7RelevantButtons[relevantButtonsCounter], level7ButtonPressCombination[relevantButtonsCounter]);
                                    }

                                    //Console.WriteLine(string.Join(",", level7EndState));

                                    // check answer
                                    if (level7EndState.SequenceEqual(machine.JoltageRequirements))
                                    {
                                        numberOfButtonPressesNecessary.Add(level7NumberOfButtonsPressed + level7JoltageRequirement);
                                    }

                                    // check if surpassed joltage reqs OR recursion is impossible
                                    if (AreAnyJoltageRequirementsTooBig(level7EndState, machine.JoltageRequirements) || 6 == machine.JoltageRequirements.Count - 1)
                                    {
                                        continue;
                                    }

                                    // go deeper
                                    var level8NumberOfButtonsPressed = level7NumberOfButtonsPressed + level7JoltageRequirement;
                                    var level8StartState = level7EndState.Clone();
                                    var level8JoltageRequirement = machine.JoltageRequirements[7] - level8StartState[7];
                                    //var level8RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(7)).ToList();
                                    var level8RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 7);
                                    maxButtonsPresses = GetMaxButtonsPressesPossible(level8RelevantButtons, level8StartState, machine.JoltageRequirements, level8JoltageRequirement);
                                    var level8ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level8JoltageRequirement, maxButtonsPresses);

                                    foreach (var level8ButtonPressCombination in level8ButtonPressCombinations)
                                    {
                                        var level8EndState = level8StartState.Clone();

                                        for (int relevantButtonsCounter = 0; relevantButtonsCounter < level8RelevantButtons.Count; relevantButtonsCounter++)
                                        {
                                            level8EndState.PressButton(level8RelevantButtons[relevantButtonsCounter], level8ButtonPressCombination[relevantButtonsCounter]);
                                        }

                                        //Console.WriteLine(string.Join(",", level8EndState));

                                        // check answer
                                        if (level8EndState.SequenceEqual(machine.JoltageRequirements))
                                        {
                                            numberOfButtonPressesNecessary.Add(level8NumberOfButtonsPressed + level8JoltageRequirement);
                                        }

                                        // check if surpassed joltage reqs OR recursion is impossible
                                        if (AreAnyJoltageRequirementsTooBig(level8EndState, machine.JoltageRequirements) || 7 == machine.JoltageRequirements.Count - 1)
                                        {
                                            continue;
                                        }

                                        // go deeper
                                        var level9NumberOfButtonsPressed = level8NumberOfButtonsPressed + level8JoltageRequirement;
                                        var level9StartState = level8EndState.Clone();
                                        var level9JoltageRequirement = machine.JoltageRequirements[8] - level9StartState[8];
                                        //var level9RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(8)).ToList();
                                        var level9RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 8);
                                        maxButtonsPresses = GetMaxButtonsPressesPossible(level9RelevantButtons, level9StartState, machine.JoltageRequirements, level9JoltageRequirement);
                                        var level9ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level9JoltageRequirement, maxButtonsPresses);

                                        foreach (var level9ButtonPressCombination in level9ButtonPressCombinations)
                                        {
                                            var level9EndState = level9StartState.Clone();

                                            for (int relevantButtonsCounter = 0; relevantButtonsCounter < level9RelevantButtons.Count; relevantButtonsCounter++)
                                            {
                                                level9EndState.PressButton(level9RelevantButtons[relevantButtonsCounter], level9ButtonPressCombination[relevantButtonsCounter]);
                                            }

                                            //Console.WriteLine(string.Join(",", level9EndState));

                                            // check answer
                                            if (level9EndState.SequenceEqual(machine.JoltageRequirements))
                                            {
                                                numberOfButtonPressesNecessary.Add(level9NumberOfButtonsPressed + level9JoltageRequirement);
                                            }

                                            // check if surpassed joltage reqs OR recursion is impossible
                                            if (AreAnyJoltageRequirementsTooBig(level9EndState, machine.JoltageRequirements) || 8 == machine.JoltageRequirements.Count - 1)
                                            {
                                                continue;
                                            }

                                            // go deeper
                                            var level10NumberOfButtonsPressed = level9NumberOfButtonsPressed + level9JoltageRequirement;
                                            var level10StartState = level9EndState.Clone();
                                            var level10JoltageRequirement = machine.JoltageRequirements[9] - level10StartState[9];
                                            //var level10RelevantButtons = machine.ButtonWiringSchematics.Where(x => x.ButtonWirings.Contains(9)).ToList();
                                            var level10RelevantButtons = GetRelevantButtons(machine.ButtonWiringSchematics, 9);
                                            maxButtonsPresses = GetMaxButtonsPressesPossible(level10RelevantButtons, level10StartState, machine.JoltageRequirements, level10JoltageRequirement);
                                            var level10ButtonPressCombinations = GetButtonPressCombinationsWithTooManyForLoops(level10JoltageRequirement, maxButtonsPresses);

                                            foreach (var level10ButtonPressCombination in level10ButtonPressCombinations)
                                            {
                                                var level10EndState = level10StartState.Clone();

                                                for (int relevantButtonsCounter = 0; relevantButtonsCounter < level10RelevantButtons.Count; relevantButtonsCounter++)
                                                {
                                                    level10EndState.PressButton(level10RelevantButtons[relevantButtonsCounter], level10ButtonPressCombination[relevantButtonsCounter]);
                                                }

                                                //Console.WriteLine(string.Join(",", level10EndState));

                                                // check answer
                                                if (level10EndState.SequenceEqual(machine.JoltageRequirements))
                                                {
                                                    numberOfButtonPressesNecessary.Add(level10NumberOfButtonsPressed + level10JoltageRequirement);
                                                }

                                                // check if surpassed joltage reqs OR recursion is impossible
                                                if (AreAnyJoltageRequirementsTooBig(level10EndState, machine.JoltageRequirements) || 9 == machine.JoltageRequirements.Count - 1)
                                                {
                                                    continue;
                                                }

                                                throw new ArgumentException("need to go deeper");
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

    private static List<ButtonWiringSchematic> GetRelevantButtons(List<ButtonWiringSchematic> buttonWiringSchematics, int numberOfInterest)
    {
        return buttonWiringSchematics.Where(x => x.ButtonWirings.Contains(numberOfInterest) && !x.ButtonWirings.Any(y => y < numberOfInterest)).ToList();
    }

    public static List<List<int>> GetButtonPressCombinations(uint joltageRequirement, int count) // public for testing
    {
        var buttonPressCombinations = new List<List<int>>();

        var possibleNumbers = Enumerable.Range(0, (int)joltageRequirement);
        var overkillOfCombinations = Math.Pow(count, joltageRequirement);

        var index = 0;
        var number = 0;

        for (var i = 0; i < overkillOfCombinations; i++)
        {
            var buttonPressCombination = new int[count];
            for (var j = 0; j < count; j++)
            {
                for (var k = 0; k <= joltageRequirement; k++)
                {
                    buttonPressCombination[j] = k;
                    Console.WriteLine(string.Join("", i, j, k));
                }
            }

        }


        return buttonPressCombinations;
    }

    public static List<List<int>> GetButtonPressCombinationsWithTooManyForLoops(uint joltageRequirement, int count) // public for testing
    {
        var buttonPressCombinations = new List<List<int>>();

        if (count == 0)
        {
            return buttonPressCombinations;
        }

        var levelCounter = 0;

        for (var i = 0; i <= joltageRequirement; i++)
        {
            if (count == 1)
            {
                if (i == joltageRequirement)
                {
                    buttonPressCombinations.Add(new List<int> { i });
                    //Console.WriteLine(string.Join("", i));
                }
                continue;
            }
            for (var j = 0; j <= joltageRequirement; j++)
            {
                if (i + j > joltageRequirement)
                {
                    break;
                }
                if (count == 2)
                {
                    if (i + j == joltageRequirement)
                    {
                        buttonPressCombinations.Add(new List<int> { i, j });
                        //Console.WriteLine(string.Join("", i, j));
                    }
                    continue;
                }
                for (var k = 0; k <= joltageRequirement; k++)
                {
                    if (i + j + k > joltageRequirement)
                    {
                        break;
                    }
                    if (count == 3)
                    {
                        if (i + j + k == joltageRequirement)
                        {
                            buttonPressCombinations.Add(new List<int> { i, j, k });
                            //Console.WriteLine(string.Join("", i, j, k));
                        }
                        continue;
                    }
                    for (var l = 0; l <= joltageRequirement; l++)
                    {
                        if (i + j + k + l > joltageRequirement)
                        {
                            break;
                        }
                        if (count == 4)
                        {
                            if (i + j + k + l == joltageRequirement)
                            {
                                buttonPressCombinations.Add(new List<int> { i, j, k, l });
                                //Console.WriteLine(string.Join("", i, j, k, l));
                            }
                            continue;
                        }
                        for (var m = 0; m <= joltageRequirement; m++)
                        {
                            if (i + j + k + l + m > joltageRequirement)
                            {
                                break;
                            }
                            if (count == 5)
                            {
                                if (i + j + k + l + m == joltageRequirement)
                                {
                                    buttonPressCombinations.Add(new List<int> { i, j, k, l, m });
                                    //Console.WriteLine(string.Join("", i, j, k, l, m));
                                }
                                continue;
                            }
                            for (var n = 0; n <= joltageRequirement; n++)
                            {
                                if (i + j + k + l + m + n > joltageRequirement)
                                {
                                    break;
                                }
                                if (count == 6)
                                {
                                    if (i + j + k + l + m + n == joltageRequirement)
                                    {
                                        buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n });
                                        //Console.WriteLine(string.Join("", i, j, k, l, m, n));
                                    }
                                    continue;
                                }
                                for (var o = 0; o <= joltageRequirement; o++)
                                {
                                    if (i + j + k + l + m + n + o > joltageRequirement)
                                    {
                                        break;
                                    }
                                    if (count == 7)
                                    {
                                        if (i + j + k + l + m + n + o == joltageRequirement)
                                        {
                                            buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n, o });
                                            //Console.WriteLine(string.Join("", i, j, k, l, m, n, o));
                                        }
                                        continue;
                                    }
                                    for (var p = 0; p <= joltageRequirement; p++)
                                    {
                                        if (i + j + k + l + m + n + o + p > joltageRequirement)
                                        {
                                            break;
                                        }
                                        if (count == 8)
                                        {
                                            if (i + j + k + l + m + n + o + p == joltageRequirement)
                                            {
                                                buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n, o, p });
                                                //Console.WriteLine(string.Join("", i, j, k, l, m, n, o, p));
                                            }
                                            continue;
                                        }
                                        for (var q = 0; q <= joltageRequirement; q++)
                                        {
                                            if (i + j + k + l + m + n + o + p + q > joltageRequirement)
                                            {
                                                break;
                                            }
                                            if (count == 9)
                                            {
                                                if (i + j + k + l + m + n + o + p + q == joltageRequirement)
                                                {
                                                    buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n, o, p, q });
                                                    //Console.WriteLine(string.Join("", i, j, k, l, m, n, o, p, q));
                                                }
                                                continue;
                                            }
                                            for (var r = 0; r <= joltageRequirement; r++)
                                            {
                                                if (i + j + k + l + m + n + o + p + q + r > joltageRequirement)
                                                {
                                                    break;
                                                }
                                                if (count == 10)
                                                {
                                                    if (i + j + k + l + m + n + o + p + q + r == joltageRequirement)
                                                    {
                                                        buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n, o, p, q, r });
                                                        //Console.WriteLine(string.Join("", i, j, k, l, m, n, o, p, q, r));
                                                    }
                                                    continue;
                                                }

                                                throw new ArgumentException("Need to go deeper");
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
        return buttonPressCombinations;
    }

    public static List<List<int>> GetButtonPressCombinationsWithTooManyForLoops(uint joltageRequirement, List<int> maxButtonPresses) // public for testing
    {
        var buttonPressCombinations = new List<List<int>>();
        var count = maxButtonPresses.Count;

        if (count == 0)
        {
            return buttonPressCombinations;
        }

        var levelCounter = 0;

        for (var i = 0; i <= maxButtonPresses[0]; i++)
        {
            if (count == 1)
            {
                if (i == joltageRequirement)
                {
                    buttonPressCombinations.Add(new List<int> { i });
                    //Console.WriteLine(string.Join("", i));
                }
                continue;
            }
            for (var j = 0; j <= maxButtonPresses[1]; j++)
            {
                if (i + j > joltageRequirement)
                {
                    break;
                }
                if (count == 2)
                {
                    if (i + j == joltageRequirement)
                    {
                        buttonPressCombinations.Add(new List<int> { i, j });
                        //Console.WriteLine(string.Join("", i, j));
                    }
                    continue;
                }
                for (var k = 0; k <= maxButtonPresses[2]; k++)
                {
                    if (i + j + k > joltageRequirement)
                    {
                        break;
                    }
                    if (count == 3)
                    {
                        if (i + j + k == joltageRequirement)
                        {
                            buttonPressCombinations.Add(new List<int> { i, j, k });
                            //Console.WriteLine(string.Join("", i, j, k));
                        }
                        continue;
                    }
                    for (var l = 0; l <= maxButtonPresses[3]; l++)
                    {
                        if (i + j + k + l > joltageRequirement)
                        {
                            break;
                        }
                        if (count == 4)
                        {
                            if (i + j + k + l == joltageRequirement)
                            {
                                buttonPressCombinations.Add(new List<int> { i, j, k, l });
                                //Console.WriteLine(string.Join("", i, j, k, l));
                            }
                            continue;
                        }
                        for (var m = 0; m <= maxButtonPresses[4]; m++)
                        {
                            if (i + j + k + l + m > joltageRequirement)
                            {
                                break;
                            }
                            if (count == 5)
                            {
                                if (i + j + k + l + m == joltageRequirement)
                                {
                                    buttonPressCombinations.Add(new List<int> { i, j, k, l, m });
                                    //Console.WriteLine(string.Join("", i, j, k, l, m));
                                }
                                continue;
                            }
                            for (var n = 0; n <= maxButtonPresses[5]; n++)
                            {
                                if (i + j + k + l + m + n > joltageRequirement)
                                {
                                    break;
                                }
                                if (count == 6)
                                {
                                    if (i + j + k + l + m + n == joltageRequirement)
                                    {
                                        buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n });
                                        //Console.WriteLine(string.Join("", i, j, k, l, m, n));
                                    }
                                    continue;
                                }
                                for (var o = 0; o <= maxButtonPresses[6]; o++)
                                {
                                    if (i + j + k + l + m + n + o > joltageRequirement)
                                    {
                                        break;
                                    }
                                    if (count == 7)
                                    {
                                        if (i + j + k + l + m + n + o == joltageRequirement)
                                        {
                                            buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n, o });
                                            //Console.WriteLine(string.Join("", i, j, k, l, m, n, o));
                                        }
                                        continue;
                                    }
                                    for (var p = 0; p <= maxButtonPresses[7]; p++)
                                    {
                                        if (i + j + k + l + m + n + o + p > joltageRequirement)
                                        {
                                            break;
                                        }
                                        if (count == 8)
                                        {
                                            if (i + j + k + l + m + n + o + p == joltageRequirement)
                                            {
                                                buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n, o, p });
                                                //Console.WriteLine(string.Join("", i, j, k, l, m, n, o, p));
                                            }
                                            continue;
                                        }
                                        for (var q = 0; q <= maxButtonPresses[8]; q++)
                                        {
                                            if (i + j + k + l + m + n + o + p + q > joltageRequirement)
                                            {
                                                break;
                                            }
                                            if (count == 9)
                                            {
                                                if (i + j + k + l + m + n + o + p + q == joltageRequirement)
                                                {
                                                    buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n, o, p, q });
                                                    //Console.WriteLine(string.Join("", i, j, k, l, m, n, o, p, q));
                                                }
                                                continue;
                                            }
                                            for (var r = 0; r <= maxButtonPresses[9]; r++)
                                            {
                                                if (i + j + k + l + m + n + o + p + q + r > joltageRequirement)
                                                {
                                                    break;
                                                }
                                                if (count == 10)
                                                {
                                                    if (i + j + k + l + m + n + o + p + q + r == joltageRequirement)
                                                    {
                                                        buttonPressCombinations.Add(new List<int> { i, j, k, l, m, n, o, p, q, r });
                                                        //Console.WriteLine(string.Join("", i, j, k, l, m, n, o, p, q, r));
                                                    }
                                                    continue;
                                                }

                                                throw new ArgumentException("Need to go deeper");
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
        return buttonPressCombinations;
    }

    private static int GetMaxButtonPressesPossible(ButtonWiringSchematic buttonWiringSchematic, List<uint> startState, List<uint> joltageRequirements)
    {
        var maxButtonPressesPossible = int.MaxValue;

        foreach (var buttonWiring in buttonWiringSchematic.ButtonWirings)
        {
            var maxPressesForJoltageRequirement = joltageRequirements[buttonWiring] - startState[buttonWiring];

            if (maxPressesForJoltageRequirement < maxButtonPressesPossible)
            {
                maxButtonPressesPossible = (int)maxPressesForJoltageRequirement;
            }
        }

        return maxButtonPressesPossible;
    }

    private static List<int> GetMaxButtonsPressesPossible(List<ButtonWiringSchematic> buttonWiringSchematics, List<uint> startState, List<uint> joltageRequirements, uint joltageRequirement)
    {
        var maxButtonsPressesPossible = new List<int>();

        foreach (var buttonWiringSchematic in buttonWiringSchematics)
        {
            var maxButtonPressesPossible = joltageRequirement;

            foreach (var buttonWiring in buttonWiringSchematic.ButtonWirings)
            {
                var maxPressesForJoltageRequirement = joltageRequirements[buttonWiring] - startState[buttonWiring];

                if (maxPressesForJoltageRequirement < maxButtonPressesPossible)
                {
                    maxButtonPressesPossible = maxPressesForJoltageRequirement;
                }
            }

            maxButtonsPressesPossible.Add((int)maxButtonPressesPossible);
        }

        return maxButtonsPressesPossible;
    }

    private static bool AreAnyJoltageRequirementsTooBig(this List<uint> levelEndState, List<uint> stateToAchieve)
    {
        var count = levelEndState.Count;
        //var noneAreBigger = true;

        for (int i = 0; i < count; i++)
        {
            if (levelEndState[i] > stateToAchieve[i])
            {
                return true;
            }
        }

        return false;
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

    private static void PressButton(this List<uint> joltageRequirement, ButtonWiringSchematic buttonWiringSchematic)
    {
        foreach (var buttonWiring in buttonWiringSchematic.ButtonWirings)
        {
            joltageRequirement[buttonWiring]++;
        }
    }

    private static void PressButton(this List<uint> joltageRequirement, ButtonWiringSchematic buttonWiringSchematic, int numberOfPresses)
    {
        foreach (var buttonWiring in buttonWiringSchematic.ButtonWirings)
        {
            joltageRequirement[buttonWiring] += (uint)numberOfPresses;
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

    private static List<uint> Clone(this List<uint> original)
    {
        var clone = new List<uint>();

        foreach (var joltageRequirement in original)
        {
            clone.Add(joltageRequirement);
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

    private static List<uint> CreateStartState(this List<uint> original)
    {
        var startState = new List<uint>();

        foreach (var joltageRequirement in original)
        {
            startState.Add(0u);
        }

        return startState;
    }

    public static Dictionary<string,List<List<int>>> GetSuperDuperDictionary(uint joltageRequirement, int count)
    {
        var superDuperDictionary = new Dictionary<string, List<List<int>>>();

        for (uint i = 0; i <= joltageRequirement; i++)
        {
            for (int j = 0; j < count; j++)
            {
                var stringKey = string.Join(",", i, j);
                var combinations = GetButtonPressCombinationsWithTooManyForLoops(i, j);

                superDuperDictionary.Add(stringKey, combinations);
            }
        }

        return superDuperDictionary;
    }
}
