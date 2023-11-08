using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AOC04.Models;

namespace AOC04;

public static class Extensions
{
    public static IEnumerable<DataEntry> RawInputToListOfObjects(this string[] rawInput)
    {
        var dataEntries = new List<DataEntry>();
        foreach (var dataEntryString in rawInput)
        {
            dataEntries.Add(dataEntryString.ConvertToDataObject()!);
        }

        return dataEntries.AsEnumerable();
    }

    private static DataEntry ConvertToDataObject(this string rawData)
    {
        var data = rawData.Split("] ");

        data[0] = data[0]
            .Replace("[", string.Empty)
            .Replace("]", string.Empty);

        if (!DateTime.TryParse(data[0], out var result))
            return default;

        return (data[1].Contains("begins shift"), data[1].Contains("falls asleep"), data[1].Contains("wakes up")) switch
        {
            (true, _, _) => ConstructDataEntry(result, data[1], true, false, false, true),
            (_, true, _) => ConstructDataEntry(result, data[1], false, false, true, false),
            (_, _, true) => ConstructDataEntry(result, data[1], false, true, false, false),
            _ => throw new InvalidDataException()
        };
    }

    private static DataEntry ConstructDataEntry(DateTime date, string dataString, bool includeId, bool wakesUp, bool fallsAsleep, bool beginsShift)
    {
        var id = string.Empty;
        if (includeId)
        {
            id = dataString.Split(" ")[1].Remove(0, 1);
        }

        return new DataEntry()
        {
            Date = date,
            GuardId = id,
            WakesUp = wakesUp,
            FallsAsleep = fallsAsleep,
            BeginsShift = beginsShift
        };
    }
}
