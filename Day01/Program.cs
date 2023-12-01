using System.Text.RegularExpressions;

Part1();
Part2();

static void Part1()
{
    var input = File.ReadAllLines(@".\input.txt");
    var startTime = System.Diagnostics.Stopwatch.GetTimestamp();

    var result = 0;
    foreach (var line in input)
    {
        var firstDigit = line.First(char.IsDigit);
        var lastDigit = line.Last(char.IsDigit);

        var calibrationValue = int.Parse($"{firstDigit}{lastDigit}");
        result += calibrationValue;
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

    var pattern = @"(?=([1-9]|one|two|three|four|five|six|seven|eight|nine))";
    var rx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
    foreach (var line in input)
    {
        var matches = rx.Matches(line);

        var firstDigit = ParseDigit(matches.First().Groups[1].Value);
        var lastDigit = ParseDigit(matches.Last().Groups[1].Value);

        var calibrationValue = int.Parse($"{firstDigit}{lastDigit}");
        result += calibrationValue;
    }

    var elapsedTime = System.Diagnostics.Stopwatch.GetElapsedTime(startTime);
    Console.WriteLine($"Part 2: {result}");
    System.Diagnostics.Debug.WriteLine($"Part 2: {elapsedTime}");
}

static string ParseDigit(string digit)
{
    var result = digit switch
    {
        "one" => "1",
        "two" => "2",
        "three" => "3",
        "four" => "4",
        "five" => "5",
        "six" => "6",
        "seven" => "7",
        "eight" => "8",
        "nine" => "9",
        _ => digit
    };
    return result;
}