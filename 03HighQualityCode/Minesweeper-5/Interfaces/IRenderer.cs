namespace Minesweeper.Interfaces
{
    using System.Collections.Generic;

    public interface IRenderer
    {
        void Write(string str);

        void PrintGameBoard(IBoard board);

        void PrintAllFields(IBoard board, IBoardScanner boardScanner);

        void PrintTopPlayers(List<IPlayer> players);

        void PrintMainMenu();
    }
}
