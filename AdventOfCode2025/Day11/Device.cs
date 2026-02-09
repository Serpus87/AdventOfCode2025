using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day11;

public class Device
{
    public string Name { get; set; }
    public List<string> OutputNames { get; set; }

    public Device(string name, List<string> outputNames)
    {
        Name = name;
        OutputNames = outputNames;
    }
}
