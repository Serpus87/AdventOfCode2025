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

    [DataRow("987654321111111", 987654321111ul)]
    [DataRow("811111111111119", 811111111119ul)]
    [DataRow("234234234234278", 434234234278ul)]
    [DataRow("818181911112111", 888911112111ul)]
    [TestMethod]
    public void Part3Solve_BankInput_ReturnsExpectedResult(string line, ulong expectedResult)
    {
        // Arrange
        var joltages = line.ToCharArray().Select(x => uint.Parse(x.ToString())).ToList(); ;
        var bank = new Bank(joltages);

        // Act
        var result = Part2.Solve(new List<Bank> { bank });

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Part3Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 3121910778619u;
        var fileName = "Example.txt";
        var banks = InputReader.GetBanks(fileName);

        // Act
        var result = Part2.Solve(banks);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
