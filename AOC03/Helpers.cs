using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC03;

public static class Helpers
{
    public static string[,] Create2DArray(int x, int y)
    {
        var rows = new string[y, x];
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                rows[i, j] = ".";
            }
        }

        return rows;
    }
}
