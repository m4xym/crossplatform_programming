string[] input = File.ReadAllLines("INPUT.txt");
string[] dimensions = input[0].Split(' ');
int W = int.Parse(dimensions[0]);
int H = int.Parse(dimensions[1]);

// 1 ≤ W, H≤ 75
if (W < 1 || H < 1 || H > 75)
{
    Console.WriteLine("Invalid values of W or H");
    return;
}

char[,] grid = new char[H, W];

for (int i = 1; i <= H; i++)
{
    string row = input[i];
    for (int j = 0; j < W; j++)
    {
        grid[i - 1, j] = row[j];
    }
}

int expandedW = W + 2;
int expandedH = H + 2;
char[,] expandedGrid = new char[expandedH, expandedW];

for (int i = 0; i < expandedH; i++)
{
    for (int j = 0; j < expandedW; j++)
    {
        if (i == 0 || i == expandedH - 1 || j == 0 || j == expandedW - 1)
        {
            expandedGrid[i, j] = '.';
        }
        else
        {
            expandedGrid[i, j] = grid[i - 1, j - 1];
        }
    }
}

List<List<int>> queries = new List<List<int>>();
for (int i = H + 1; i < input.Length; i++)
{
    string[] queryData = input[i].Split(' ');

    if (queryData.Length == 4)
    {
        List<int> query = new List<int>();
        for (int j = 0; j < 4; j++)
        {
            query.Add(int.Parse(queryData[j]));
        }

        // 1 ≤ X1, X2 ≤ W, 1 ≤ Y1, Y2 ≤ H
        if (query[0] < 1 || query[2] > W || query[1] < 1 || query[3] > H)
        {
            Console.WriteLine("Invalid values of the query");
            return;
        }
        if (query[0] == 0 && query[1] == 0 && query[2] == 0 && query[3] == 0)
        {
            break;
        }
            
        queries.Add(query);
    }
}

using (StreamWriter writer = new StreamWriter("OUTPUT.txt"))
{
    foreach (var query in queries)
    {
        int shortestPath = ShortestPath(expandedGrid, (query[1], query[0]), (query[3], query[2]));
        writer.WriteLine(shortestPath);
    }
}


static int ShortestPath(char[,] grid, (int, int) start, (int, int) end)
{
    int rows = grid.GetLength(0);
    int cols = grid.GetLength(1);

    int[] rowOffsets = { -1, 1, 0, 0 };
    int[] colOffsets = { 0, 0, -1, 1 };

    var priorityQueue = new List<(int, int, int)>();

    var distances = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            distances[i, j] = int.MaxValue;
        }
    }

    distances[start.Item1, start.Item2] = 0;
    priorityQueue.Add((start.Item1, start.Item2, 0));

    while (priorityQueue.Count > 0)
    {
        priorityQueue.Sort((a, b) => a.Item3 - b.Item3);

        var (row, col, dist) = priorityQueue[0];
        priorityQueue.RemoveAt(0);

        if ((row, col) == end)
        {
            return dist;
        }

        for (int i = 0; i < 4; i++)
        {
            int newRow = row + rowOffsets[i];
            int newCol = col + colOffsets[i];

            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
            {
                if ((newRow, newCol) == end)
                {
                    return dist + 1;
                }

                int altDistance = dist + 1;

                if (altDistance < distances[newRow, newCol] && grid[newRow, newCol] == '.')
                {
                    distances[newRow, newCol] = altDistance;
                    priorityQueue.Add((newRow, newCol, altDistance));
                }
            }
        }
    }

    return 0;
}
