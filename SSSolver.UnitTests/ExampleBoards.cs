using SSolver;

namespace SSSolver.UnitTests;

public static class ExampleBoards
{
    private static readonly int[] CorrectBoardNums = {
        1, 2, 3, 4, 5, 6, 7, 8, 9,
        4, 5, 6, 7, 8, 9, 1, 2, 3,
        7, 8, 9, 1, 2, 3, 4, 5, 6,
        2, 3, 4, 5, 6, 7, 8, 9, 1,
        5, 6, 7, 8, 9, 1, 2, 3, 4,
        8, 9, 1, 2, 3, 4, 5, 6, 7,
        3, 4, 5, 6, 7, 8, 9, 1, 2, 
        6, 7, 8, 9, 1, 2, 3, 4, 5 ,
        9, 1, 2, 3, 4, 5, 6, 7, 8,
    };

    public static Board CorrectBoard()
    {
        return new Board(CorrectBoardNums);
    }
}