string inputFilePath = "INPUT.txt";
string outputFilePath = "OUTPUT.txt";
int inputNumber = 0;
int positionOfPermutation = 0;

string[] lines = File.ReadAllLines(inputFilePath);

if (Int32.TryParse(lines[0], out inputNumber) && Int32.TryParse(lines[1], out positionOfPermutation))
{
    if (inputNumber >= 1 && inputNumber <= 12 && positionOfPermutation >= 1 && positionOfPermutation <= FactRec(inputNumber))
    {
        List<List<int>> permutations = GetPermutations(inputNumber);
        File.WriteAllText(outputFilePath, string.Join(" ", permutations[positionOfPermutation]));
    }
}
else
{
    Console.WriteLine("Invalid number format");
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