// See https://aka.ms/new-console-template for more information
Console.WriteLine("AOC 01:");

var frequency = 0;
var path = Path.Combine(Directory.GetCurrentDirectory(), "Input.txt");
var frequencyChanges = File.ReadAllText(path).Split("\r\n");

foreach (var frequencyChange in frequencyChanges) 
{
    if (int.TryParse(frequencyChange, out int result))
    {
        frequency += result;
    }
}

Console.WriteLine($"Result: {frequency}");