namespace SSolver;

public class Solver
{
    private readonly Board _board;
    private readonly BoardValidator _boardValidator;

    public Solver(Board board)
    {
        _board = board;
        _boardValidator = new BoardValidator(board);
    }

    public Board Solve()
    {
        
        for (var boardIndex = 0; boardIndex < Board.Length; boardIndex++)
        {
            var number = _board[boardIndex];
            if (number != 0)
            {
                continue;
            }

            for (var possibleNumber = 1; possibleNumber < 10; possibleNumber++)
            {
                _board[boardIndex] = possibleNumber;
                if (_boardValidator.IsBoardCorrect())
                {
                    return _board;
                }
            }
        }
        
        return _board;
    }
}