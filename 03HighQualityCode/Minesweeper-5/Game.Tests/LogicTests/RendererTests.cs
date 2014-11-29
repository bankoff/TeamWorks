namespace Game.Tests.LogicTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Data;
    using Minesweeper.Interfaces;
    using Minesweeper.Logic;

    [TestClass]
    public class RendererTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            StreamWriter standardOut =
                new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
        }

        [TestMethod]
        public void TestWrite()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("Pesho" + Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Renderer ab = new Renderer();
                    ab.Write("Pesho");

                    string expected = string.Format("Pesho" + Environment.NewLine);
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void TestPrintTopPlayers()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("Scoreboard" + Environment.NewLine + "1. Ivaylo --> 10" + Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Renderer ab = new Renderer();
                    Player ivo = new Player("Ivaylo", 10);
                    List<IPlayer> players = new List<IPlayer>();
                    players.Add(ivo);
                    ab.PrintTopPlayers(players);

                    string expected = string.Format("Scoreboard" + Environment.NewLine + "1. Ivaylo --> 10" + Environment.NewLine);
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void TestPrintIfNotTopPlayers()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("There is still no TOP players!" + Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Renderer ab = new Renderer();
                    List<IPlayer> players = new List<IPlayer>();
                    ab.PrintTopPlayers(players);

                    string expected = string.Format("There is still no TOP players!" + Environment.NewLine);
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void TestPrintGameMatrix()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("    0 " + Environment.NewLine +
                                                                        "  ╔═══╗" + Environment.NewLine +
                                                                        "0 ║ 0 ║" + Environment.NewLine +
                                                                        "  ╚═══╝" + Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Renderer ab = new Renderer();
                    IBoard gameMatrix = new Board(1, 1, 0);

                    ab.PrintGameMatrix(gameMatrix, true);

                    string expected = string.Format("    0 " + Environment.NewLine +
                                                    "  ╔═══╗" + Environment.NewLine +
                                                    "0 ║ 0 ║" + Environment.NewLine +
                                                    "  ╚═══╝" + Environment.NewLine);

                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void TestPrintAllFields()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("    0 " + Environment.NewLine +
                                                                        "  ╔═══╗" + Environment.NewLine +
                                                                        "0 ║ 0 ║" + Environment.NewLine +
                                                                        "  ╚═══╝" + Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Renderer ab = new Renderer();
                    IBoard gameMatrix = new Board(1, 1, 0);
                    IBoardScanner scanner = new BoardScanner(gameMatrix);

                    ab.PrintAllFields(gameMatrix, scanner);

                    string expected = string.Format("    0 " + Environment.NewLine +
                                                    "  ╔═══╗" + Environment.NewLine +
                                                    "0 ║ 0 ║" + Environment.NewLine +
                                                    "  ╚═══╝" + Environment.NewLine);

                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void TestPrintGameBoard()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format("    0 " + Environment.NewLine +
                                                                        "  ╔═══╗" + Environment.NewLine +
                                                                        "0 ║ ? ║" + Environment.NewLine +
                                                                        "  ╚═══╝" + Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Renderer ab = new Renderer();
                    IBoard gameMatrix = new Board(1, 1, 0);

                    ab.PrintGameBoard(gameMatrix);

                    string expected = string.Format("    0 " + Environment.NewLine +
                                                    "  ╔═══╗" + Environment.NewLine +
                                                    "0 ║ ? ║" + Environment.NewLine +
                                                    "  ╚═══╝" + Environment.NewLine);

                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }

        [TestMethod]
        public void TestPrintMainMenu()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(string.Format(Environment.NewLine +
                        "Welcome to the game “Minesweeper”!" + Environment.NewLine +
                        "Try to reveal all cells without mines." + Environment.NewLine +
                        "Please press:" + Environment.NewLine + Environment.NewLine +
                            "'" + ConsoleKey.T.ToString() + "' to view the scoreboard" + Environment.NewLine +
                            "'" + ConsoleKey.N.ToString() + "' to start a new game" + Environment.NewLine +
                            "'" + ConsoleKey.Q.ToString() + "' to quit the game!" +
                            Environment.NewLine + Environment.NewLine + Environment.NewLine)))
                {
                    Console.SetIn(sr);

                    Renderer ab = new Renderer();

                    ab.PrintMainMenu();

                    string expected = string.Format(Environment.NewLine +
                        "Welcome to the game “Minesweeper”!" + Environment.NewLine +
                        "Try to reveal all cells without mines." + Environment.NewLine +
                        "Please press:" + Environment.NewLine + Environment.NewLine +
                            "'" + ConsoleKey.T.ToString() + "' to view the scoreboard" + Environment.NewLine +
                            "'" + ConsoleKey.N.ToString() + "' to start a new game" + Environment.NewLine +
                            "'" + ConsoleKey.Q.ToString() + "' to quit the game!" +
                            Environment.NewLine + Environment.NewLine + Environment.NewLine);

                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }
    }
}
