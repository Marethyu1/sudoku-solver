using SSolver.Iterators;

namespace SSolver;
public class Board
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
}                                                                                