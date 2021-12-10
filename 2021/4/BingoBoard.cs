using System;
using System.Collections.Generic;
using System.Linq;

namespace _4
{
    public class BingoBoard
    {
        public BingoBoard()
        {
        }

        public BingoBoard(string board)
        {
            var input = board.Split(' ', '\r', '\n');

            int offsetX = 0;
            int offsetY = 0;

            foreach (var number in input)
            {
                if (number != "")
                {
                    numbers[offsetX, offsetY] = new BingoNumber(Convert.ToInt32(number));
                    offsetX++;
                    if (offsetX > 4)
                    {
                        offsetX = 0;
                        offsetY++;
                    }
                }
            }
        }

        private BingoNumber[,] numbers = new BingoNumber[5, 5];

        public int Score { get; private set; }

        public bool Call(int numberToCall)
        {
            if (Score != 0)
            {
                // already won, don't need to check off any more numbers
                return false;
            }

            foreach (var number in numbers)
            {
                number.Call(numberToCall);
            }

            var rowsAndColumns = GetRowsAndColumns();
            foreach (var line in rowsAndColumns)
            {
                if (line.TrueForAll(x => x.Called))
                {
                    CalculateScore(numberToCall);
                    return true;
                }
            }

            return false;
        }

        private void CalculateScore(int winningNumber)
        {
            int sumOfUnmarked = numbers
                .Cast<BingoNumber>()
                .Where(x => x.Called == false)
                .Sum(x => x.Number);

            Score = sumOfUnmarked * winningNumber;
        }

        public List<List<BingoNumber>> GetRowsAndColumns()
        {
            var rowsAndColumns = new List<List<BingoNumber>>();

            for (int y = 0; y < 5; y++)
            {
                var row = new List<BingoNumber>();
                var column = new List<BingoNumber>();
                for (int x = 0; x < 5; x++)
                {
                    row.Add(numbers[x, y]);
                    column.Add(numbers[y, x]);
                }
                rowsAndColumns.Add(row);
                rowsAndColumns.Add(column);
            }

            return rowsAndColumns;
        }
    }
}
