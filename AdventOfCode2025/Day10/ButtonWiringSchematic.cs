using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day10;

public class ButtonWiringSchematic
{
    public List<uint> ButtonWirings { get; set; }

    public ButtonWiringSchematic(List<uint> buttonWirings)
    {
        ButtonWirings = buttonWirings;    
    }
}
