using SodukoBoard;

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
        return _board.GetAllPossibleSequences()
            .All(AreNumbersLegal);
    }
    
    public static bool IsBoardLegal(Board board)
    {
        return board.GetAllPossibleSequences()
            .All(AreNumbersLegal);
    }

    public bool IsBoardCorrect()
    {
        return _board
            .GetAllPossibleSequences()
            .All(IsCorrect);
    }
    
    public static bool IsBoardCorrect(Board board)
    {
        return board
            .GetAllPossibleSequences()
            .All(IsCorrect);
    }

    private static bool IsCorrect(IEnumerable<int> numbers)
    {
        var set = new HashSet<int>();
        foreach (var number in numbers)
        {
            if (number is < 1 or > 9)
            {
                return false;
            }
            if (set.Contains(number))
            {
                return false;
            }
            set.Add(number);
        }
        return true;
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

            var exists = set.Add(number);
            if (!exists) 
                return false;
        }
        return true;
    }
    
    public static bool IsIndexLegal(Board board, int i)
    {
        return board
            .GetAllPossibleSequencesAtIndex(i)
            .All(AreNumbersLegal);
    }
}