using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day11;

public static class DeviceService
{
    public static uint FindPathsFromYouToOut(List<Device> devices)
    {
        var paths = new List<Path> { new Path("you") };

        var allPathsHaveEnded = paths.All(x=>x.HasEnded);

        while (!allPathsHaveEnded)
        {
            var path = paths.First(x => !x.HasEnded);
            var device = devices.First(x => x.Name == path.DeviceNames.Last());
            var nextDeviceNames = device.OutputNames.ToList();

            foreach (var nextDeviceName in nextDeviceNames) 
            {
                var newPath = path.Clone();

                if (newPath.DeviceNames.Contains(nextDeviceName))
                {
                    throw new ArgumentException("will loop forever, need to handle this");
                }

                newPath.DeviceNames.Add(nextDeviceName);

                if (nextDeviceName == "out")
                {
                    newPath.HasEnded = true;
                }

                paths.Add(newPath);
            }

            paths.Remove(path);
            allPathsHaveEnded = paths.All(x => x.HasEnded);
        }

        return (uint)paths.Count();
    }

    public static uint FindPathsFromNodeToNode(List<Device> devices, string nodeStart, string nodeEnd, List<string> nodesToEnd)
    {
        var paths = new List<Path> { new Path(nodeStart) };

        var allPathsHaveEnded = paths.All(x => x.HasEnded);

        var timeStart = DateTime.Now;
        var counter = 0;

        while (!allPathsHaveEnded)
        {
            var path = paths.First(x => !x.HasEnded);
            var device = devices.First(x => x.Name == path.DeviceNames.Last());
            var nextDeviceNames = device.OutputNames.ToList();

            foreach (var nextDeviceName in nextDeviceNames)
            {
                var newPath = path.Clone();

                if (nodesToEnd.Contains(nextDeviceName))
                {
                    continue;
                }

                if (newPath.DeviceNames.Contains(nextDeviceName))
                {
                    throw new ArgumentException("will loop forever, need to handle this");
                }

                newPath.DeviceNames.Add(nextDeviceName);

                if (nextDeviceName == nodeEnd)
                {
                    newPath.HasEnded = true;
                }

                paths.Add(newPath);
            }

            paths.Remove(path);
            allPathsHaveEnded = paths.All(x => x.HasEnded);

            // debug
            if ((int)((DateTime.Now - timeStart).TotalSeconds / Math.Pow(10, counter)) > 0)
            {
                counter++;
                var secondsPassed = (DateTime.Now - timeStart).TotalSeconds;
                Console.WriteLine($"{secondsPassed} seconds since start;{paths.Count(x => x.HasEnded)} paths have ended; {paths.Count(x => !x.HasEnded)} paths have not ended yet");
            }
            // debug
        }

        return (uint)paths.Count();
    }

    public static uint FindPathsFromSvrToOut(List<Device> devices)
    {
        var paths = new List<Path> { new Path("svr") };

        var allPathsHaveEnded = paths.All(x => x.HasEnded);

        while (!allPathsHaveEnded)
        {
            var path = paths.First(x => !x.HasEnded);
            var device = devices.First(x => x.Name == path.DeviceNames.Last());
            var nextDeviceNames = device.OutputNames.ToList();

            foreach (var nextDeviceName in nextDeviceNames)
            {
                var newPath = path.Clone();

                if (newPath.DeviceNames.Contains(nextDeviceName))
                {
                    throw new ArgumentException("will loop forever, need to handle this");
                }

                newPath.DeviceNames.Add(nextDeviceName);

                if (nextDeviceName == "dac")
                {
                    newPath.HasVisitedDac = true;
                }

                if (nextDeviceName == "fft")
                {
                    newPath.HasVisitedFft = true;
                }

                if (nextDeviceName == "out")
                {
                    newPath.HasEnded = true;
                }

                paths.Add(newPath);
            }

            paths.Remove(path);
            allPathsHaveEnded = paths.All(x => x.HasEnded);
        }

        return (uint)paths.Count(x=>x.HasVisitedFft && x.HasVisitedDac);
    }

    public static uint FindPathsFromOutToSvr(List<Device> devices)
    {
        var paths = new List<Path> { new Path("out") };

        var allPathsHaveEnded = paths.All(x => x.HasEnded);

        var timeStart = DateTime.Now;
        var counter = 0;

        while (!allPathsHaveEnded)
        {
            var path = paths.First(x => !x.HasEnded);
            var devicesOfInterest = devices.Where(x => x.OutputNames.Contains(path.DeviceNames.Last()));
            var nextDeviceNames = devicesOfInterest.Select(x=>x.Name).ToList();

            foreach (var nextDeviceName in nextDeviceNames)
            {
                var newPath = path.Clone();

                if (newPath.DeviceNames.Contains(nextDeviceName))
                {
                    newPath.HasEnded = true;
                }

                newPath.DeviceNames.Add(nextDeviceName);

                if (nextDeviceName == "dac")
                {
                    newPath.HasVisitedDac = true;
                }

                if (nextDeviceName == "fft")
                {
                    newPath.HasVisitedFft = true;
                }

                if (nextDeviceName == "svr")
                {
                    newPath.HasFoundExit = true;
                    newPath.HasEnded = true;
                }

                paths.Add(newPath);
            }

            paths.Remove(path);
            allPathsHaveEnded = paths.All(x => x.HasEnded);

            // debug
            if((int)((DateTime.Now - timeStart).TotalSeconds / Math.Pow(10,counter)) > 0)
            {
                counter++;
                var secondsPassed = (DateTime.Now - timeStart).TotalSeconds;
                Console.WriteLine($"{secondsPassed} seconds since start;{paths.Count(x=>x.HasEnded)} paths have ended; {paths.Count(x=>!x.HasEnded)} paths have not ended yet");
            }
            // debug
        }

        return (uint)paths.Count(x => x.HasVisitedFft && x.HasVisitedDac && x.HasFoundExit);
    }
}
