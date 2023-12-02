Part1();
Part2();

static void Part1()
{
    var input = File.ReadAllLines(@".\input.txt");
    var startTime = System.Diagnostics.Stopwatch.GetTimestamp();

    var cubeBag = new Dictionary<string, int>()
    {
        {"red", 12},
        {"green", 13},
        {"blue", 14}
    };
    var result = 0;
    var id = 1;
    foreach (var line in input)
    {
        var games = line.Split(':')[1].Split(';');
        var possible = true;
        foreach (var game in games)
        {
            var currentBag = cubeBag.ToDictionary();
            var moves = game.Trim().Split(',');
            foreach (var move in moves)
            {
                var split = move.Trim().Split(' ');
                var count = int.Parse(split[0]);
                var color = split[1];
                currentBag[color] -= count;
            }
            if (currentBag.Any(v => v.Value < 0))
            {
                possible = false;
                break;
            }
        }
        if (possible)
        {
            result += id;
        }
        id++;
    }

    var elapsedTime = System.Diagnostics.Stopwatch.GetElapsedTime(startTime);
    Console.WriteLine($"Part 1: {result}");
    System.Diagnostics.Debug.WriteLine($"Part 1: {elapsedTime}");
}

static void Part2()
{
    var input = File.ReadAllLines(@".\input.txt");
    var startTime = System.Diagnostics.Stopwatch.GetTimestamp();

    var emptyBag = new Dictionary<string, int>()
    {
        {"red", 0},
        {"green", 0},
        {"blue", 0}
    };
    var result = 0;
    foreach (var line in input)
    {
        var games = line.Split(':')[1].Split(';');
        var currentMin = emptyBag.ToDictionary();
        foreach (var game in games)
        {
            var currentBag = emptyBag.ToDictionary();
            var moves = game.Trim().Split(',');
            foreach (var move in moves)
            {
                var split = move.Trim().Split(' ');
                var count = int.Parse(split[0]);
                var color = split[1];
                currentBag[color] += count;
            }
            currentMin["red"] = Math.Max(currentMin["red"], currentBag["red"]);
            currentMin["green"] = Math.Max(currentMin["green"], currentBag["green"]);
            currentMin["blue"] = Math.Max(currentMin["blue"], currentBag["blue"]);
        }
        var power = currentMin["red"] * currentMin["green"] * currentMin["blue"];
        result += power;
    }

    var elapsedTime = System.Diagnostics.Stopwatch.GetElapsedTime(startTime);
    Console.WriteLine($"Part 2: {result}");
    System.Diagnostics.Debug.WriteLine($"Part 2: {elapsedTime}");
}

