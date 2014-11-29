namespace Minesweeper.Logic
{
    using System;
    using System.Collections.Generic;

    using Minesweeper.Enums;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Represent console renderer
    /// </summary>
    public class Renderer : IRenderer
    {
        private const string BOMB_SYMBOL = "*";
        private const string UNCOVERED_FIELD_SYMBOL = "?";
        private const string SPACE = " ";
        private const string NO_PLAYERS_MESSAGE = "There is still no TOP players!";
        private const string SCORE_BOARD_TITLE = "Scoreboard";

        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine(string.Format(Environment.NewLine +
                        "Welcome to the game “Minesweeper”!" + Environment.NewLine +
                        "Try to reveal all cells without mines." + Environment.NewLine +
                        "Please press:" + Environment.NewLine + Environment.NewLine +
                            "'" + ConsoleKey.T.ToString() + "' to view the scoreboard" + Environment.NewLine +
                            "'" + ConsoleKey.N.ToString() + "' to start a new game" + Environment.NewLine +
                            "'" + ConsoleKey.Q.ToString() + "' to quit the game!" +
                            Environment.NewLine + Environment.NewLine));
        }

        public void Write(string input)
        {
            Console.WriteLine(input);
        }

        public void PrintAllFields(IBoard board, IBoardScanner boardScanner)
        {
            var areAllFieldsOpened = true;

            this.PrintGameMatrix(board, areAllFieldsOpened);
        }

        public void PrintGameMatrix(IBoard board, bool areAllFieldsOpened)
        {
            Console.Clear();
            this.PrintColumnsNumber(board.Columns);
            this.PrintTopOrBottomBorder(board.Columns, '╔', '═', '╗');

            IBoardScanner boardScanner = new BoardScanner(board);

            for (var i = 0; i < board.Rows; i++)
            {
                Console.Write(i);
                Console.Write(SPACE + "║");

                for (var j = 0; j < board.Columns; j++)
                {
                    var currentField = board.FieldsMatrix[i, j];

                    if (currentField.Status == FieldStatus.Opened)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(SPACE + board.FieldsMatrix[i, j].Value);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (areAllFieldsOpened)
                    {
                        if (currentField.Status == FieldStatus.IsAMine)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(SPACE + BOMB_SYMBOL);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write(SPACE + boardScanner.ScanSurroundingFields(i, j));
                        }
                    }
                    else
                    {
                        Console.Write(SPACE + UNCOVERED_FIELD_SYMBOL);
                    }
                }

                Console.WriteLine(SPACE + "║");
            }

            this.PrintTopOrBottomBorder(board.Columns, '╚', '═', '╝');
        }

        public void PrintGameBoard(IBoard board)
        {
            var areAllFieldsOpened = false;

            this.PrintGameMatrix(board, areAllFieldsOpened);
        }

        public void PrintTopPlayers(List<IPlayer> players)
        {
            Console.Clear();

            if (players.Count > 0)
            {
                Console.WriteLine(SCORE_BOARD_TITLE);
                for (var i = 0; i < players.Count; i++)
                {
                    var playerRank = i + 1;
                    Console.WriteLine(playerRank + ". " + players[i]);
                }
            }
            else
            {
                Console.WriteLine(NO_PLAYERS_MESSAGE);
            }
        }

        private void PrintColumnsNumber(int columns)
        {
            Console.Write("    ");

            for (var i = 0; i < columns; i++)
            {
                Console.Write(i + SPACE);
            }

            Console.WriteLine();
        }

        private void PrintTopOrBottomBorder(int columns, char firstSymbol, char mediumSymbols, char lastSymbol)
        {
            var borderLength = 2 * (columns + 2);

            Console.WriteLine(("  " + firstSymbol).PadRight(borderLength, mediumSymbols) + lastSymbol);
        }
    }
}
