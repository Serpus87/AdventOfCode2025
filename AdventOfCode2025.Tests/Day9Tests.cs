using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day9;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day9Tests
{
    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 50ul;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day9\\{fileName}");
        var tiles = TileService.GetRedTiles(input);

        // Act
        var result = Part1.Solve(tiles);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Part2Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 24ul;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day9\\{fileName}");
        var tiles = TileService.GetRedTiles(input);

        // Act
        var result = Part2.Solve(tiles);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
