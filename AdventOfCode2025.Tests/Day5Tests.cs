using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day5;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day5Tests
{
    [TestMethod]
    public void Part1Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 3; 
        var fileName = "Example.txt";
        var input = InputReader.GetInput(fileName);

        // Act
        var result = Part1.Solve(input);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void Part2Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 14ul;
        var fileName = "Example.txt";
        var input = InputReader.GetInput(fileName);

        // Act
        var result = Part2.Solve(input);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [DataRow(10ul,20ul,11ul,19ul,10ul,20ul)]
    [DataRow(10ul,19ul,11ul,20ul,10ul,20ul)]
    [DataRow(10ul,19ul,19ul,20ul,10ul,20ul)]
    [DataRow(10ul,11ul,11ul,20ul,10ul,20ul)]
    [DataRow(10ul,20ul,11ul,20ul,10ul,20ul)]
    [TestMethod]
    public void CreateNonOverlappingIdPairs_InputWithOverlap_ReturnsExpectedOutput(ulong id1IdPair1, ulong id2IdPair1, ulong id1IdPair2, ulong id2IdPair2, ulong id1NonOverlappingId, ulong id2NonOverlappingId)
    {
        // Arrange
        var idPair1 = new IdPair(id1IdPair1, id2IdPair1);
        var idPair2 = new IdPair(id1IdPair2, id2IdPair2);
        var expectedIdPairResult = new IdPair(id1NonOverlappingId, id2NonOverlappingId);

        var idPairs = new List<IdPair> {
            idPair1,
            idPair2
        };

        // Act
        var result = IdService.CreateNonOverlappingIdPairs(idPairs);

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(expectedIdPairResult.Id1, result[0].Id1);
        Assert.AreEqual(expectedIdPairResult.Id2, result[0].Id2);
    }
}
