using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;
using AdventOfCode2025.Day4;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day4Tests
{
    [TestMethod]
    public void GetAdjacentPosition_Input_ReturnsExpectedResult()
    {
        // Arrange
        var expectedNumberOfAdjacentPositions = 8;

        var map = CreateTestMap();
        var position = new Position(1, 1);

        // Act
        var adJacentPositions = MapService.GetAdjacentPositions(map, position);
        var actualNumberOfAdjacentPositions = adJacentPositions.Count;

        // Assert
        Assert.AreEqual(expectedNumberOfAdjacentPositions, actualNumberOfAdjacentPositions);
    }

    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 13u;

        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day4\\{fileName}");
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
        var expectedResult = 43u;

        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day4\\{fileName}");
        var map = MapService.GetMap(input);

        // Act
        var result = Part2.Solve(map);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    private Map CreateTestMap()
    {
        var map = new Map(3, 3);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var field = new Field(new Position(i, j), '@');
                map.Fields[i, j] = field;
                map.FieldsList.Add(field);
            }
        }

        return map;
    }
}
