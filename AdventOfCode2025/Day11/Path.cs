using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day11;

public class Path
{
    public List<string> DeviceNames { get; set; }
    public bool HasEnded { get; set; } = false;
    public bool HasVisitedDac { get; set; } = false;
    public bool HasVisitedFft { get; set; } = false;
    public bool HasFoundExit { get; set; } = false;

    public Path(string start)
    {
        DeviceNames = new List<string> { start };
    }

    public Path Clone()
    {
        var cloneOfNames = new List<string>();

        foreach (var name in DeviceNames) 
        {
            cloneOfNames.Add(name);
        }

        return new Path(cloneOfNames, HasVisitedDac, HasVisitedFft, HasFoundExit);
    }

    private Path(List<string> deviceNames, bool hasVisitedDac, bool hasVisitedFft, bool hasFoundExit)
    {
        DeviceNames = deviceNames;
        HasVisitedDac = hasVisitedDac;
        HasVisitedFft = hasVisitedFft;
        HasFoundExit = hasFoundExit;
    }
}
