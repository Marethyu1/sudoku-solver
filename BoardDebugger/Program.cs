﻿using SodukoBoard;
using SSolver;

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

var solver = new Solver(board);
var solvedBoard = solver.Solve();
Console.WriteLine(new BoardValidator(solvedBoard).IsBoardCorrect());