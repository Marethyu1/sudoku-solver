namespace SSolver.Iterators;

public class ColumnIterator: ISequenceIterator
{
    private const int Length = Board.Length;
    private const int SequenceLength = Board.SequenceLength;
    
    
    public IEnumerable<IEnumerable<int>> GetSequences()
    {
        for (var i = 0; i < SequenceLength; i ++)
        {
            yield return GetColumnIndexes(i);
        }                                           
    }
    
    private static IEnumerable<int> GetColumnIndexes(int startIndex)            
    {                                                             
        for (var i = startIndex; i < Length; i += SequenceLength) 
        {                                                         
            yield return i;                             
        }                                                         
    }                                                             
}