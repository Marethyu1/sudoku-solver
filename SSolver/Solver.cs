namespace SSolver;

public class Solver
{
    private readonly Board _board;
    private readonly BoardValidator _boardValidator;
    private int _count = 0;

    public Solver(Board board)
    {
        _board = board;
        _boardValidator = new BoardValidator(board);
    }

    public bool RecursiveSolve()
    {
        _count += 1;
        if (_count % 1000 == 0)
        {
            _board.Display();
        }
        for (var i = 0; i < Board.Length; i++)
        {
            if (_board[i] == 0)
            {
                for (var j = 1; j < 10; j++)
                {
                    _board[i] = j;
                    // _board.Display();
                    if (BoardValidator.IsBoardLegal(_board))
                    {
                        if (RecursiveSolve())
                        {
                            return true;
                        }
                        _board[i] = 0;
                    }
                    else
                    {
                        _board[i] = 0;
                    }
                }

                return false;
            }
        }

        return true;
    }

    public Board Solve()
    {
        RecursiveSolve();
        _board.Display();
        return _board;
    }
}