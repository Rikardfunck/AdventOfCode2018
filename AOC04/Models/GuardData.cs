using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC04.Models;

public record GuardData
{
    public string GuardId { get; set; }

    public int MinuteMostAsleep { get; set; }

    public int MinuteMostAsleepCount { get; set; }

    public int MinutesAsleep { get; set; }
}
