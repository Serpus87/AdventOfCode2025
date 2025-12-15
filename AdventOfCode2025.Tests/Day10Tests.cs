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
        var expectedResult = 0ul;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day10\\{fileName}");
        var machines = InputReader.GetMachines(input);

        // Act
        var result = Part2.Solve(machines);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
