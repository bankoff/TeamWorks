using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using Farticle;
using EndScreen;

namespace PushItGame
{
    partial class Game
    {
        #region Variables

        public const int MAX_ROWS = 8;
        public const int MAX_COLS = 12;

        public enum SquareType
        {
            Free, Target, Wall, Ice
        }

        public enum SquareState
        {
            Nothing, Player, Rock, Busy
        }

        public struct Square
        {
            public SquareType type;
            public SquareState state;
        }

        public struct Level
        {
            public Square[,] board; //will be always 8x12
            // some additional data here?
            // maybe level time?
        }

        //IMPORTANT GLOBAL VARIABLES
        static public Level[] levels; //represents all levels; should be used only in methods: LoadLevels(), GetLevel()
        //static public int stepsCount;
        //static public int levelInPlay;
        static public int timeCount;
        static public int score;

        static public int penguinCoordRow;
        static public int penguinCoordCol;

        // TO BE CHANGED
        //Player should have at least 4 states
        static public string[] player = { "     ", 
                                          "•-O-•",
                                          "     "};

        static public string[] rock = { "rrrrr", 
                                        "rrrrr",
                                        "rrrrr"};

        static public string[] target = { "╔═══╗", 
                                          "║ ◙ ║",
                                          "╚═══╝"};

        static public string[] wall = { "░░░░░", 
                                        "░░░░░",
                                        "░░░░░"};

        static public string[] nothing = { "     ", 
                                           "     ",
                                           "     "}; 
        #endregion

        //Loads different rocks for each level.
        static public string[] LoadRock(int levelInPlay)
        {
            string[] levelRock= new string[3];
            switch (levelInPlay)
            {
                case 0:
                    {
                        levelRock[0] = "C#.C#";
                        levelRock[1] = "C#.C#";
                        levelRock[2] = "C#.C#";
                    break;
                    }
                case 1:
                    {
                        levelRock[0] = "OOP..";
                        levelRock[1] = ".OOP.";
                        levelRock[2] = "..OOP";
                        break;
                    }
                case 2:
                    {
                        levelRock[0] = "HTML.";
                        levelRock[1] = ".HTML";
                        levelRock[2] = "HTML.";
                        break;
                    }
                case 3:
                    {
                        levelRock[0] = "CSS..";
                        levelRock[1] = ".CSS.";
                        levelRock[2] = "..CSS";
                        break;
                    }
                case 4:
                    {
                        levelRock[0] = "Java.";
                        levelRock[1] = "Scr..";
                        levelRock[2] = "..ipt";
                        break;
                    }
                case 5:
                    {
                        levelRock[0] = "Nakov";
                        levelRock[1] = "Nakov";
                        levelRock[2] = "Nakov";
                        break;
                    }
            }            
            return levelRock;
        }

