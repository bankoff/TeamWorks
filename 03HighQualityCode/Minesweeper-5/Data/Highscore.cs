namespace Minesweeper.Data
{
    using System;
    using System.Collections.Generic;

    using Minesweeper.Interfaces;

    public class Highscore : IHighscore
    {
        private const int MAX_TOP_PLAYERS = 5;
        private const string DEFAULT_PLAYER_NAME = "no name";

        private List<IPlayer> topPlayers;

        public Highscore()
        {
            this.topPlayers = new List<IPlayer> { Capacity = MAX_TOP_PLAYERS };
        }

        public static int MaxTopPlayersCount
        {
            get
            {
                return MAX_TOP_PLAYERS;
            }
        }

        public List<IPlayer> TopPlayers
        {
            get
            {
                return new List<IPlayer>(this.topPlayers);
            }

            private set
            {
                this.topPlayers = value;
            }
        }

        public bool IsHighScore(int currentPlayerScore)
        {
            if (this.topPlayers.Capacity > this.topPlayers.Count)
            {
                return true;
            }

            foreach (var player in this.topPlayers)
            {
                if (player.Score < currentPlayerScore)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     If the current player is with top score, add it to Top list players and show the scoreboard.
        /// </summary>
        /// <param name="playerScore">
        ///     The score of the current player.
        /// </param>
        /// <param name="renderer">class that inherits IRenderer interface, used for drawing on current renderer</param>
        public void AddIfTopPlayer(int playerScore, IRenderer renderer)
        {
            if (!this.IsHighScore(playerScore))
            {
                return;
            }

            renderer.Write("Please enter your name for the top players' scoreboard: ");

            var playerName = Console.ReadLine();

            if (string.IsNullOrEmpty(playerName))
            {
                playerName = DEFAULT_PLAYER_NAME;
            }

            var player = new Player(playerName, playerScore);

            this.AddTopPlayer(player);
            renderer.PrintTopPlayers(this.TopPlayers);
        }

        public void AddTopPlayer(Player currentPlayer)
        {
            if (currentPlayer == null)
            {
                throw new ArgumentNullException("currentPlayer");
            }

            if (this.topPlayers.Capacity <= this.topPlayers.Count)
            {
                var lastTopPlayerIndex = this.topPlayers.Capacity - 1;
                this.topPlayers.RemoveAt(lastTopPlayerIndex);
            }

            this.topPlayers.Add(currentPlayer);
            this.topPlayers.Sort();
        }        
    }
}
