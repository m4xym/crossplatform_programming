int[,] a;
int n;

using (StreamReader reader = new StreamReader("INPUT.txt"))
{
    if (!int.TryParse(reader.ReadLine(), out n) || n < 1 || n > 50)
    {
        Console.WriteLine("Invalid value of N");
        return;
    }

    a = new int[n + 1, n + 1];

    for (int i = 1; i <= n; i++)
    {
        string[] line = reader.ReadLine().Split();
        for (int j = 1; j <= n; j++)
        {
            if (!int.TryParse(line[j - 1], out a[i, j]) || int.Parse(line[j - 1]) < 1 || int.Parse(line[j - 1]) > 50)
            {
                Console.WriteLine("Invalid value of a");
                return;
            }
        }
    }
}

int[,] max = new int[n + 1, n + 1];

for (int i = 1; i <= n; i++)
{
    for (int j = 0; j <= n; j++)
    {
        max[i, j] = max[i - 1, j];

        for (int k = 1; k <= j; k++)
        {
            if (max[i, j] < a[k, i] + max[i - 1, j - k])
            {
                max[i, j] = a[k, i] + max[i - 1, j - k];
            }
        }
    }
}

using (StreamWriter writer = new StreamWriter("OUTPUT.txt"))
{
    writer.WriteLine(max[n, n]);
}
