using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day1;

public class Dial
{
    private const uint MinimumPosition = 0;
    private const uint MaximumPosition = 99;
    private const int PositionCorrection = 100;
    private bool IsStartPositionZero = false;

    public uint Position { get; set; }
    public uint ZeroCounter { get; set; } = 0;

    public Dial()
    {
        Position = 50;
    }

    public Dial(uint position) // for test purposes
    {
        Position = position;
    }

    public void Rotate(RotationInstruction rotateInstruction) // TODO simplify
    {
        ZeroCounter += rotateInstruction.NumberOfRotations / PositionCorrection;
        var actualRotations = rotateInstruction.NumberOfRotations % PositionCorrection;

        if (actualRotations == 0) 
        {
            return;
        }

        if (Position == MinimumPosition)
        {
            IsStartPositionZero = true;
        }
        else
        {
            IsStartPositionZero = false;
        }

        var newPosition = (int)Position;

        if (rotateInstruction.RotationDirection == DirectionCode.Left)
        {
            newPosition -= (int)actualRotations;
        }
        if (rotateInstruction.RotationDirection == DirectionCode.Right)
        {
            newPosition += (int)actualRotations;
        }

        if (newPosition > MaximumPosition)
        {
            newPosition -= PositionCorrection;
            if (newPosition != MinimumPosition)
            {
                ZeroCounter++;
            }
        }
        if (newPosition < MinimumPosition)
        {
            newPosition += PositionCorrection;

            if (!IsStartPositionZero)
            {
                ZeroCounter++;
            }
        }

        Position = (uint)newPosition;

        if (Position == MinimumPosition)
        {
            ZeroCounter++;
        }
    }
}
