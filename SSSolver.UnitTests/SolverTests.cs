using SSolver;

namespace SSSolver.UnitTests;

public class SolverTests
{
    [Fact]
    public void CanSolve()
    {
        var board = ExampleBoards.CorrectBoard();
        board[0] = 0;
        var boardValidator = new BoardValidator(board);
        Assert.True(boardValidator.IsBoardLegal());
        Assert.False(boardValidator.IsBoardCorrect());

        var solver = new Solver(board);
        var solvedBoard = solver.Solve();
        Assert.True(new BoardValidator(solvedBoard).IsBoardCorrect());
        
    }
}