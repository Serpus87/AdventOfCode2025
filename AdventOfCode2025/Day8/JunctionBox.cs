using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day8;

public class JunctionBox
{
    public int Id { get; init; }
    public Location Location { get; init; }
    public int ClosestJunctionBoxId { get; set; } = default!;
    public JunctionBox ClosestJunctionBox { get; set; } = default!;
    public decimal DistanceToClosestJunctionBox { get; set; } = default!;

    public JunctionBox(int id, Location location)
    {
        Id = id;
        Location = location;
    }
}
