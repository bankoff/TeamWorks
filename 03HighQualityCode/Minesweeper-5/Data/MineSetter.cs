namespace Minesweeper
{
    using System;
    using Interfaces;

    using Minesweeper.Data;
    using Minesweeper.Enums;

    /// <summary>
    /// Sets all mines at random position
    /// </summary>
    public class MineSetter : IVisitor
    {
        private IRandomGenerator random;

        public MineSetter(IRandomGenerator random)
        {
            this.random = random;
        }

        public void Visit(Board board)
        {
            for (var i = 0; i < board.MinesCount; i++)
            {
                var row = this.random.GenerateRandomNumber(0, board.Rows);
                var column = this.random.GenerateRandomNumber(0, board.Columns);

                if (board[row, column].Status == FieldStatus.IsAMine)
                {
                    i--;
                }
                else
                {
                    board[row, column].Status = FieldStatus.IsAMine;
                }
            }
        }
    }
}
