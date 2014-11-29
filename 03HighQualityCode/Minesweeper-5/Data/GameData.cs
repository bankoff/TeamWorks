namespace Minesweeper.Data
{
    using System;

    using Minesweeper.Interfaces;

    /// <summary>
    /// Represent private data for game instance
    /// Structural patterns -> Private Class Data
    /// More info at: http://sourcemaking.com/design_patterns/private_class_data
    /// </summary>
    internal class GameData
    {
        public const ConsoleKey ExitGameKey = ConsoleKey.Q;
        public const ConsoleKey NewGameKey = ConsoleKey.N;

        public const ConsoleKey TopPlayersKey = ConsoleKey.T;

        public GameData(IRenderer renderer, IHighscore highscore)
        {
            this.Renderer = renderer;
            this.Highscore = highscore;
        }

        internal IHighscore Highscore { get; set; }

        internal IRenderer Renderer { get; set; }
    }
}
