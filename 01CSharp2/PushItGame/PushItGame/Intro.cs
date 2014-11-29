using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Farticle
{
    class Intro
    {
        static void PlayMusic()
        {
            Console.Beep(440, 500);
            Console.Beep(440, 500);
            Console.Beep(440, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);

            Console.Beep(440, 500);

            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 1000);

            Console.Beep(659, 500);
            Console.Beep(659, 500);
            Console.Beep(650, 500);
            Console.Beep(698, 350);
            Console.Beep(523, 150);

            Console.Beep(415, 500);
            Console.Beep(349, 350);
            Console.Beep(523, 150);
            Console.Beep(440, 1000);
        }

        public static void SetupConsole()
        {
            Console.BufferWidth = Console.WindowWidth = 75;
            Console.BufferHeight = Console.WindowHeight = 26;
            Console.CursorVisible = false;
        }

        public static void Printer()
        {
            string[] textArray ={
            "It is a period  of programming",
            "tortures,  rebel ninja  striking",
            "from  shadows  had  won  his first",
            "victory   against  the  Academy   of",
            "programming.    Pursued      by    the",
            "Academy's     trainers,    the     rebel",
            "ninja        struggles      to      indure",
            "severe       trials     on       his     way",
            "of      becoming          senior        ninja.",};

            //Outer loop keeps last line
            for (int i = 0; i < textArray.Length; i++)
            {
                int coordX = 37 - (textArray[i].Length / 2);
                int coordY = 20;
                //Inner loop print all lines to the current last
                for (int j = 0; j <= i; j++)
                {
                    coordX = 37 - (textArray[i - j].Length / 2);
                    coordY = 20 - 2 * j;
                    if (coordY > 13) Console.ForegroundColor = ConsoleColor.White;
                    else if (coordY > 7) Console.ForegroundColor = ConsoleColor.Gray;
                    else Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(coordX, coordY);
                    Console.Write(textArray[i - j]);
                }

               System.Threading.Thread.Sleep(1000);

                Console.SetCursorPosition(coordX, coordY);
                if (i < textArray.Length - 1)
                {
                    Console.Clear();
                }
                else
                {
                    //Add some more lines
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine();
                    }

                    //Print "Press [ENTER]..."
                    string pressEnter = "Press [ENTER] to start.";
                    coordX = 37 - pressEnter.Length / 2;
                    coordY = 23;
                    Console.SetCursorPosition(coordX, coordY);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(pressEnter);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                Console.WriteLine();
            }
        }

        internal static void MainIntro()
        {
            //Thread music = new Thread(new ThreadStart(PlayFinalMusic));
            //music.IsBackground = true;
            //music.Start();

            Thread music1 = new Thread(new ThreadStart(PlayMusic));
            music1.IsBackground = true;
            music1.Start();

            SetupConsole();
            Printer();
        }
    }
}