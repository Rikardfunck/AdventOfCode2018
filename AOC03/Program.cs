// #1
using AOC03;
using Shared;

Console.WriteLine("AOC03 #1:");

var dataEntries = SharedHelpers
    .ReadContentAndSplitFromInputFile()
    .RawInputToListOfObjects();

var squareMeters = Helpers.Create2DArray(1000, 1000)
    .InputEntriesInMatrix(dataEntries)
    .GetOverlappingSquareMeters();

Console.WriteLine($"Result: {squareMeters}");
Console.WriteLine("-------------------------------------------");
Console.WriteLine("AOC03 #2:");

var id = Helpers.Create2DArray(1000, 1000)
    .InputEntriesInMatrix(dataEntries)
    .GetWhichIdIsNotOverlapping(dataEntries);

Console.WriteLine($"Result: {id}");
