namespace SodukoBoard.Iterators;

public class BoxIterator: ISequenceIterator
{
    private static readonly int[][] SequenceIndexes = {
        new[] { 0, 1, 2, 9, 10, 11, 18, 19, 20 },
        new[] { 3, 4, 5, 12, 13, 14, 21, 22, 23 },
        new[] { 6, 7, 8, 15, 16, 17, 24, 25, 26 },
        new[] { 27, 28, 29, 36, 37, 38, 45, 46, 47 },
        new[] { 30, 31, 32, 39, 40, 41, 48, 49, 50 },
        new[] { 33, 34, 35, 42, 43, 44, 51, 52, 53 },
        new[] { 54, 55, 56, 63, 64, 65, 72, 73, 74 },
        new[] { 57, 58, 59, 66, 67, 68, 75, 76, 77 },
        new[] { 60, 61, 62, 69, 70, 71, 78, 79, 80 }
    };

    public IEnumerable<IEnumerable<int>> GetSequences()
    {
        return SequenceIndexes;
    }

    public IEnumerable<IEnumerable<int>> GetSequenceAtIndex(int index)
    {
        return SequenceIndexes.Where(t => t.Contains(index));
    }
}