        //****************************************************************************
        //* load all levels form file and return how many levels are read            *
        //* no arguments                                                             * 
        //****************************************************************************
        static public int LoadLevels()
        {
            int levelsCount = 0;

            try
            {
                using (StreamReader sr = new StreamReader("../../Levels.txt"))
                {
                    string line;

                    //read the number of levels
                    line = sr.ReadLine();
                    levelsCount = int.Parse(line);
                    levels = new Level[levelsCount];

                    for (int i = 0; i < levelsCount; i++)
                    {
                        //read next 8 lines for the square types
                        levels[i].board = new Square[8, 12];

                        for (int row = 0; row < 8; row++)
                        {
                            line = sr.ReadLine();
                            for (int col = 0; col < 12; col++)
                            {
                                levels[i].board[row, col].type = (SquareType)int.Parse(line.Substring(col, 1));
                            }
                        }

                        //read more 8 lines for the square states
                        for (int row = 0; row < 8; row++)
                        {
                            line = sr.ReadLine();
                            for (int col = 0; col < 12; col++)
                            {
                                levels[i].board[row, col].state = (SquareState)int.Parse(line.Substring(col, 1));
                            }
                        }

                        //read a line for end of level '-----------'
                        line = sr.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Exception levelsNotFound = new Exception("Levels.txt can not be found in the current directory.");

                throw levelsNotFound;
            }
            catch (FormatException)
            {
                Exception levelsWrongFormat = new Exception("Levels.txt contains invalid levels descriptions.");

                throw levelsWrongFormat;
            }

            return levelsCount;
        }

        //**************************************************************************
        //* returns a copy of a level, so changes to this level are freely allowed *
        //* 1 argument:                                                            * 
        //* the number of the level                                                * 
        //************************************************************************** 
        static public Level GetLevel(int levelNumber)
        {
            Level copyLevel;

            //because the struct is value type, when assigning to new variable c# makes a copy
            copyLevel.board = new Square[8, 12];

            for (int i = 0; i < MAX_ROWS; i++)
            {
                for (int j = 0; j < MAX_COLS; j++)
                {
                    copyLevel.board[i, j].type = levels[levelNumber].board[i, j].type;
                    copyLevel.board[i, j].state = levels[levelNumber].board[i, j].state;
                }
            }

            return copyLevel;
        }

        //************************************************************
        //* Prints the object of a square on the screen              *
        //* Gets the object type and form where to start writing     *
        //* All coordinates are in the console coordinate system     *
        //* Returns nothing                                          * 
        //************************************************************
        static void PrintSquareType(SquareType type, int consoleRow, int consoleCol)
        {
            switch (type)
            {
                case SquareType.Free:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(consoleCol, consoleRow);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(nothing[i]);
                            consoleRow++;
                        }
                        break;
                    }
                case SquareType.Wall:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(consoleCol, consoleRow);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(wall[i]);
                            consoleRow++;
                        }
                        break;
                    }
                case SquareType.Target:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(consoleCol, consoleRow);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(target[i]);
                            consoleRow++;
                        }
                        break;
                    }

            }
        }

        //************************************************************
        //* Prints the state of a square on the screen               *
        //* Gets the square state and form where to start writing    *
        //* All coordinates are in the console coordinate system     *
        //* Returns nothing                                          * 
        //************************************************************
        static void PrintSquareState(SquareState state, int consoleRow, int consoleCol)
        {
            switch (state)
            {
                case SquareState.Busy:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(consoleCol, consoleRow);
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(wall[i]);
                            consoleRow++;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                        break;
                    }
                case SquareState.Player:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(consoleCol, consoleRow);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(player[i]);
                            consoleRow++;
                        }
                        break;
                    }
                case SquareState.Rock:
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(consoleCol, consoleRow);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(rock[i]);
                            consoleRow++;
                        }
                        break;
                    }
            }
        }

        //************************************
        //* Prints a level on the screen     *
        //* Gets the current board           *
        //* Returns nothing                  *
        //************************************
        static void PrintLevel(Square[,] arr)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j].state == SquareState.Nothing)
                    {
                        PrintSquareType(arr[i, j].type, i * 3, j * 5);
                    }
                    else
                    {
                        PrintSquareState(arr[i, j].state, i * 3, j * 5);
                    }
                }
            }
        }

        public static void PrintStringOnPosition(int coordCol, int coordRow, string str, ConsoleColor color = ConsoleColor.Red)
        {
            Console.SetCursorPosition(coordCol, coordRow);
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        //******************************************************
        //* Finds where on the board is located the player     *
        //* Gets the current board                             *
        //* Returns the coordinates in array                   *
        //******************************************************
        static int[] LoadPenguinCoord(Square[,] level)
        {
            int[] coord = new int[2];
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(1); j++)
                {
                    if (level[i, j].state == SquareState.Player)
                    {
                        coord[0] = i;
                        coord[1] = j;
                    }
                }
            }
            return coord;
        }

        static int[,] TargetPosition(Square[,] levels)
        {
            List<int> coordRow = new List<int>();
            List<int> coordCol = new List<int>();
            for (int i = 0; i < levels.GetLength(0); i++)
            {
                for (int j = 0; j < levels.GetLength(1); j++)
                {
                    if (levels[i, j].state == SquareState.Rock)
                    {
                        coordRow.Add(i);
                        coordCol.Add(j);
                    }
                }
            }
            int[,] matrix = new int[2, coordRow.Count];

            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                matrix[0, k] = coordCol[k];
                matrix[1, k] = coordRow[k];
            }
            return matrix;
        }

        //*****************************************************************
        //* Checks if the board is solved, i.e all targets have rocks     *
        //* Gets the current board                                        *
        //* Returns True if the board is solved and False otherwise       *
        //******************************************************************
        static bool CheckSolved(Square[,] levelToCheck)
        {
            bool solved = true;

            for (int i = 0; i < levelToCheck.GetLength(0); i++)
            {
                for (int j = 0; j < levelToCheck.GetLength(1); j++)
                {
                    if (levelToCheck[i, j].type == SquareType.Target)
                    {
                        if (levelToCheck[i, j].state != SquareState.Rock)
                        {
                            solved = false;
                            return solved;
                        }
                    }
                }
            }
            return solved;
        }

        //******************************************************************
        //* Moves the player if this is possible and updates the board     *
        //* in the memory and on the screen                                *
        //* Gets the current board and how the coordinates will be changed *
        //* Returns 1 if the player was really moved and 0 otherwise       *
        //******************************************************************
        // All object transitions can be made with animations
        static int MovePlayer(Square[,] level, int rowChange, int colChange)
        {
            #region If target square is free just move
            // If target square is free just move
            if (level[penguinCoordRow + rowChange, penguinCoordCol + colChange].state == SquareState.Nothing)
            {
                //animation
                if (rowChange == -1)
                {
                    PlayerUp();
                }
                if (rowChange == 1)
                {
                    PlayerDown();
                }
                if (colChange == -1)
                {
                    PlayerLeft();
                }
                if (colChange == 1)
                {
                    PlayerRigth();
                }

                // clear the old position
                level[penguinCoordRow, penguinCoordCol].state = SquareState.Nothing;
                PrintSquareType(level[penguinCoordRow, penguinCoordCol].type, penguinCoordRow * 3, penguinCoordCol * 5);

                // change coordinates
                penguinCoordRow += rowChange;
                penguinCoordCol += colChange;

                // set the new position
                level[penguinCoordRow, penguinCoordCol].state = SquareState.Player;
                PrintSquareState(level[penguinCoordRow, penguinCoordCol].state, penguinCoordRow * 3, penguinCoordCol * 5);

                // return 1 to increment the steps count
                return 1;
            } 
            #endregion

            #region If target square is rock we have to check if the next square is free
            //If target square is rock we have to check if the next square is free
            if (level[penguinCoordRow + rowChange, penguinCoordCol + colChange].state == SquareState.Rock)
            {
                if (level[penguinCoordRow + (2 * rowChange), penguinCoordCol + (2 * colChange)].state == SquareState.Nothing)
                {
                    // animation
                    if (rowChange == -1)
                    {
                        PlayerUpPush();
                    }

                    if (rowChange == 1)
                    {
                        PlayerDownPush();
                    }

                    if (colChange == -1)
                    {
                        PlayerLeftPush();
                    }

                    if (colChange == 1)
                    {
                        PlayerRigthPush();
                    }

                    // clear the old position
                    level[penguinCoordRow, penguinCoordCol].state = SquareState.Nothing;
                    PrintSquareType(level[penguinCoordRow, penguinCoordCol].type, penguinCoordRow * 3, penguinCoordCol * 5);

                    //change coordinates
                    penguinCoordRow += rowChange;
                    penguinCoordCol += colChange;

                    // we have penguinCoordRow once updated so add rowChange one more time
                    int newRockRow = penguinCoordRow + rowChange;
                    // we have penguinCoordCol once updated so add colChange one more time
                    int newRockCol = penguinCoordCol + colChange;

                    // set the new position
                    level[penguinCoordRow, penguinCoordCol].state = SquareState.Player;
                    PrintSquareState(level[penguinCoordRow, penguinCoordCol].state, penguinCoordRow * 3, penguinCoordCol * 5);

                    // update the board with the new rock position
                    level[newRockRow, newRockCol].state = SquareState.Rock;
                    PrintSquareState(level[newRockRow, newRockCol].state, newRockRow * 3, newRockCol * 5);

                    // return 1 to increment the steps count
                    return 1;
                }
            } 
            #endregion

            return 0;
        }

        //*****************************************
        //* Setup the parameters for the Console  *
        //* no argument, no return value          *
        //*****************************************
        public static void SetupConsole()
        {
            Console.BufferWidth = Console.WindowWidth = 75;
            Console.BufferHeight = Console.WindowHeight = 26;
            Console.CursorVisible = false;
        }

        private static void PlayLevel(int levelInPlay)
        {
            rock = LoadRock(levelInPlay);
            Level test = GetLevel(levelInPlay);
            PrintLevel(test.board);

            int[] penguinCoord = LoadPenguinCoord(test.board);
            penguinCoordRow = penguinCoord[0];
            penguinCoordCol = penguinCoord[1];
            int[,] finalRockPosition = TargetPosition(test.board);

            int stepsCount = 0;
            // Time
            PrintStringOnPosition(5, 25, "Time: " + timeCount, ConsoleColor.Red);
            // Steps
            PrintStringOnPosition(25, 25, "Steps: " + stepsCount, ConsoleColor.Blue);
            // Lives
            PrintStringOnPosition(45, 25, "Score: " + score, ConsoleColor.Green);
            //Reset level
            PrintStringOnPosition(63, 13, "[RESET]", ConsoleColor.Yellow);
            PrintStringOnPosition(62, 15, "Press \"R\"", ConsoleColor.Yellow);

            DateTime controlTime = DateTime.Now;

            //Penguin move if possible
            while (true)
            {
                if (Math.Abs(DateTime.Now.Second - controlTime.Second) > 0)
                {
                    controlTime = DateTime.Now;
                    timeCount++;
                    PrintStringOnPosition(5, 25, "Time: " + timeCount, ConsoleColor.Red);
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }

                    if (pressedKey.KeyChar == 'R')
                    {
                        Console.Clear();
                        rock = LoadRock(levelInPlay);
                        test = GetLevel(levelInPlay);
                        PrintLevel(test.board);

                        penguinCoord = LoadPenguinCoord(test.board);
                        penguinCoordRow = penguinCoord[0];
                        penguinCoordCol = penguinCoord[1];
                        finalRockPosition = TargetPosition(test.board);

                        stepsCount = 0;
                        // Time
                        PrintStringOnPosition(5, 25, "Time: " + timeCount, ConsoleColor.Red);
                        // Steps
                        PrintStringOnPosition(25, 25, "Steps: " + stepsCount, ConsoleColor.Blue);
                        // Lives
                        PrintStringOnPosition(45, 25, "Score: " + score, ConsoleColor.Green);
                        // some score?
                        //Reset level
                        PrintStringOnPosition(63, 13, "[RESET]", ConsoleColor.Yellow);
                        PrintStringOnPosition(62, 15, "Press \"R\"", ConsoleColor.Yellow);

                    }

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        //move left
                        stepsCount += MovePlayer(test.board, 0, -1);
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        //move right
                        stepsCount += MovePlayer(test.board, 0, 1);
                    }
                    else if (pressedKey.Key == ConsoleKey.UpArrow)
                    {
                        //move up
                        stepsCount += MovePlayer(test.board, -1, 0);
                    }
                    else if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        //move down
                        stepsCount += MovePlayer(test.board, 1, 0);
                    }

                    PrintStringOnPosition(25, 25, "Steps: " + stepsCount, ConsoleColor.Blue);
                    

                    if (CheckSolved(test.board) == true)
                    {
                        Console.Clear();
                        LoadingScreen.MainLoading(levelInPlay);
                        Thread.Sleep(300);
                        score += (int)(timeCount * 100 / stepsCount * (levelInPlay + 1));
                        levelInPlay++;
                        timeCount = 0;
                        break;
                    }
                }                
            }
            return;
        }

        static void Main()
        {
            Console.Clear();
            Intro.MainIntro();
            Console.OutputEncoding = Encoding.UTF8;
            SetupConsole();

            int totalLevels = 0;
            try
            {
                totalLevels = LoadLevels();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Unable to load the levels: {0} Exitting.", ex.Message);
                return;
            }

            for (int levelInPlay = 0; levelInPlay < totalLevels; levelInPlay++)
            {
                Console.Clear();
                PlayLevel(levelInPlay);
            }

            Ending.MainEnding();
            

        }
    }
}
