using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EndScreen
{
    class Ending
    {
        internal static void MainEnding()
        {
            Console.Clear();
            Thread music1 = new Thread(new ThreadStart(PlayFinalMusic));
            music1.IsBackground = true;
            music1.Start();

            SetupConsole();
            Printer();
        }

        static void PlayFinalMusic()
        {
            Console.Beep(440, 400);
            Console.Beep(440, 400);
            Console.Beep(494, 400);
            Console.Beep(523, 400);
            Console.Beep(523, 400);
            Console.Beep(494, 400);
            Console.Beep(440, 400);
            Console.Beep(392, 400);
            Console.Beep(349, 400);
            Console.Beep(349, 400);
            Console.Beep(392, 400);
            Console.Beep(440, 300);
            Console.Beep(440, 600);
            Console.Beep(392, 300);
            Console.Beep(392, 700);
        }

        public static void SetupConsole()
        {
            Console.BufferWidth = Console.WindowWidth = 75;
            Console.BufferHeight = Console.WindowHeight = 26;
            Console.CursorVisible = false;
        }

        public static void Printer()
        {
            string[] textArray = {
                                     "YOU HAVE WON! NOW GO LEARN SOME COMPUTER PROGRAMMING!",
                                     "YOU  HAVE  WON!  NOW  GO  LEARN  SOME  COMPUTER  PROGRAMMING!",
                                     "YOU   HAVE   WON!   NOW   GO  LEARN   SOME   COMPUTER   PROGRAMMING!"};
            int coordX;
            int coordY = 8;

            //Outer loop keeps last line
            for (int i = 0; i < 3; i++)
            {
                coordX = 37 - (textArray[i].Length / 2);

                if (coordY > 10) Console.ForegroundColor = ConsoleColor.White;
                else if (coordY > 9) Console.ForegroundColor = ConsoleColor.Gray;
                else Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(coordX, coordY);
                Console.Write(textArray[i]);
                coordY += 2;

                System.Threading.Thread.Sleep(1000);

                Console.SetCursorPosition(coordX, coordY);
                if (i < textArray.Length - 1)
                {
                    Console.Clear();
                }
                else
                {
                    //Print "Press [ENTER]..."
                    string pressEnter = "Press [ENTER] to exit.";
                    coordX = 37 - pressEnter.Length / 2;
                    coordY = 23;
                    Console.SetCursorPosition(coordX, coordY);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(pressEnter);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                Console.WriteLine();
            }
        }
    }
}
