namespace Minesweeper.Interfaces
{
    using System.Collections.Generic;

    using Minesweeper.Data;

    public interface IHighscore
    {
        List<IPlayer> TopPlayers { get; }

        bool IsHighScore(int currentPlayerScore);

        void AddTopPlayer(Player currentPlayer);

        void AddIfTopPlayer(int playerScore, IRenderer renderer);
    }
}
