Part1();
Part2();

static void Part1()
{
    var input = File.ReadAllLines(@".\input.txt");
    var startTime = System.Diagnostics.Stopwatch.GetTimestamp();

    var result = 0;
    foreach (var line in input)
    {
        var split = line.Split(':')[1].Split('|');
        var winning = split[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var numbers = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var matches = Enumerable.Intersect(numbers, winning);
        var matchCount = matches.Count();
        if (matchCount > 0)
        {
            result += (int)Math.Pow(2, matchCount - 1);
        }
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
    var cards = new List<Card>();
    int id = 1;
    foreach (var line in input)
    {
        var split = line.Split(':')[1].Split('|');
        var winning = split[0].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
        var numbers = split[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToArray();
        cards.Add(new Card(id, winning, numbers));
        id++;
    }

    foreach (var card in cards)
    {
        for (int i = 0; i < card.MatchCount; i++)
        {
            var nextIndex = card.Id + i;
            if (nextIndex < cards.Count)
            {
                var nextCard = cards[nextIndex];
                nextCard.Copies += card.Copies;
            }
        }
        result += card.Copies;
    }

    var elapsedTime = System.Diagnostics.Stopwatch.GetElapsedTime(startTime);
    Console.WriteLine($"Part 2: {result}");
    System.Diagnostics.Debug.WriteLine($"Part 2: {elapsedTime}");
}

record class Card(int Id, int[] WinningNumbers, int[] ActualNumbers)
{
    public int Copies { get; set; } = 1;

    public IEnumerable<int> Matches
    {
        get
        {
            return Enumerable.Intersect(WinningNumbers, ActualNumbers);
        }
    }

    public int MatchCount
    {
        get
        {
            return Matches.Count();
        }
    }

    public bool IsWinner
    {
        get
        {
            return MatchCount > 0;
        }
    }

    public int Score
    {
        get
        {
            if (IsWinner)
            {
                return (int)Math.Pow(2, MatchCount - 1);
            }
            return 0;
        }
    }
}