// See https://aka.ms/new-console-template for more information
// #1
Console.WriteLine("AOC 01#1:");

var frequency = 0;
var path = Path.Combine(Directory.GetCurrentDirectory(), "Data/input.txt");
var frequencyChanges = File.ReadAllText(path).Split("\r\n");

foreach (var frequencyChange in frequencyChanges)
{
    if (int.TryParse(frequencyChange, out int result))
    {
        frequency += result;
    }
}

Console.WriteLine($"Result: {frequency}");
Console.WriteLine("----------------------------------");

// #2
Console.WriteLine("AOC 01#2:");

frequency = 0;
var frequencies = new List<int>();
var hasOccuredTwice = false;

while (!hasOccuredTwice)
{
    foreach (var frequencyChange in frequencyChanges)
    {
        if (int.TryParse(frequencyChange, out int result))
        {
            frequency += result;

            if (frequencies.Contains(frequency))
            {
                hasOccuredTwice = true;
            }

            frequencies.Add(frequency);

            if (hasOccuredTwice)
            {
                break;
            }
        }
    }
}

Console.WriteLine($"Result: {frequencies.LastOrDefault()}");