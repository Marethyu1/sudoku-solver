using SodukoBoard;

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
        if (_count % 10000 == 0)
        {
            // _board.Display();
        }
        for (var i = 0; i < Board.Length; i++)
        {
            if (_board[i] != 0) continue;
            
            for (var j = 1; j < 10; j++)
            {
                _board[i] = j;
                // _board.Display();
                if (BoardValidator.IsIndexLegal(_board, i))
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

        return true;
    }

    public Board Solve()
    {
        RecursiveSolve();
        _board.Display();
        if (!BoardValidator.IsBoardCorrect(_board))
        {
            throw new Exception("Board wasn't legal");
        }
        return _board;
    }
}