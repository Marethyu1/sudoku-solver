using System.Diagnostics;
using SodukoBoard;
using SSolver;
using Xunit.Abstractions;

namespace SSSolver.UnitTests;

public class SolverTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SolverTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

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

    [Fact]
    public void HardBoard()
    {
        var numbers = new[]
        {
            0, 0, 0,  0, 3, 1,  0, 0, 0,
            0, 0, 0,  0, 0, 0,  0, 0, 3,
            0, 0, 1,  0, 7, 0,  0, 8, 2,
            
            0, 0, 0,  0, 4, 0,  0, 0, 0,
            1, 0, 5,  7, 0, 0,  8, 2, 4,
            7, 0, 0,  0, 0, 0,  9, 0, 0,
            
            0, 0, 0,  0, 1, 3,  0, 5, 0,
            0, 0, 3,  0, 6, 0,  4, 0, 8,
            0, 9, 8,  0, 2, 0,  0, 3, 0,
        };

        var board = new Board(numbers);
        
        var boardValidator = new BoardValidator(board);
        Assert.True(boardValidator.IsBoardLegal());
        Assert.False(boardValidator.IsBoardCorrect());

        var solver = new Solver(board);
        var s = new Stopwatch();
        s.Start();
        var solvedBoard = solver.Solve();
        s.Stop();
        Assert.True(new BoardValidator(solvedBoard).IsBoardCorrect());
        _testOutputHelper.WriteLine($"Took {s.ElapsedMilliseconds/1000}s to solve");
        Assert.True(s.ElapsedMilliseconds < 1000 * 90);
    }
}