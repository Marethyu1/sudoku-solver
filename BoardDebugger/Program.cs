// See https://aka.ms/new-console-template for more information


using SSolver;
using SSSolver.UnitTests;


var board = ExampleBoards.CorrectBoard();
board[80] = 0;
var s = new Solver(board);
var b = s.Solve();
var boardValidator = new BoardValidator(b);
var isLegal = boardValidator.IsBoardLegal();
Console.WriteLine(isLegal);