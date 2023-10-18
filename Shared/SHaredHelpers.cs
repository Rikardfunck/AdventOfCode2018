namespace Shared;

public static class SharedHelpers
{
    public static string[] ReadContentFromInputFile()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "Data/input.txt");
        var fileContent = File.ReadAllText(path).Split("\r\n");

        return fileContent;
    }
}
