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
var guardAndSleptTime = new Dictionary<string, GuardData>();

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
    guardAndSleptTime[group.Key] = mostSleptMinute == null ? new GuardData() : new GuardData
    {
        MinuteMostAsleep = mostSleptMinute.Key,
        MinutesAsleep = minutesAsleep
    };
}

var mostAsleepGuard = guardAndSleptTime.OrderByDescending(s => s.Value.MinutesAsleep).First();

Console.WriteLine($"The guard with ID: {mostAsleepGuard.Key} was asleep the most. He loved sleeping a little bit extra in minute {mostAsleepGuard.Value.MinuteMostAsleep}");
Console.WriteLine($"Result: {int.Parse(mostAsleepGuard.Key) * mostAsleepGuard.Value.MinuteMostAsleep}");

record GuardData
{
    public int MinuteMostAsleep { get; set; }

    public int MinutesAsleep { get; set; }
}
