using AOC06;
using Shared;

Console.WriteLine("AOC06 #1");

// Manhattan distance is -> d = |x1 - x2| + |y1 - y2|
var input = SharedHelpers.ReadContentAndSplitFromInputFile();
var dataObjects = input.ToListOfCoordinates();

Console.WriteLine("Test");
