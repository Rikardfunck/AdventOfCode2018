using AOC04;
using Shared;

Console.WriteLine("AOC04 #1:");

var input = SharedHelpers
    .ReadContentFromInputFile()
    .RawInputToListOfObjects();

var sortedInput = input.OrderBy(s => s.Date).ToList();
var currentGuardId = string.Empty;

for (int i = 0; i < sortedInput.Count; i++)
{
    if (!string.IsNullOrEmpty(sortedInput[i].GuardId))
    {
        currentGuardId = sortedInput[i].GuardId;
    }

    sortedInput[i].GuardId = currentGuardId;
}

var groupedSchedulesOnGuardId = sortedInput.GroupBy(item => item.GuardId).ToList();
var guardsAndSleptTime = new List<GuardData>();

foreach (var group in groupedSchedulesOnGuardId)
{
    var minutesSleeping = new List<int>();
    var minutesAsleep = 0;
    
    for (int i = 0; i < group.Count(); i++)
    {
        var currentGroup = group.ToList();
        if (currentGroup[i].FallsAsleep)
        {
            var diff = currentGroup[i + 1].Date - currentGroup[i].Date;

            for (int j = currentGroup[i].Date.Minute; j < currentGroup[i].Date.AddMinutes(diff.Minutes).Minute; j++)
            {
                minutesSleeping.Add(j);
                minutesAsleep++;
            }
        }
    }

    var mostSleptMinute = minutesSleeping.ToArray().GroupBy(minute => minute).OrderByDescending(s => s.Count()).FirstOrDefault();
    guardsAndSleptTime.Add(mostSleptMinute == null ? new GuardData() : new GuardData
    {
        GuardId = group.Key,
        MinuteMostAsleep = mostSleptMinute.Key,
        MinutesAsleep = minutesAsleep,
        MinuteMostAsleepCount = mostSleptMinute.Count()
    });
}

var mostAsleepGuard = guardsAndSleptTime.OrderByDescending(s => s.MinutesAsleep).First();

Console.WriteLine($"The guard with ID: {mostAsleepGuard.GuardId} was asleep the most. He loved sleeping a little bit extra in minute {mostAsleepGuard.MinuteMostAsleep}");
Console.WriteLine($"Result: {int.Parse(mostAsleepGuard.GuardId) * mostAsleepGuard.MinuteMostAsleep}");
Console.WriteLine("--------------------------------------------------------------------------------");

// #2
var guardMostFrequentlySleepingSameMinute = guardsAndSleptTime.OrderByDescending(s => s.MinuteMostAsleepCount).First();

Console.WriteLine($"Result: {guardMostFrequentlySleepingSameMinute.MinuteMostAsleep * int.Parse(guardMostFrequentlySleepingSameMinute.GuardId)}");

record GuardData
{
    public string GuardId { get; set; }

    public int MinuteMostAsleep { get; set; }

    public int MinuteMostAsleepCount { get; set; }

    public int MinutesAsleep { get; set; }
}
