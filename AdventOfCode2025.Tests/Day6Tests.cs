using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day6;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day6Tests
{
    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 0; 
        var fileName = "Example.txt";
        //var input = InputReader.GetInput(fileName);

        // Act
        var result = Part1.Solve();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Part2Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 0;
        var fileName = "Example.txt";
        //var input = InputReader.GetInput(fileName);

        // Act
        var result = Part2.Solve();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
