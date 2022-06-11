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
        return _board.IsLegal();
    }
}