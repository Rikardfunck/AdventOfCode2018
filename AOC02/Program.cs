using AOC02;
using Shared;

// #1
Console.WriteLine("AOC 02#1:");

var lines = SharedHelpers.ReadContentFromInputFile();
var threeOccurances = 0;
var twoOccurances = 0;

foreach (var line in lines)
{
    var numbers = new Dictionary<char, int>();
    foreach (char character in line)
    {
        if (!numbers.TryAdd(character, 1)) 
        {
            numbers[character]++;
        }
    }

    if (numbers.ContainsValue(2))
    {
        twoOccurances++;
    }
    
    if (numbers.ContainsValue(3))
    {
        threeOccurances++;
    }
}

Console.WriteLine($"Result (Checksum): {twoOccurances * threeOccurances}");
Console.WriteLine("--------------------------------------------------");

// #2
Console.WriteLine("AOC #2:");

var similarIsFound = false;
var mergedLine = string.Empty;

foreach (var line in lines)
{
    foreach (var innerLine in lines)
    {
        mergedLine = Helpers.JoinStringsWhereSimilar(innerLine, line);

        if (mergedLine.Length == innerLine.Length - 1)
        {
            similarIsFound = true;
            break;
        }
    }
    
    if (similarIsFound)
    {
        break;
    }
}

Console.WriteLine($"Result: {mergedLine}");