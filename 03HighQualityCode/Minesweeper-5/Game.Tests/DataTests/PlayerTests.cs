namespace Game.Tests.PlayerTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;
    using Minesweeper.Data;
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerNullName()
        {
            Player player = new Player(null, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerNegativeScore()
        {
            Player player = new Player("Gosho", -3);
        }

        [TestMethod]
        public void PlayerCompare()
        {
            Player firstPlayer = new Player("Gosho", 2);
            Player secondPlayer = new Player("Gosho", 1);
            Assert.AreEqual(firstPlayer.CompareTo(secondPlayer), -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerCompareWithNonPlayer()
        {
            Player firstPlayer = new Player("Gosho", 2);
            object fake = "fake player";
            Assert.AreEqual(firstPlayer.CompareTo(fake), -1);
        }

        [TestMethod]
        public void CheckToStringMethod()
        {
            Player player = new Player("Gosho", 2);
            string expected = "Gosho --> 2";
            string actual = player.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckGetName()
        {
            Player player = new Player("Dimo", 4);
            string expected = "Dimo";
            string actual = player.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckGetScore()
        {
            Player player = new Player("Dimo", 4);
            int expected = 4;
            int actual = player.Score;

            Assert.AreEqual(expected, actual);
        }
    }
}
