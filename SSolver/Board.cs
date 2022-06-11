namespace SSolver;
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

    public IEnumerable<IEnumerable<int>> GetRows()
    {
        for (var i = 0; i < Length; i += RowLength)
        {
            var upperIndex = i + RowLength;
            yield return _numbers[i..upperIndex];
        }
    }
    
    public IEnumerable<IEnumerable<int>> GetColumns()
    {
        for (var i = 0; i < RowLength; i += 1)
        {
            yield return GetColumn(i);
        }
    }

    private IEnumerable<int> GetColumn(int startIndex)
    {
        for (var i = startIndex; i < Length; i += RowLength)
        {
            yield return _numbers[i];
        }
    }
    
    public IEnumerable<IEnumerable<int>> GetBoxes()
    {
        return Box.Boxes().Select(GetBox);
    }
    
    private IEnumerable<int> GetBox(IEnumerable<int> boxIndexes)
    {
        return boxIndexes.Select(boxIndex => _numbers[boxIndex]);
    }
}