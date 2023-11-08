using AOC06.Models;

namespace AOC06;
public static class Helpers
{
    public static List<Coordinate> ToListOfCoordinates(this string[] source)
    {
        var coordinates = new List<Coordinate>();

        foreach (var entry in source)
        {
            var coordinate = entry.Split(',');

            coordinates.Add(new Coordinate(coordinate[0], coordinate[1]));
        }

        return coordinates;
    }
}
