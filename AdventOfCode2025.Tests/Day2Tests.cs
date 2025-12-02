using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day2;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day2Tests
{
    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 1227775554u;
        var fileName = "Example.txt";
        var idPairs = InputReader.GetIdPairs(fileName);

        // Act
        var result = Part1.Solve(idPairs);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
