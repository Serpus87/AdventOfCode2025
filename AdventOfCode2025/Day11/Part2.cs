using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2025.Shared;

namespace AdventOfCode2025.Day11;

public static class Part2
{
    public static ulong Solve(List<Device> devices)
    {
        //var result = DeviceService.FindPathsFromOutToSvr(devices); // too slow
        //var result = DeviceService.FindPathsFromSvrToOut(devices); // too slow

        var svrToDac = DeviceService.FindPathsFromNodeToNode(devices, "svr", "dac", new List<string> { "out" , "fft" });
        Console.WriteLine("conection 1/6 found!");

        var dacToFft = DeviceService.FindPathsFromNodeToNode(devices, "dac", "fft", new List<string> { "out" , "svr" });
        Console.WriteLine("conection 2/6 found!");

        var fftToOut = DeviceService.FindPathsFromNodeToNode(devices, "fft", "out", new List<string> { "svr", "dac" });
        Console.WriteLine("conection 3/6 found!");

        var number1 = svrToDac * dacToFft * fftToOut;

        var svrToFft = DeviceService.FindPathsFromNodeToNode(devices, "svr", "fft", new List<string> { "out", "dac" });
        Console.WriteLine("conection 4/6 found!");

        var fftToDac = DeviceService.FindPathsFromNodeToNode(devices, "fft", "dac", new List<string> { "out", "svr" });
        Console.WriteLine("conection 5/6 found!");

        var dacToOut = DeviceService.FindPathsFromNodeToNode(devices, "dac", "out", new List<string> { "svr", "fft" });
        Console.WriteLine("conection 6/6 found!");

        var number2 = svrToFft * fftToDac * dacToOut;

        var result = number1 + number2;

        return result;
    }
}
