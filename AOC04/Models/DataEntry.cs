using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC04.Models;

public record DataEntry
{
    public DateTime Date { get; set; }

    public string GuardId { get; set; }

    public bool WakesUp { get; set; }

    public bool FallsAsleep { get; set; }

    public bool BeginsShift { get; set; }
}
