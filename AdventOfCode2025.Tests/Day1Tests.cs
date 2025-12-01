using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Day1;

namespace AdventOfCode2025.Tests;

[TestClass]
public class Day1Tests
{
    [TestMethod]
    public void Solve_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 3u;
        var inputFileName = "Example.txt";

        // Act
        var rotationInstructions = InputReader.GetRotationInstructions(inputFileName);

        var dial = new Dial();

        var result = 0u;

        foreach (var rotationInstruction in rotationInstructions)
        {
            dial.Rotate(rotationInstruction);

            if (dial.Position == 0)
            {
                result++;
            }
        }

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void SolvePart2_Example_ReturnsExpectedResult()
    {
        // Arrange
        var expectedResult = 6u;
        var inputFileName = "Example.txt";

        // Act
        var rotationInstructions = InputReader.GetRotationInstructions(inputFileName);

        var dial = new Dial();

        foreach (var rotationInstruction in rotationInstructions)
        {
            dial.Rotate(rotationInstruction);
        }

        var result = dial.ZeroCounter;

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [DataRow(50u, DirectionCode.Left, 1u, 49u, 0u)]
    [DataRow(50u, DirectionCode.Right, 1u, 51u, 0u)]
    [DataRow(50u, DirectionCode.Left, 50u, 0u, 1u)]
    [DataRow(50u, DirectionCode.Right, 49u, 99u, 0u)]
    [DataRow(50u, DirectionCode.Right, 50u, 0u, 1u)]
    [DataRow(50u, DirectionCode.Left, 101u, 49u, 1u)]
    [DataRow(50u, DirectionCode.Right, 101u, 51u, 1u)]
    [DataRow(50u, DirectionCode.Left, 150u, 0u, 2u)]
    [DataRow(50u, DirectionCode.Right, 149u, 99u, 1u)]
    [DataRow(50u, DirectionCode.Right, 150u, 0u, 2u)]
    [DataRow(0u, DirectionCode.Left, 1u, 99u, 0u)]
    [DataRow(0u, DirectionCode.Right, 1u, 1u, 0u)]
    [DataRow(0u, DirectionCode.Left, 50u, 50u,0u)]
    [DataRow(0u, DirectionCode.Right, 50u, 50u,0u)]
    [DataRow(0u, DirectionCode.Left, 99u, 1u,0u)]
    [DataRow(0u, DirectionCode.Left, 100u, 0u,1u)]
    [DataRow(0u, DirectionCode.Left, 101u, 99u,1u)]
    [DataRow(0u, DirectionCode.Right, 99u, 99u,0u)]
    [DataRow(0u, DirectionCode.Right, 100u, 0u,1u)]
    [DataRow(0u, DirectionCode.Left, 199u, 1u,1u)]
    [DataRow(0u, DirectionCode.Left, 200u, 0u,2u)]
    [DataRow(0u, DirectionCode.Right, 199u, 99u,1u)]
    [DataRow(0u, DirectionCode.Right, 200u, 0u,2u)]
    [DataRow(99u, DirectionCode.Left, 1u, 98u,0u)]
    [DataRow(99u, DirectionCode.Right, 1u, 0u,1u)]
    [DataRow(99u, DirectionCode.Left, 50u, 49u,0u)]
    [DataRow(99u, DirectionCode.Right, 50u, 49u,1u)]
    [DataRow(99u, DirectionCode.Left, 99u, 0u,1u)]
    [DataRow(99u, DirectionCode.Left, 100u, 99u,1u)]
    [DataRow(99u, DirectionCode.Right, 1u, 0u,1u)]
    [DataRow(99u, DirectionCode.Right, 99u, 98u,1u)]
    [DataRow(99u, DirectionCode.Right, 100u, 99u,1u)]
    [DataRow(99u, DirectionCode.Left, 199u, 0u,2u)]
    [DataRow(99u, DirectionCode.Left, 200u, 99u,2u)]
    [DataRow(99u, DirectionCode.Right, 101u, 0u,2u)]
    [DataRow(99u, DirectionCode.Right, 199u, 98u,2u)]
    [DataRow(99u, DirectionCode.Right, 200u, 99u,2u)]
    [TestMethod]
    public void Rotate_Input_ReturnsExpectedResult(uint startingPosition, DirectionCode rotationDirection, uint numberOfDirection, uint expectedPosition, uint expectedZeroCounter)
    {
        // Arrange
        var dial = new Dial(startingPosition);
        var rotationInstruction = new RotationInstruction(rotationDirection, numberOfDirection);

        // Act
        dial.Rotate(rotationInstruction);

        var actualPosition = dial.Position;
        var actualZeroCounter = dial.ZeroCounter;

        // Assert
        Assert.AreEqual(expectedPosition, actualPosition);
        Assert.AreEqual(expectedZeroCounter, actualZeroCounter);
    }
}
