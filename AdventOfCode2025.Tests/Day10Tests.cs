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
            new ButtonWiringSchematic(new List<uint>{0u,2u,5u}),
            new ButtonWiringSchematic(new List<uint>{0u,2u,3u,4u,5u}),
            new ButtonWiringSchematic(new List<uint>{1u,2u}),
            new ButtonWiringSchematic(new List<uint>{0u,1u,5u}),
            new ButtonWiringSchematic(new List<uint>{0u,2u,3u,4u}),
            new ButtonWiringSchematic(new List<uint>{3u}),
            new ButtonWiringSchematic(new List<uint>{2u,3u,5u}),
            new ButtonWiringSchematic(new List<uint>{1u,5u})
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
