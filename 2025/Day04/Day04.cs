Console.WriteLine("Day 04 - Part 1: " + part1());

Console.WriteLine("Day 04 - Part 2: " + part2());

long part1()
{
    string projectRootPath = Directory.GetCurrentDirectory();
    string inputFilePath = Path.Combine(projectRootPath, "Data/input.txt");
    string text = File.ReadAllText(inputFilePath);

    char[][] grid = text.Split('\n', StringSplitOptions.RemoveEmptyEntries)
        .Select(line => line.TrimEnd('\r').ToCharArray())
        .ToArray();

    long solution = 0;
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            int count = 0;
            if (grid[i][j] == '@')
            {
                if (i > 0)
                {
                    if (grid[i - 1][j] == '@')
                        count++;
                }
                if (i < grid.Length - 1)
                {
                    if (grid[i + 1][j] == '@')
                        count++;
                }
                if (j > 0)
                {
                    if (grid[i][j - 1] == '@')
                        count++;
                }
                if (j < grid[i].Length - 1)
                {
                    if (grid[i][j + 1] == '@')
                        count++;
                }
                if (j > 0 && i > 0)
                {
                    if (grid[i - 1][j - 1] == '@')
                        count++;
                }
                if (j < grid[i].Length - 1 && i > 0)
                {
                    if (grid[i - 1][j + 1] == '@')
                        count++;
                }
                if (j > 0 && i < grid.Length - 1)
                {
                    if (grid[i + 1][j - 1] == '@')
                        count++;
                }
                if (j < grid[i].Length - 1 && i < grid.Length - 1)
                {
                    if (grid[i + 1][j + 1] == '@')
                        count++;
                }

                if (count < 4)
                {
                    solution++;
                }
            }
        }
    }
    return solution;
}

long part2()
{
    string projectRootPath = Directory.GetCurrentDirectory();
    string inputFilePath = Path.Combine(projectRootPath, "Data/input.txt");
    string text = File.ReadAllText(inputFilePath);

    char[][] grid = text.Split('\n', StringSplitOptions.RemoveEmptyEntries)
        .Select(line => line.TrimEnd('\r').ToCharArray())
        .ToArray();

    long solution = 0;
    int changed = -1;
    char[][] auxiliaryGrid = grid.Select(line => line.ToArray()).ToArray();
    while (changed != 0)
    {
        changed = 0;
        grid = auxiliaryGrid.Select(line => line.ToArray()).ToArray();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                int count = 0;
                if (grid[i][j] == '@')
                {
                    if (i > 0)
                    {
                        if (grid[i - 1][j] == '@')
                            count++;
                    }
                    if (i < grid.Length - 1)
                    {
                        if (grid[i + 1][j] == '@')
                            count++;
                    }
                    if (j > 0)
                    {
                        if (grid[i][j - 1] == '@')
                            count++;
                    }
                    if (j < grid[i].Length - 1)
                    {
                        if (grid[i][j + 1] == '@')
                            count++;
                    }
                    if (j > 0 && i > 0)
                    {
                        if (grid[i - 1][j - 1] == '@')
                            count++;
                    }
                    if (j < grid[i].Length - 1 && i > 0)
                    {
                        if (grid[i - 1][j + 1] == '@')
                            count++;
                    }
                    if (j > 0 && i < grid.Length - 1)
                    {
                        if (grid[i + 1][j - 1] == '@')
                            count++;
                    }
                    if (j < grid[i].Length - 1 && i < grid.Length - 1)
                    {
                        if (grid[i + 1][j + 1] == '@')
                            count++;
                    }

                    if (count < 4)
                    {
                        auxiliaryGrid[i][j] = 'X';
                        changed++;
                        solution++;
                    }
                }
            }
        }
    }

    return solution;
}
