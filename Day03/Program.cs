using System.Text.RegularExpressions;

Part1();
Part2();

static void Part1()
{
    var input = File.ReadAllLines(@".\input.txt");
    var startTime = System.Diagnostics.Stopwatch.GetTimestamp();

    var result = 0;
    var lineNumber = 0;
    var pattern = @"[0-9]+";
    var rx = new Regex(pattern, RegexOptions.Compiled);
    foreach (var line in input)
    {
        var matches = rx.Matches(line);
        foreach (Match number in matches)
        {
            var index = number.Index;
            if (IsPartNumber(number, input, lineNumber))
            {
                result += int.Parse(number.Value);
            }
        }
        lineNumber++;
    }

    var elapsedTime = System.Diagnostics.Stopwatch.GetElapsedTime(startTime);
    Console.WriteLine($"Part 1: {result}");
    System.Diagnostics.Debug.WriteLine($"Part 1: {elapsedTime}");
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

static bool IsPartNumber(Match number, string[] input, int lineNumber)
{
    var rx = FindSymbols();

    var index = number.Index;
    var length = number.Length;

    var up = lineNumber - 1;
    var down = lineNumber + 1;

    var left = index - 1;
    if (left < 0) left = index;

    var right = index + length;
    if (right >= input[lineNumber].Length) right = input[lineNumber].Length - 1;

    if (up > 0)
    {
        var lineAbove = input[up];
        var searchLength = length + 2;
        if (left + searchLength >= lineAbove.Length) searchLength--;    //I hate this but lineAbove[left..right] didn't work
        var adjacentAbove = lineAbove.Substring(left, searchLength);
        if (rx.IsMatch(adjacentAbove)) return true;
    }
    if (down < input.Length)
    {
        var lineBelow = input[down];
        var searchLength = length + 2;
        if (left + searchLength >= lineBelow.Length) searchLength--;
        var adjacentBelow = lineBelow.Substring(left, searchLength);
        if (rx.IsMatch(adjacentBelow)) return true;
    }

    if (rx.IsMatch(input[lineNumber][left].ToString())) return true;
    if (rx.IsMatch(input[lineNumber][right].ToString())) return true;

    return false;
}

partial class Program
{
    [GeneratedRegex(@"[^0-9.]", RegexOptions.Compiled)]
    private static partial Regex FindSymbols();
}