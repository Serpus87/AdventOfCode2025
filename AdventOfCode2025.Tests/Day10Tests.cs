using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day10;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day10Tests
{
    [DataRow(false, false, true)]
    [DataRow(false, true, false)]
    [DataRow(true, false, false)]
    [DataRow(true, true, true)]
    [TestMethod]
    public void Contains_ListOfListOfBool_ReturnsExpectedResult(bool list1Bool, bool list2Bool, bool expectedResult)
    {
        // Arrange
        var list1 = new List<List<bool>> { new List<bool> { list1Bool } };
        var list2 = new List<bool>  { list2Bool } ;

        // Act
        //var result = list1.Contains(list2);
        var result = list1.Any(x=> x.SequenceEqual(list2));

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void GetFewestButtonPressesWithTooManyForLoops_Machine_ReturnsResultBiggerThanZero()
    {
        // Arrange
        var indicatorLightDiagram = new List<bool> { true, true, true, false, false, true };
        var buttonWiringSchematics = new List<ButtonWiringSchematic>
        {
            new ButtonWiringSchematic(new List<int>{0,2,5}),
            new ButtonWiringSchematic(new List<int>{0,2,3,4,5}),
            new ButtonWiringSchematic(new List<int>{1,2}),
            new ButtonWiringSchematic(new List<int>{0,1,5}),
            new ButtonWiringSchematic(new List<int>{0,2,3,4}),
            new ButtonWiringSchematic(new List<int>{3}),
            new ButtonWiringSchematic(new List<int>{2,3,5}),
            new ButtonWiringSchematic(new List<int>{1,5})
        };

        var machine = new Machine(indicatorLightDiagram, buttonWiringSchematics, new List<uint>());

        // Act
        var result = MachineService.GetFewestButtonPressesWithTooManyForLoops(machine);

        // Assert
        Assert.IsTrue(result > 0ul);
    }

    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 7ul;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day10\\{fileName}");
        var machines = InputReader.GetMachines(input);

        // Act
        var result = Part1.Solve(machines);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [DataRow(2u,2,3)]
    [DataRow(3u,2,4)]
    [DataRow(2u,3,6)]
    [DataRow(3u,3,10)]
    [DataRow(1u,10,10)]
    [TestMethod]
    public void GetButtonPressCombinations_Input_ReturnsExpectedResult(uint joltageRequirement, int numberOfButtons, int expectedCount)
    {
        // Arrange
    
        // Act
        var result = MachineService.GetButtonPressCombinationsWithTooManyForLoops(joltageRequirement, numberOfButtons);

        // Assert
        Assert.IsTrue(result.Count == expectedCount);
        Assert.IsTrue(result.All(x=>x.Sum() == (int)joltageRequirement));
    }

    [TestMethod]
    public void Part2Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 33ul;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day10\\{fileName}");
        var machines = InputReader.GetMachines(input);

        // Act
        var result = Part2.Solve(machines);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
