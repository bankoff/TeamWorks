namespace Minesweeper.Logic
{
    using Minesweeper.Enums;
    using Minesweeper.Interfaces;

    public class BoardScanner : IBoardScanner
    {
        private readonly IBoard board;

        public BoardScanner(IBoard board)
        {
            this.board = board;
        }

        public int ScanSurroundingFields(int row, int column)
        {
            var mines = 0;
            var previousRow = row - 1;
            var nextRow = row + 1;
            var previousColumn = column - 1;
            var nextColumn = column + 1;

            for (var i = previousRow; i <= nextRow; i++)
            {
                for (var j = previousColumn; j <= nextColumn; j++)
                {
                    if (!(i == row && j == column) && this.IsMineInPosition(i, j))
                    {
                        mines++;
                    }
                }
            }

            return mines;
        }

        private bool IsMineInPosition(int row, int column)
        {
            return (0 <= row) && (row < this.board.Rows)
                   && (0 <= column) && (column < this.board.Columns)
                   && (this.board.FieldsMatrix[row, column].Status == FieldStatus.IsAMine);
        }
    }
}
