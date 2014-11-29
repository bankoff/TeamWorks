using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Farticle
{
    partial class LoadingScreen
    {
        struct Character
        {
            public int cooX;
            public int cooY;
        }

        static string[] appearanceOne;
        static string[] appearanceOneTwo;
        static string[] appearacneTwoOne;
        static string[] appearanceTwoTwo;
        static string[] appearanceWinner;
        static string[] appearanceLoser;

        static Character ninjaOne;
        static Character ninjaTwo;
        static Character winner;
        static Character loser;

        public static void MainLoading(int levelInPlay)
        {
            ninjaOne.cooX = 31;
            ninjaOne.cooY = 12;
            appearanceOne = new string[] {
                                      "  0   ", 
                                      " /|\\__",
                                      "//\\   ",
                                      "/  |  "
                                  };
            appearanceOneTwo = new string[]{
                                          "  0  /",
                                          " /|\\/ ",
                                          "/ /\\  ",
                                          " |  \\ ",
                                      };

            ninjaTwo.cooX = 37;
            ninjaTwo.cooY = 12;
            appearacneTwoOne = new string[]{
                                           "   0  ",
                                           "__/|\\ ",
                                           "   /\\\\",
                                           "  |  \\",
                                       };
            appearanceTwoTwo = new string[]{
                                          "\\  0  ",
                                          " \\/|\\ ",
                                          "  /\\ \\",
                                          " /  | ",
                                      };

            winner.cooX = 31;
            winner.cooY = 10;
            appearanceWinner = new string[]{
                                           "     /",
                                           "    /",
                                           "  0/ ",
                                           " /|  ",
                                           "// \\ ",
                                           "/  | ",
                                       };

            loser.cooX = 37;
            loser.cooY = 14;
            appearanceLoser = new string[]{
                                         "     0",
                                         "_/\\_/\\",
                                     };


            SetupConsole();

            //Thread subtext = new Thread(() =>PrintTextFromTxt(8, 20));
            //subtext.IsBackground = true;
            //subtext.Start();

            AnimationPriter();

            PrintTextFromTxt(8, 20, levelInPlay);

            System.Threading.Thread.Sleep(2000);
        }

        public static void SetupConsole()
        {
            Console.BufferWidth = Console.WindowWidth = 75;
            Console.BufferHeight = Console.WindowHeight = 26;
            Console.CursorVisible = false;
        }

        public static void AnimationPriter()
        {
            for (int i = 0; i < 2; i++)
            {
                PrintStringOnPosition(ninjaOne.cooX, ninjaOne.cooY, appearanceOne, ConsoleColor.DarkGray);
                PrintStringOnPosition(ninjaTwo.cooX, ninjaTwo.cooY, appearanceTwoTwo, ConsoleColor.White);
                System.Threading.Thread.Sleep(400);
                Console.Clear();
                PrintStringOnPosition(ninjaOne.cooX - 1, ninjaOne.cooY, appearanceOneTwo, ConsoleColor.DarkGray);
                PrintStringOnPosition(ninjaTwo.cooX - 1, ninjaTwo.cooY, appearacneTwoOne, ConsoleColor.White);
                System.Threading.Thread.Sleep(400);
            }

            Console.Clear();
            PrintStringOnPosition(winner.cooX, winner.cooY, appearanceWinner, ConsoleColor.DarkGray);
            PrintStringOnPosition(loser.cooX, loser.cooY, appearanceLoser, ConsoleColor.White);
        }

        public static void PrintTextFromTxt(int coordCol, int coordRow, int row)
        {
            StreamReader readFromTxt = new StreamReader(@"..\..\TextFile1.txt");
            using (readFromTxt)
            {
                string[] inTxtText = readFromTxt.ReadToEnd().Split('\n');
                for (int i = 0; i < inTxtText[row].Length; i++)
                {
                    Console.SetCursorPosition(coordCol, coordRow);
                    Console.WriteLine(inTxtText[row][i]);
                    System.Threading.Thread.Sleep(100);
                    coordCol++;
                    if (coordCol == Console.WindowWidth - 8)
                    {
                        coordRow++;
                        coordCol = 8;
                    }
                }
            }
        }

        public static void PrintStringOnPosition(int coordCol, int coordRow, string[] str, ConsoleColor color = ConsoleColor.Red)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Console.SetCursorPosition(coordCol, coordRow);
                Console.ForegroundColor = color;
                Console.WriteLine(str[i]);
                coordRow++;
            }
        }

        //public static void ClearCurrentLocation(int coordX, int coordY)
        //{
        //    Console.SetCursorPosition(coordX, coordY);
        //    for (int i = 0; i < 9; i++)
        //    {
        //        Console.Write("       ");
        //        coordY++;
        //    }
        //}
    }
}