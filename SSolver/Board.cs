using Microsoft.VisualBasic;

namespace SSolver;
using b = Box;
public class Board
{
    private readonly int[] _numbers;
    private const int Length = 81;
    private const int RowLength = 9;

    
    public Board(int[] numbers)
    {
        if (numbers.Length != Length)
        {
            throw new ArgumentException($"must be {Length}");
        }
        _numbers = numbers;
    }

    public bool IsLegal()
    {
        return IsRowsLegal() && IsColumnsLegal() && IsBoxesLegal();
    }

    private IEnumerable<IEnumerable<int>> Rows()
    {
        for (var i = 0; i < Length; i += RowLength)
        {
            var upperIndex = i + RowLength;
            yield return _numbers[i..upperIndex];
        }
    }
    
    private IEnumerable<IEnumerable<int>> Columns()
    {
        for (var i = 0; i < RowLength; i += 1)
        {
            yield return Column(i);
        }
    }

    private IEnumerable<int> Column(int startIndex)
    {
        for (var i = startIndex; i < Length; i += RowLength)
        {
            yield return _numbers[i];
        }
    }
    
    private IEnumerable<IEnumerable<int>> Boxes()
    {
        return b.Boxes().Select(Box);
    }
    
    private IEnumerable<int> Box(IEnumerable<int> boxIndexes)
    {
        return boxIndexes.Select(boxIndex => _numbers[boxIndex]);
    }

    private bool IsRowsLegal()
    {
        foreach (var row in Rows())
        {
            if (!AreNumbersLegal(row))
            {
                return false;
            }
        }
        return true;
    }

    private bool IsColumnsLegal()
    {
        foreach (var column in Columns())
        {
            if (!AreNumbersLegal(column))
            {
                return false;
            }
        }
        return true;
    }
    
    private bool IsBoxesLegal()
    {
        foreach (var box in Boxes())
        {
            Console.WriteLine(string.Join(' ', box));
            if (!AreNumbersLegal(box))
            {
                return false;
            }
        }
        return true;
    }
    
    private static bool AreNumbersLegal(IEnumerable<int> numbers)
    {
        var set = new HashSet<int>();
        foreach (var number in numbers)
        {
            switch (number)
            {
                case < 0 or > 9:
                    return false;
                case 0:
                    continue;
            }

            if (set.Contains(number))
            {
                return false;
            }

            set.Add(number);
        }
        return true;
    }
}