using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day11;

public static class InputReader
{
    public static List<Device> GetDevices(string fileName) {

        var devices = new List<Device>();
        string[] lines = File.ReadAllLines($"Day11\\{fileName}");

        foreach (var line in lines)
        {
            var nameAndOutputNames = line.Split(':',' ');
            var name = nameAndOutputNames[0];
            var outputNames = nameAndOutputNames.Skip(2).ToList();

            devices.Add(new Device(name, outputNames));
        }

        return devices;
    }
}
