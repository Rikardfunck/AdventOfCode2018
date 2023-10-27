using Shared;

Console.WriteLine("AOC05 #1:");

var input = SharedHelpers.ReadContentAndSplitFromInputFile(separator: "").First();
var wholeStringProcessed = false;

// Is correct but need to optimize this as much as possible
while (!wholeStringProcessed)
{
    for (int i = 0; i < input.Length; i++)
    {
        if (input.ElementAtOrDefault(i + 1) != default(char))
        {
            var upperCaseCurrent = Char.ToUpper(input[i]);
            var upperCaseNext = Char.ToUpper(input[i + 1]);

            if (upperCaseCurrent == upperCaseNext)
            {
                if (Char.IsUpper(input[i]) != Char.IsUpper(input[i + 1]))
                {
                    input = input.Remove(i, 2);
                    Console.WriteLine($"String lenght: {input.Length}");

                    break;
                }
            }
        }

        if (i == (input.Length - 1))
        {
            wholeStringProcessed = true;
        }
    }
}

Console.WriteLine($"Result: {input}");

/*
 * Make a method which implements the removing logic
 * Loop through each character in the string and check against the next one if its not the last
 * When an alternation of the string happens, mutate and restart loop
 */
