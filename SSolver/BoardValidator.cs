namespace SSolver;

public class BoardValidator
{
    private readonly Board _board;

    public BoardValidator(Board board)
    {
        _board = board;
    }
    
    public bool IsBoardLegal()
    {
        return AreRowsLegal() && AreColumnsLegal() && AreBoxesLegal();
    }

    private static bool AreSequencesLegal(IEnumerable<IEnumerable<int>> sequences)
    {
        return sequences.All(AreNumbersLegal);
    }

    private bool AreBoxesLegal()
    {
        return AreSequencesLegal(_board.GetBoxes());
    }

    private bool AreColumnsLegal()
    {
        return AreSequencesLegal(_board.GetColumns());
    }

    private bool AreRowsLegal()
    {
        return AreSequencesLegal(_board.GetRows());
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