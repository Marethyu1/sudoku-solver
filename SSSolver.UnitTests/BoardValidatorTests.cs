using SSolver;
using Xunit.Abstractions;

namespace SSSolver.UnitTests;

public class BoardConstructionTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private static readonly int[] Nums = new[]
    {
        0, 1, 2, 3, 4, 6, 6, 7, 8,
        0, 1, 2, 3, 4, 5, 6, 7, 8,
        0, 1, 2, 3, 4, 5, 6, 7, 8,
        0, 1, 2, 3, 4, 5, 6, 7, 8,
        0, 1, 2, 3, 4, 5, 6, 7, 8,
        0, 1, 2, 3, 4, 5, 6, 7, 8,
        0, 1, 2, 3, 4, 5, 6, 7, 8,
        0, 1, 2, 3, 4, 5, 6, 7, 8,
        0, 1, 2, 3, 4, 5, 6, 7, 8,
    };

    public BoardConstructionTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CanConstruct()
    {
        var board = new Board(Nums);
        var boardValidator = new BoardValidator(board);
        Assert.NotNull(boardValidator);
    }
    
    [Fact]
    public void GivenWidthIsWrong_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new BoardValidator(new Board(new int[8])));
    }

    [Fact]
    public void DetectsIllegalRow()
    {
        var nums = new[]
        {
            1, 0, 1, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
        };
        var board = new Board(nums);
        var boardValidator = new BoardValidator(board);
        Assert.False(boardValidator.IsBoardLegal());
    }
    
    [Fact]
    public void DetectsIllegalColumn()
    {
        var nums = new[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 1,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 1,
        };
        var board = new Board(nums);
        var boardValidator = new BoardValidator(board);
        Assert.False(boardValidator.IsBoardLegal());
    }

    [Fact]
    public void DetectsIllegalBox()
    {
        var nums = new[]
        {
            1, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 1, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
        };
        var board = new Board(nums);
        var boardValidator = new BoardValidator(board);
        Assert.False(boardValidator.IsBoardLegal());
    }

    [Fact]
    public void DetectsLegalBoard()
    {
        var nums = new[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 1, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0,
        };
        var board = new Board(nums);
        var boardValidator = new BoardValidator(board);
        Assert.True(boardValidator.IsBoardLegal());
    }
    
    [Fact]
    public void DetectsCorrect()
    {
        var boardValidator = new BoardValidator(ExampleBoards.CorrectBoard());
        Assert.True(boardValidator.IsBoardCorrect());
    }
}