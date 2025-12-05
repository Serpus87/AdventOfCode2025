using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Shared;

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

    [DataRow(11ul,22ul,33ul)]
    [DataRow(95ul,115ul,210ul)]
    [DataRow(999ul,1010ul,2009ul)]
    [DataRow(1188511880ul, 1188511890ul, 1188511885ul)]
    [DataRow(222220ul, 222224ul, 222222ul)]
    [DataRow(1698522ul, 1698528ul, 0ul)]
    [DataRow(446443ul, 446449ul, 446446ul)]
    [DataRow(38593856ul, 38593862ul, 38593859ul)]
    [DataRow(565653ul, 565659ul, 565656ul)]
    [DataRow(824824821ul, 824824827ul, 824824824ul)]
    [DataRow(2121212118ul, 2121212124ul, 2121212121ul)]
    [TestMethod]
    public void Part2Solve_IdPairInput_ReturnsExpectedResult(ulong id1, ulong id2, ulong expectedResult)
    {
        // Arrange
        var idPairs = new List<IdPair> { new IdPair(id1, id2) };

        // Act
        var result = Part2.Solve(idPairs);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Part2Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 4174379265u;
        var fileName = "Example.txt";
        var idPairs = InputReader.GetIdPairs(fileName);

        // Act
        var result = Part2.Solve(idPairs);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
