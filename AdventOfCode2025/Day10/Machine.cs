using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day10;

public class Machine
{
    public List<bool> IndicatorLightDiagram { get; set; }
    public List<ButtonWiringSchematic> ButtonWiringSchematics { get; set; }
    public List<uint> JoltageRequirements { get; set; }

    public Machine(List<bool> indicatorLightDiagram, List<ButtonWiringSchematic> buttonWiringSchematics, List<uint> joltageRequirements)
    {
        IndicatorLightDiagram = indicatorLightDiagram;
        ButtonWiringSchematics = buttonWiringSchematics;
        JoltageRequirements = joltageRequirements;
    }
}
