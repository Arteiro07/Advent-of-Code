Console.WriteLine("Day 03 - Part 1: " + part1());

Console.WriteLine("Day 03 - Part 2: " + part2());

long part1()
{
    string projectRootPath = Directory.GetCurrentDirectory();
    string inputFilePath = Path.Combine(projectRootPath, "Data/input.txt");
    string text = File.ReadAllText(inputFilePath);

    string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
    long finalValue = 0;
    foreach (string line in lines)
    {
        int auxMax = 0;
        int index = 0;
        for (int i = 0; i < line.Length - 1; i++)
        {
            int digit = line[i] - '0';
            if (digit == 9)
            {
                index = i;
                auxMax = 9;
                break;
            }
            if (digit > auxMax)
            {
                auxMax = digit;
                index = i;
            }
        }
        int solution = auxMax * 10;
        auxMax = 0;
        for (int i = index + 1; i < line.Length; i++)
        {
            int digit = line[i] - '0';
            if (digit == 9)
            {
                auxMax = 9;
                break;
            }
            if (digit > auxMax)
            {
                auxMax = digit;
                index = i;
            }
        }
        solution += auxMax;
        finalValue += solution;
    }
    return finalValue;
}

long part2()
{
    string projectRootPath = Directory.GetCurrentDirectory();
    string inputFilePath = Path.Combine(projectRootPath, "Data/input.txt");
    string text = File.ReadAllText(inputFilePath);

    string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

    long solution = 0;
    foreach (string line in lines)
    {
        int index = -1;
        for (int i = 11; i >= 0; i--)
        {
            long auxMax = 0;
            for (int j = index + 1; j < line.Length - i; j++)
            {
                int digit = line[j] - '0';
                if (digit > auxMax)
                {
                    auxMax = digit;
                    index = j;
                }
            }
            solution += auxMax * (long)Math.Pow(10, i);
        }
    }
    return solution;
}
