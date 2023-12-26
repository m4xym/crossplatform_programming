using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Lab5_MVC
{
    public class Labs
    {
        public static string Lab1(string inputString)
        {
            
            int inputNumber = 0;
            int positionOfPermutation = 0;

            string[] lines = inputString.Split("\r\n");

            if (Int32.TryParse(lines[0], out inputNumber) && Int32.TryParse(lines[1], out positionOfPermutation))
            {
                if (inputNumber >= 1 && inputNumber <= 12 && positionOfPermutation >= 1 && positionOfPermutation <= FactRec(inputNumber))
                {
                    List<List<int>> permutations = GetPermutations(inputNumber);
                    var res = string.Join(" ", permutations[positionOfPermutation]);
                    return res;
                }
                else
                {
                    return "Invalid values";
                }
            }
            else
            {
                return "Invalid number format";
            }

            static List<List<int>> GetPermutations(int n)
            {
                List<List<int>> result = new List<List<int>>();
                List<int> numbers = Enumerable.Range(1, n).ToList();
                PermuteHelper(numbers, 0, result);
                return result;
            }

            static void PermuteHelper(List<int> numbers, int startIndex, List<List<int>> result)
            {
                if (startIndex == numbers.Count - 1)
                {
                    result.Add(new List<int>(numbers));
                    return;
                }

                for (int i = startIndex; i < numbers.Count; i++)
                {
                    Swap(numbers, startIndex, i);
                    PermuteHelper(numbers, startIndex + 1, result);
                    Swap(numbers, startIndex, i);
                }
            }

            static void Swap(List<int> list, int i, int j)
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }

            static int FactRec(int n)
            {
                if (n == 1 || n == 0)
                    return n;
                else
                    return n * FactRec(n - 1);
            }
        }

        public static string Lab2(string inputString)
        {
            int[,] a;
            int n;

            string[] lines = inputString.Split('\n');

            if (!int.TryParse(lines[0], out n) || n < 1 || n > 50)
            {
                return "Invalid value of N";
            }

            a = new int[n + 1, n + 1];

            for (int i = 1; i <= n; i++)
            {
                string[] line = lines[i].Split();
                for (int j = 1; j <= n; j++)
                {
                    if (!int.TryParse(line[j - 1], out a[i, j]) || int.Parse(line[j - 1]) < 1 || int.Parse(line[j - 1]) > 50)
                    {
                        return "Invalid value of a";
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

            return max[n, n].ToString();
        }

        public static string Lab3(string inputString)
        {
            string[] input = inputString.Split('\n');
            string[] dimensions = input[0].Split(' ');
            int W = int.Parse(dimensions[0]);
            int H = int.Parse(dimensions[1]);

            // 1 ≤ W, H≤ 75
            if (W < 1 || H < 1 || H > 75)
            {
                return "Invalid values of W or H";
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

                    if (query[0] == 0 && query[1] == 0 && query[2] == 0 && query[3] == 0)
                    {
                        break;
                    }
                    // 1 ≤ X1, X2 ≤ W, 1 ≤ Y1, Y2 ≤ H
                    if (query[0] < 1 || query[2] > W || query[1] < 1 || query[3] > H)
                    {
                        return "Invalid values of the query";
                    }
                    
                    queries.Add(query);
                }
            }

            List<int> result = new List<int>();

            foreach (var query in queries)
            {
                int shortestPath = ShortestPath(expandedGrid, (query[1], query[0]), (query[3], query[2]));
                result.Add(shortestPath);
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

            return string.Join("\n", result);
        }
    }
}