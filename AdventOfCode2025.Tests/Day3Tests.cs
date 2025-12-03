using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day3;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day3Tests
{
    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 357u;
        var fileName = "Example.txt";
        var banks = InputReader.GetBanks(fileName);

        // Act
        var result = Part1.Solve(banks);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
