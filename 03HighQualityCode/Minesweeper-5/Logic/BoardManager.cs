namespace Minesweeper.Logic
{
    using Minesweeper.Enums;
    using Minesweeper.Interfaces;

    public class BoardManager : IBoardManager
    {
        private readonly IBoard board;
        private readonly IBoardScanner boardScanner;

        public BoardManager(IBoard board, IBoardScanner scanner)
        {
            this.board = board;
            this.boardScanner = scanner;
        }

        public BoardStatus OpenField(int row, int column)
        {
            var fieldsMatrix = this.board.FieldsMatrix;
            var field = fieldsMatrix[row, column];
            BoardStatus status;

            switch (field.Status)
            {
                case FieldStatus.IsAMine:
                    status = BoardStatus.SteppedOnAMine;
                    break;
                case FieldStatus.Opened:
                    status = BoardStatus.AlreadyOpened;
                    break;
                default:
                    field.Value = this.boardScanner.ScanSurroundingFields(row, column);
                    field.Status = FieldStatus.Opened;
                    status = this.CheckIfWin() ? BoardStatus.AllFieldsAreOpened : BoardStatus.SuccessfullyOpened;
                    break;
            }

            return status;
        }

        public int CountOpenedFields()
        {
            var count = 0;
            for (var i = 0; i < this.board.FieldsMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < this.board.FieldsMatrix.GetLength(1); j++)
                {
                    if (this.board.FieldsMatrix[i, j].Status == FieldStatus.Opened)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool CheckIfWin()
        {
            var openedFields = this.CountOpenedFields();
            return (openedFields + this.board.MinesCount) == (this.board.Rows * this.board.Columns);
        }        
    }
}
