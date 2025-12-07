using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day7;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day7Tests
{
    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 21; 
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day7\\{fileName}");
        var map = MapService.GetMap(input);

        // Act
        var result = Part1.Solve(map);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Part2Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 0ul;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day7\\{fileName}");
        var map = MapService.GetMap(input);

        // Act
        var result = Part2.Solve(map);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
