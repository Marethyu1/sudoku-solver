namespace SSolver.Iterators;

public interface ISequenceIterator
{
    public IEnumerable<IEnumerable<int>> GetSequences();
}