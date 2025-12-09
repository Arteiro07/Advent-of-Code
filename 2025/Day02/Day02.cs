Console.WriteLine("Day 02 - Part 1: " + part1());

Console.WriteLine("Day 02 - Part 2: " + part2());

long part1()
{
    string projectRootPath = Directory.GetCurrentDirectory();
    string inputFilePath = Path.Combine(projectRootPath, "Data/input.txt");
    string text = File.ReadAllText(inputFilePath);

    string[] pairs = text.Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

    List<(string Start, string End)> ranges = pairs
        .Select(pair =>
        {
            var bounds = pair.Split('-');
            return (bounds[0], bounds[1]);
        })
        .ToList();

    long solution = 0;

    foreach (var (start, end) in ranges)
    {
        string startValue = start;
        string endValue = end;

        if (start.Length % 2 != 0)
        {
            startValue = "1".PadRight(start.Length + 1, '0');
        }
        if (end.Length % 2 != 0)
        {
            endValue = "9".PadRight(end.Length - 1, '9');
        }

        while (long.Parse(startValue) <= long.Parse(endValue))
        {
            if (startValue.Length % 2 != 0)
            {
                startValue = "1".PadRight(start.Length + 1, '0');
            }

            if (
                long.Parse(startValue.Substring(0, startValue.Length / 2))
                == long.Parse(startValue.Substring(startValue.Length / 2))
            )
            {
                solution += long.Parse(startValue);
            }

            startValue = (long.Parse(startValue) + 1).ToString();
        }
    }

    return solution;
}

long part2()
{
    string projectRootPath = Directory.GetCurrentDirectory();
    string inputFilePath = Path.Combine(projectRootPath, "Data/input.txt");
    string text = File.ReadAllText(inputFilePath);

    string[] pairs = text.Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

    List<(string Start, string End)> ranges = pairs
        .Select(pair =>
        {
            var bounds = pair.Split('-');
            return (bounds[0], bounds[1]);
        })
        .ToList();

    long solution = 0;

    foreach (var (start, end) in ranges)
    {
        string startValue = start;
        string endValue = end;

        while (long.Parse(startValue) <= long.Parse(endValue))
        {
            for (int i = 1; i <= startValue.Length / 2; i++)
            {
                if (startValue.Length % i != 0)
                {
                    continue;
                }

                string currVal = startValue.Substring(0, i);

                string testVal = "";

                for (int j = 0; j < startValue.Length / i; j++)
                {
                    testVal += currVal;
                }
                if (long.Parse(testVal) == long.Parse(startValue))
                {
                    solution += long.Parse(startValue);
                    break;
                }
            }

            startValue = (long.Parse(startValue) + 1).ToString();
        }
    }

    return solution;
}
