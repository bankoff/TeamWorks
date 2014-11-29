using System;
using System.Threading;
namespace PushItGame
{
    partial class Game
    {
        public static int sleep = 100;

        //*****************************************
        //* Print moving of penguin *
        //*****************************************
        public static void PlayerUp()
        {
            string[,] position = 
            {
                { " ", "¯", "O", "_", " " },
                { " ", "_", "O", "¯", " " },
            };
            for (int row = penguinCoordRow * 3 + 1; row >= penguinCoordRow * 3 - 2; row--)
            {
                for (int j = 0; j < position.GetLength(1); j++)
                {
                    PrintStringOnPosition(penguinCoordCol * 5 + j, row, position[row % 2, j], ConsoleColor.Green);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep);

                for (int j = 0; j < position.GetLength(1); j++)
                {
                    PrintStringOnPosition(penguinCoordCol * 5 + j, row, position[row % 2, j], ConsoleColor.Black);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        public static void PlayerDown()
        {
            string[,] position = 
            {
                { " ", "¯", "O", "_", " " },
                { " ", "_", "O", "¯", " " },
            };
            for (int row = penguinCoordRow * 3 + 1; row <= penguinCoordRow * 3 + 4; row++)
            {
                for (int j = 0; j < position.GetLength(1); j++)
                {
                    PrintStringOnPosition(penguinCoordCol * 5 + j, row, position[row % 2, j], ConsoleColor.Green);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep);

                for (int j = 0; j < position.GetLength(1); j++)
                {
                    PrintStringOnPosition(penguinCoordCol * 5 + j, row, position[row % 2, j], ConsoleColor.Black);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        public static void PlayerLeft()
        {
            PrintStringOnPosition(penguinCoordCol * 5, penguinCoordRow * 3 + 1, "     ", ConsoleColor.Black);
            string[,] position = 
            {
            { "/", "O", "/"},
            { "\\", "O", "\\" },
            };
            for (int col = penguinCoordCol * 5 + 2; col >= penguinCoordCol * 5 - 3; col--)
            {
                for (int j = 0; j < position.GetLength(1); j++)
                {
                    PrintStringOnPosition(col, penguinCoordRow * 3 + j, position[col % 2, j], ConsoleColor.Green);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep);

                for (int j = 0; j < position.GetLength(1); j++)
                {
                    PrintStringOnPosition(col, penguinCoordRow * 3 + j, position[col % 2, j], ConsoleColor.Black);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        public static void PlayerRigth()
        {
            PrintStringOnPosition(penguinCoordCol * 5, penguinCoordRow * 3 + 1, "     ", ConsoleColor.Black);
            string[,] position = 
            {
            { "/", "O", "/"},
            { "\\", "O", "\\" },
            };
            for (int col = penguinCoordCol * 5 + 2; col <= penguinCoordCol * 5 + 6; col++)
            {
                for (int j = 0; j < position.GetLength(1); j++)
                {
                    PrintStringOnPosition(col, penguinCoordRow * 3 + j, position[col % 2, j], ConsoleColor.Green);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep);

                for (int j = 0; j < position.GetLength(1); j++)
                {
                    PrintStringOnPosition(col, penguinCoordRow * 3 + j, position[col % 2, j], ConsoleColor.Black);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        //*****************************************
        //* Print penguin pushing                 *
        //*****************************************
        public static void PlayerUpPush()
        {
            string[] position = 
            {
                "rrrrr",
                "rrrrr",
                "rrrrr",
                " ^O^ ",
                "  |  ",
                " / \\ "               
            };

            for (int i = 0; i < 3; i++)
            {
                position[i] = rock[i];
            }

            for (int j = 0; j < 3; j++)
            {

                for (int i = 0; i < 3; i++)
                {
                    PrintStringOnPosition(penguinCoordCol * 5, i + (penguinCoordRow - 1) * 3 - j, position[i], ConsoleColor.Blue);
                    PrintStringOnPosition(penguinCoordCol * 5, i + penguinCoordRow * 3 - j, position[i + 3], ConsoleColor.Green);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep * 2);

                if (j % 2 == 0) PrintStringOnPosition(penguinCoordCol * 5, penguinCoordRow * 3 + 2 - j, " /   ", ConsoleColor.Green);
                else PrintStringOnPosition(penguinCoordCol * 5, penguinCoordRow * 3 + 2 - j, "   \\ ", ConsoleColor.Green);

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep * 2);

                PrintStringOnPosition(penguinCoordCol * 5, penguinCoordRow * 3 + 2 - j, "     ", ConsoleColor.Black);

                if (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        public static void PlayerDownPush()
        {
            string[] position = 
            {
                " \\ / ",
                "  |  ",
                " ^O^ ",
                "rrrrr",
                "rrrrr",
                "rrrrr",
            };

            for (int i = 0; i < 3; i++)
            {
                position[i + 3] = rock[i];
            }

            for (int j = 0; j < 3; j++)
            {

                for (int i = 0; i < 3; i++)
                {
                    PrintStringOnPosition(penguinCoordCol * 5, i + (penguinCoordRow + 1) * 3 + j, position[i + 3], ConsoleColor.Blue);
                    PrintStringOnPosition(penguinCoordCol * 5, i + penguinCoordRow * 3 + j, position[i], ConsoleColor.Green);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep * 2);

                if (j % 2 == 0) PrintStringOnPosition(penguinCoordCol * 5, penguinCoordRow * 3 + j, "   / ", ConsoleColor.Green);
                else PrintStringOnPosition(penguinCoordCol * 5, penguinCoordRow * 3 + j, " \\   ", ConsoleColor.Green);

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep * 2);

                PrintStringOnPosition(penguinCoordCol * 5, penguinCoordRow * 3 + j, "     ", ConsoleColor.Black);

                if (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        public static void PlayerLeftPush()
        {
            string[] position = 
            {
                ">   /",
                " O—— ",
                ">   \\",
                "rrrrr",
                "rrrrr",
                "rrrrr",
            };

            for (int i = 0; i < 3; i++)
            {
                position[i + 3] = rock[i];
            }

            for (int j = 0; j < 5; j++)
            {

                for (int i = 0; i < 3; i++)
                {
                    PrintStringOnPosition((penguinCoordCol - 1) * 5 - j, i + penguinCoordRow * 3, position[i + 3], ConsoleColor.Blue);
                    PrintStringOnPosition(penguinCoordCol * 5 - j, i + penguinCoordRow * 3, position[i], ConsoleColor.Green);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep * 2);

                if (j % 2 == 0) PrintStringOnPosition(penguinCoordCol * 5 - j, penguinCoordRow * 3, ">    ", ConsoleColor.Green);
                else PrintStringOnPosition(penguinCoordCol * 5 - j, penguinCoordRow * 3 + 2, ">    ", ConsoleColor.Green);

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep * 2);

                PrintStringOnPosition(penguinCoordCol * 5 + 4 - j, penguinCoordRow * 3, " ", ConsoleColor.Black);
                PrintStringOnPosition(penguinCoordCol * 5 + 4 - j, penguinCoordRow * 3 + 2, " ", ConsoleColor.Black);

                if (Console.KeyAvailable) Console.ReadKey(true);
            }
        }

        public static void PlayerRigthPush()
        {
            string[] position = 
            {
                "\\   <",
                " ——O ",
                "/   <",
                "rrrrr",
                "rrrrr",
                "rrrrr",
            };

            for (int i = 0; i < 3; i++)
            {
                position[i + 3] = rock[i];
            }

            for (int j = 0; j < 5; j++)
            {

                for (int i = 0; i < 3; i++)
                {
                    PrintStringOnPosition((penguinCoordCol + 1) * 5 + j, i + penguinCoordRow * 3, position[i + 3], ConsoleColor.Blue);
                    PrintStringOnPosition(penguinCoordCol * 5 + j, i + penguinCoordRow * 3, position[i], ConsoleColor.Green);
                }

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep * 2);

                if (j % 2 == 0) PrintStringOnPosition(penguinCoordCol * 5 + j, penguinCoordRow * 3, "    <", ConsoleColor.Green);
                else PrintStringOnPosition(penguinCoordCol * 5 + j, penguinCoordRow * 3 + 2, "    <", ConsoleColor.Green);

                if (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(sleep * 2);

                PrintStringOnPosition(penguinCoordCol * 5 + j, penguinCoordRow * 3, " ", ConsoleColor.Black);
                PrintStringOnPosition(penguinCoordCol * 5 + j, penguinCoordRow * 3 + 2, " ", ConsoleColor.Black);

                if (Console.KeyAvailable) Console.ReadKey(true);
            }
        }
    }
}