using System.Collections;
using SSolver.Iterators;

namespace SSolver;
public class Board: IEnumerable<int>
{
    private readonly int[] _numbers;
    public const int Length = 81;
    public const int SequenceLength = 9;
    private static readonly ISequenceIterator RowIterator = new RowIterator();
    private static readonly ISequenceIterator ColumnIterator = new ColumnIterator();
    private static readonly ISequenceIterator BoxIterator = new BoxIterator();

    public Board(int[] numbers)
    {
        if (numbers.Length != Length)
        {
            throw new ArgumentException($"must be {Length}");
        }
        _numbers = numbers;
    }

    public IEnumerable<IEnumerable<int>> GetAllPossibleSequences()
    {
        foreach (var row in GetRows())
        {
            yield return row;
        }

        foreach (var column in GetColumns())
        {
            yield return column;
        }

        foreach (var box in GetBoxes())
        {
            yield return box;
        }
    }

    public IEnumerable<IEnumerable<int>> GetRows()
    {
        return GetSequences(RowIterator);
    }
    
    public IEnumerable<IEnumerable<int>> GetColumns()
    {
        return GetSequences(ColumnIterator);
    }
    
    public IEnumerable<IEnumerable<int>> GetBoxes()
    {
        return GetSequences(BoxIterator);
    }

    private IEnumerable<IEnumerable<int>> GetSequences(ISequenceIterator iterator)
    {
        return iterator
            .GetSequences()
            .Select(GetNumbersAtIndexes);
    }

    private IEnumerable<int> GetNumbersAtIndexes(IEnumerable<int> indexes)
    {
        return indexes.Select(i => _numbers[i]);
    }

    public int this[int i]
    {
        get => _numbers[i];
        set => _numbers[i] = value;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return ((IEnumerable<int>)_numbers).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Display()
    {
        Console.WriteLine("------------------------------");
        foreach (var row in GetRows())
        {
            Console.WriteLine(string.Join(' ', row));
        }
        Console.WriteLine("------------------------------");
    }

    public Board GetCopy()
    {
        var copy = new int[81];
        _numbers.CopyTo(copy, 0);
        return new Board(copy);
    }
}                                                                                