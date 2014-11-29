namespace Minesweeper
{
    using System;
    using Minesweeper.Data;
    using Minesweeper.Enums;
    using Minesweeper.Interfaces;
    using Minesweeper.Logic;

    public sealed class Game
    {
        public const int MAX_ROWS = 5;
        public const int MAX_COLUMNS = 10;
        public const int MAX_MINES = 15;

        internal readonly GameData GameData;
        private static Game theGame;
        private readonly UserInput userInputHandler;
        private Board board;
        private IBoardManager boardManager;
        private IBoardScanner boardScanner;

        /// <summary>
        ///     Prevents a default instance of the <see cref="Game" /> class from being created.
        /// </summary>
        private Game()
        {
            this.GameData = new GameData(new Renderer(), new Highscore());
            this.userInputHandler = new UserInput(this);
        }

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        public static Game Instance
        {
            // 'Lazy initialization'
            get
            {
                return theGame ?? (theGame = new Game());
            }
        }

        public void Run()
        {
            var inGame = true;

            while (inGame)
            {
                this.GameData.Renderer.PrintMainMenu();
                inGame = this.userInputHandler.Handle();
            }
        }

        /// <summary>
        ///     The Engine of the Game.
        /// </summary>
        internal void Engine()
        {
            this.board = new Board(MAX_ROWS, MAX_COLUMNS, MAX_MINES);
            this.boardScanner = new BoardScanner(this.board);
            this.boardManager = new BoardManager(this.board, this.boardScanner);
            this.board.Accept(new MineSetter(new RandomGenerator()));
            this.GameData.Renderer.PrintGameBoard(this.board);

            while (true)
            {
                this.GameData.Renderer.Write(
                    "\nChoose and press Enter:\n" + "'" + PlayerCommand.ReturnKey + "'"
                    + " to return to the menu or\nEnter row and column separated by a space: \n");

                // getting player input as object
                var command = new PlayerCommand(Console.ReadLine());

                if (command.IsBadInput)
                {
                    this.GameData.Renderer.Write(command.Message);
                }
                else
                {
                    if (command.IsReturnKey || this.IsGameOver(command.Row, command.Col))
                    {
                        this.Run();
                    }
                }
            }
        }

        /// <summary>
        /// Check the current status of the Game and print a result.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsGameOver(int chosenRow, int chosenColumn)
        {
            var gameOver = false;
            try
            {
                var boardStatus = this.boardManager.OpenField(chosenRow, chosenColumn);

                switch (boardStatus)
                {
                    case BoardStatus.SteppedOnAMine:
                        {
                            this.GameData.Renderer.PrintAllFields(this.board, this.boardScanner);

                            var playerScore = this.boardManager.CountOpenedFields();
                            this.GameData.Renderer.Write(
                                "Booooom! You were killed by a mine. You revealed " + playerScore
                                + " cells without mines.");

                            gameOver = this.GetPlayerName(playerScore);
                        }

                        break;

                    case BoardStatus.AlreadyOpened:
                        {
                            this.GameData.Renderer.Write("The field is already opened!");
                        }

                        break;

                    case BoardStatus.AllFieldsAreOpened:
                        {
                            this.GameData.Renderer.PrintAllFields(this.board, this.boardScanner);
                            this.GameData.Renderer.Write("Congratulations! You win!!!");

                            var playerScore = this.boardManager.CountOpenedFields();

                            gameOver = this.GetPlayerName(playerScore);
                        }

                        break;

                    default:
                        {
                            this.GameData.Renderer.PrintGameBoard(this.board);
                        }

                        break;
                }
            }
            catch
            {
                this.GameData.Renderer.Write("Wrong field's coordinates!");
            }

            return gameOver;
        }

        private bool GetPlayerName(int playerScore)
        {
            if (this.GameData.Highscore.TopPlayers.Count == 0)
            {
                foreach (var player in Scoreboard.Load())
                {
                    this.GameData.Highscore.AddTopPlayer((Player)player);
                }
            }

            this.GameData.Highscore.AddIfTopPlayer(playerScore, this.GameData.Renderer);
            Scoreboard.Save(this.GameData.Highscore.TopPlayers);
            this.GameData.Renderer.Write("Press Enter: to return to the menu");
            Console.ReadLine();
            return true;
        }
    }
}