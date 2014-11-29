namespace Minesweeper.Interfaces
{
    public interface IBoardScanner
    {
        int ScanSurroundingFields(int row, int column);
    }
}
