namespace Minesweeper.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }

        int Score { get; }

        string ToString();
    }
}
