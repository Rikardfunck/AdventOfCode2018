using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC03;

public static class Extensions
{
    public static IEnumerable<DataEntry> RawInputToListOfObjects(this string[] rawInput)
    {
        var dataEntries = new List<DataEntry>();
        foreach (var dataEntryString in rawInput)
        {
            dataEntries.Add(dataEntryString.ExtractInformation());
        }

        return dataEntries.AsEnumerable();
    }

    public static string[,] InputEntriesInMatrix(this string[,] matrix, IEnumerable<DataEntry> entries)
    {
        foreach (var entry in entries)
        {
            for (int i = entry.Coordinates.Y; i < (entry.Coordinates.Y + entry.Size.Height); i++)
            {
                for (int j = entry.Coordinates.X; j < (entry.Coordinates.X + entry.Size.Width); j++)
                {
                    if (matrix[i, j] == ".")
                    {
                        matrix[i, j] = entry.Id;
                    }
                    else
                    {
                        matrix[i, j] = "X";
                    }
                }
            }
        }

        return matrix;
    }

    public static int GetOverlappingSquareMeters(this string[,] matrix)
    {
        var squareMeters = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == "X")
                {
                    squareMeters++;
                }
            }
        }

        return squareMeters;
    }

    public static string GetWhichIdIsNotOverlapping(this string[,] matrix, IEnumerable<DataEntry> entries)
    {
        var id = string.Empty;

        foreach (var entry in entries)
        {
            var isOverlapping = false;
            for (int i = entry.Coordinates.Y; i < (entry.Coordinates.Y + entry.Size.Height); i++)
            {
                for (int j = entry.Coordinates.X; j < (entry.Coordinates.X + entry.Size.Width); j++)
                {
                    if (matrix[i, j] == "X")
                    {
                        isOverlapping = true;
                    }
                }
            }

            if (!isOverlapping)
            {
                id = entry.Id;
            }
        }

        return id;
    }

    public static void DrawMatrix(this string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static DataEntry ExtractInformation(this string dataEntryString)
    {
        var splitString = dataEntryString.Split(' ');

        var coordinate = splitString[2]
            .Replace(":", string.Empty)
            .Split(",");

        var size = splitString[3].Split("x");

        return new DataEntry(splitString[0].Remove(0, 1),
            new Coordinates(
                int.Parse(coordinate[0]),
                int.Parse(coordinate[1])),
            new Size(
                int.Parse(size[0]),
                int.Parse(size[1])));
    }
}

public record DataEntry(string Id, Coordinates Coordinates, Size Size);

public record Coordinates(int X, int Y);

public record Size(int Width, int Height);
