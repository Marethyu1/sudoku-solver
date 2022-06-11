namespace SSolver.Iterators;

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
}