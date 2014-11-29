namespace Minesweeper.Interfaces
{
    using Minesweeper.Data;

    public interface IBoard
    {
        int Rows { get; }

        int Columns { get; }

        int MinesCount { get; }

        Field[,] FieldsMatrix { get; }
    }
}
