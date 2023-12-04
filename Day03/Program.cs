using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

Part1();
Part2();

static void Part1()
{
    var input = File.ReadAllLines(@".\input.txt");
    var startTime = System.Diagnostics.Stopwatch.GetTimestamp();

    var result = 0;
    var lineNumber = 0;
    var pattern = @"[^0-9.]";
    var rx = new Regex(pattern, RegexOptions.Compiled);
    foreach (var line in input)
    {
        var matches = rx.Matches(line);
        foreach (Match match in matches)
        {
            var index = match.Index;
            result += SearchForNumbers(input, index, lineNumber);
        }
        lineNumber++;
    }

    var elapsedTime = System.Diagnostics.Stopwatch.GetElapsedTime(startTime);
    Console.WriteLine($"Part 1: {result}");
    System.Diagnostics.Debug.WriteLine($"Part 1: {elapsedTime}");
}

static int SearchForNumbers(string[] input, int index, int lineNumber)
{
    var result = 0;

    var left = index - 1;
    var right = index + 1;
    var up = lineNumber - 1;
    var down = lineNumber + 1;

    for (int x = left; x <= right; x++)
    {
        if (x < 0 || x > input[index].Length) continue;
        for (int y = up; y <= down; y++)
        {
            if (y < 0 || y > input.Length) continue;
            if (char.IsDigit(input[y][x]))
            {
                //right, so I have the position of a digit, need to find the entire number
                //need to also make sure we're not double counting anything
            }
        }
    }

    return result;
}

static void Part2()
{
    var input = File.ReadAllLines(@".\input.txt");
    var startTime = System.Diagnostics.Stopwatch.GetTimestamp();

    var result = 0;
    foreach (var line in input)
    {

    }

    var elapsedTime = System.Diagnostics.Stopwatch.GetElapsedTime(startTime);
    Console.WriteLine($"Part 2: {result}");
    System.Diagnostics.Debug.WriteLine($"Part 2: {elapsedTime}");
}
