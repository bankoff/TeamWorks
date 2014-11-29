namespace Minesweeper.Logic
{
    using System;

    using Minesweeper.Data;

    public class UserInput
    {
        private readonly Game instanceGame;

        public UserInput(Game instanceGame)
        {
            this.instanceGame = instanceGame;
        }

        public Game InstanceGame
        {
            get
            {
                return this.instanceGame;
            }
        }

        public bool Handle()
        {
            var keyPressed = Console.ReadKey();

            var inGame = true;
            switch (keyPressed.Key)
            {
                // Start a new Game
                case GameData.NewGameKey:
                    {
                        this.instanceGame.Engine();
                        inGame = false;
                    }

                    break;

                // Exit the Game
                case GameData.ExitGameKey:
                    {
                        inGame = false;
                        this.instanceGame.GameData.Renderer.Write("Good bye!");
                        Environment.Exit(1);
                    }

                    break;

                // Show Top Scores
                case GameData.TopPlayersKey:
                    {
                        this.instanceGame.GameData.Renderer.PrintTopPlayers(Scoreboard.Load());
                        this.instanceGame.GameData.Renderer.Write("Press Enter: to return to the menu");
                        Console.ReadLine();
                    }

                    break;
            }

            return inGame;
        }
    }
}
