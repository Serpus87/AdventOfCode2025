using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day8;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day8Tests
{
    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 0u;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day8\\{fileName}");
        var boxes = BoxService.GetJunctionBoxes(input);

        // Act
        var result = Part1.Solve(boxes);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Part2Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 0u;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day8\\{fileName}");
        var boxes = BoxService.GetJunctionBoxes(input);

        // Act
        var result = Part2.Solve(boxes);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
