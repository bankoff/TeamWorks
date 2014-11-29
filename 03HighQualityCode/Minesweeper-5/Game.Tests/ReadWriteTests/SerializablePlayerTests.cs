namespace Game.Tests.ReadWriteTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.ReadWrite;
    [TestClass]
    public class SerializablePlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerNullName()
        {
            SerializablePlayer player = new SerializablePlayer(null, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PlayerNegativeScore()
        {
            SerializablePlayer player = new SerializablePlayer("Gosho", -3);
        }

        [TestMethod]
        public void CheckGetName()
        {
            SerializablePlayer player = new SerializablePlayer("Gosho", 2);
            string expected = "Gosho";
            string actual = player.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckGetScore()
        {
            SerializablePlayer player = new SerializablePlayer("Gosho", 2);
            int expected = 2;
            int actual = player.Score;

            Assert.AreEqual(expected, actual);
        }
    }
}
