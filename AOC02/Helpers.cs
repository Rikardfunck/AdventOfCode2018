using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC02;

public static class Helpers
{
    public static string JoinStringsWhereSimilar(string innerLine, string line)
    {
        var mergedLine = innerLine.Zip(line, (first, second) =>
        {
            return first == second ? first : ' ';
        });

        var cleanedLine = mergedLine.Where(character => character != ' ').ToArray();

        return new string(cleanedLine);
    }
}
