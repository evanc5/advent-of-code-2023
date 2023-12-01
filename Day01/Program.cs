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
    foreach (var line in input)
    {
        var processed = ProcessLine(line);

        var firstDigit = processed.First(char.IsDigit);
        var lastDigit = processed.Last(char.IsDigit);

        var calibrationValue = int.Parse($"{firstDigit}{lastDigit}");
        result += calibrationValue;
    }

    var elapsedTime = System.Diagnostics.Stopwatch.GetElapsedTime(startTime);
    Console.WriteLine($"Part 2: {result}");
    System.Diagnostics.Debug.WriteLine($"Part 2: {elapsedTime}");
}

static string ProcessLine(string line)  //I kind of hate this but I hate it less than a regex solution that doesn't work so I'm fine with it for now
{
    line = line.Replace("one", "o1ne");
    line = line.Replace("two", "t2wo");
    line = line.Replace("three", "thr3ee");
    line = line.Replace("four", "fo4ur");
    line = line.Replace("five", "fi5ve");
    line = line.Replace("six", "s6ix");
    line = line.Replace("seven", "se7ven");
    line = line.Replace("eight", "ei8ght");
    line = line.Replace("nine", "ni9ne");
    return line;
}
