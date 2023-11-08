using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC06.Models;

public record Coordinate
{
    public Coordinate(string x, string y)
    {
        if (int.TryParse(x, out int resultX) && int.TryParse(y, out int resultY))
        {
            X = resultX;
            Y = resultY;
        }
    }

    public int X { get; set; }

    public int Y { get; set; }
}
