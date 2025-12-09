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
    public void GetJunctionBoxes_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 20;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day8\\{fileName}");

        // Act
        var result = BoxService.GetJunctionBoxes(input).Count;

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 40u;
        var fileName = "Example.txt";
        var input = File.ReadAllLines($"Day8\\{fileName}");
        var boxes = BoxService.GetJunctionBoxes(input);
        var shortestConnectionsToMake = 10;

        // Act
        var result = Part1.Solve(boxes, shortestConnectionsToMake);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void GetClosestLocations_PuzzleInput_PassesBasicChecks()
    {
        // Arrange
        var fileName = "PuzzleInput.txt";
        var input = File.ReadAllLines($"Day8\\{fileName}");
        var boxes = BoxService.GetJunctionBoxes(input);

        // Act
        BoxService.GetClosestLocations(boxes);

        // Assert
        Assert.AreEqual(0,boxes.Count(x=>x.Id == x.ClosestJunctionBoxId));
    }

    [TestMethod]
    public void MakeShortestConnections_PuzzleInput_PassesBasicChecks()
    {
        // Arrange
        var fileName = "PuzzleInput.txt";
        var input = File.ReadAllLines($"Day8\\{fileName}");
        var boxes = BoxService.GetJunctionBoxes(input);
        var shortestConnectionsToMake = 1000;

        BoxService.GetClosestLocations(boxes);

        // Act
        var result = BoxService.MakeShortestConnections(boxes, shortestConnectionsToMake);
        var orderedResult = result.OrderByDescending(x=>x.ConnectedBoxIds.Count);

        // Assert
        Assert.AreEqual(result.SelectMany(x => x.ConnectedBoxIds).Count(), shortestConnectionsToMake);
        Assert.AreEqual(result.SelectMany(x => x.ConnectedBoxIds).Count(), boxes.Count);
        Assert.AreEqual(result.SelectMany(x => x.ConnectedBoxIds).Count(), result.SelectMany(x => x.ConnectedBoxIds).Distinct().Count());
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
