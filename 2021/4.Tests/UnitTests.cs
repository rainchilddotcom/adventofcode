using System;
using System.Collections.Generic;
using Xunit;

namespace _4.Tests
{
    public class UnitTests
    {
        static readonly string winningNumbers = @"14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";


        [Fact]
        public void WinningBoardRowsAndColumns()
        {
            var winningBoard = new BingoBoard(winningNumbers);

            var rowsAndColumns = winningBoard.GetRowsAndColumns();

            Assert.Collection(rowsAndColumns[0],
                x => Assert.Equal(14, x.Number),
                x => Assert.Equal(21, x.Number),
                x => Assert.Equal(17, x.Number),
                x => Assert.Equal(24, x.Number),
                x => Assert.Equal(4, x.Number));

            Assert.Collection(rowsAndColumns[1],
                x => Assert.Equal(14, x.Number),
                x => Assert.Equal(10, x.Number),
                x => Assert.Equal(18, x.Number),
                x => Assert.Equal(22, x.Number),
                x => Assert.Equal(2, x.Number));

            Assert.Collection(rowsAndColumns[9],
                x => Assert.Equal(4, x.Number),
                x => Assert.Equal(19, x.Number),
                x => Assert.Equal(20, x.Number),
                x => Assert.Equal(5, x.Number),
                x => Assert.Equal(7, x.Number));
        }

        [Fact]
        public void WinningBoardWins()
        {
            var calledNumbers = new List<int>() { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24 };
            var winningBoard = new BingoBoard(winningNumbers);

            foreach (var number in calledNumbers)
            {
                var result = winningBoard.Call(number);
                if (number == 24)
                    Assert.True(result);
            }

            Assert.Equal(4512, winningBoard.Score);
        }

        [Fact]
        public void TestBingo()
        {
            var calledNumbers = new List<int>() { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

            var winningBoard = new BingoBoard(winningNumbers);

            var bingoBoards = new List<BingoBoard>()
            {
                new BingoBoard(
@"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19"),

                new BingoBoard(
@"3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6"),

                winningBoard
            };

            _4.Program.PlayBingo(bingoBoards, calledNumbers, out var winner, out var loser);

            Assert.Equal(winningBoard, winner);
            Assert.Equal(4512, winner.Score);

            Assert.Equal(1924, loser.Score);
        }

        static readonly string text = @"
7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7
";

        [Fact]
        public void TestInput()
        {
            var expectedNumbers = new List<int>() { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

            _4.Program.ParseInput(text, out var bingoBoards, out var calledNumbers);

            Assert.Equal(expectedNumbers, calledNumbers);
            Assert.Equal(3, bingoBoards.Count);
        }
    }
}
