using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day11;

public static class Part1
{
    public static ulong Solve(List<Device> devices)
    {
        var result = DeviceService.FindPathsFromYouToOut(devices);

        return result;
    }
}
