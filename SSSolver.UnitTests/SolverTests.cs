using SSolver;

namespace SSSolver.UnitTests;

public class SolverTests
{
    [Fact]
    public void CanSolveOneMissing()
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
    
    [Fact]
    public void CanSolveTwoMissing()
    {
        var board = ExampleBoards.CorrectBoard();
        board[0] = 0;
        board[1] = 0;
        var boardValidator = new BoardValidator(board);
        Assert.True(boardValidator.IsBoardLegal());
        Assert.False(boardValidator.IsBoardCorrect());

        var solver = new Solver(board);
        var solvedBoard = solver.Solve();
        Assert.True(new BoardValidator(solvedBoard).IsBoardCorrect());
    }
    
    [Fact]
    public void CanSolveTwoMissingAtEnd()
    {
        var board = ExampleBoards.CorrectBoard();
        board[0] = 0;
        board[80] = 0;
        var boardValidator = new BoardValidator(board);
        Assert.True(boardValidator.IsBoardLegal());
        Assert.False(boardValidator.IsBoardCorrect());

        var solver = new Solver(board);
        var solvedBoard = solver.Solve();
        Assert.True(new BoardValidator(solvedBoard).IsBoardCorrect());
    }
    
    [Fact]
    public void CanSolveRandomMissing()
    {
        var board = ExampleBoards.CorrectBoard();
        board[0] = 0;
        board[5] = 0;
        board[15] = 0;
        board[30] = 0;
        board[35] = 0;
        board[40] = 0;
        board[80] = 0;
        
        var boardValidator = new BoardValidator(board);
        Assert.True(boardValidator.IsBoardLegal());
        Assert.False(boardValidator.IsBoardCorrect());

        var solver = new Solver(board);
        var solvedBoard = solver.Solve();
        Assert.True(new BoardValidator(solvedBoard).IsBoardCorrect());
    }
}