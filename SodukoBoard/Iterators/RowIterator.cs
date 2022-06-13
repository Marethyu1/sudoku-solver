namespace SodukoBoard.Iterators;

public class RowIterator : ISequenceIterator
{
    private const int Length = Board.Length;
    private const int SequenceLength = Board.SequenceLength;
    
    
    public IEnumerable<IEnumerable<int>> GetSequences()
    {
        for (var i = 0; i < Length; i += SequenceLength) 
        {
            yield return Enumerable.Range(i, SequenceLength);
        }                                           
        
    }

    public IEnumerable<IEnumerable<int>> GetSequenceAtIndex(int index)
    {
        var columnIndex = index % 9;
        var rowIndex = (index - columnIndex) / 9;
        return GetSequences()
            .Skip(rowIndex)
            .Take(1);
    }
}