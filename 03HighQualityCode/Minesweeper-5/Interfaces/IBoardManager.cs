namespace Minesweeper.Interfaces
{
    using Minesweeper.Enums;

    public interface IBoardManager
    {
        BoardStatus OpenField(int row, int column);

        int CountOpenedFields();
    }
}
