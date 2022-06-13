namespace SodukoBoard.Iterators;

public interface ISequenceIterator
{
    public IEnumerable<IEnumerable<int>> GetSequences();
    IEnumerable<IEnumerable<int>> GetSequenceAtIndex(int i);
}