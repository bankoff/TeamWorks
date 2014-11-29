namespace Game.Tests.DataTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Logic;
    [TestClass]
    public class PlayerCommandTests
    {
        [TestMethod]
        public void PlayerCommandInitialize()
        {
            PlayerCommand command = new PlayerCommand("1 2");
            Assert.IsFalse(command.IsBadInput);
            Assert.IsFalse(command.IsReturnKey);
            Assert.AreEqual(command.Row, 1);
            Assert.AreEqual(command.Col, 2);
        }

        [TestMethod]
        public void PlayerCommandNullInput()
        {
            PlayerCommand command = new PlayerCommand(null);
            Assert.IsTrue(command.IsReturnKey);
        }

        [TestMethod]
        public void PlayerCommandEmptyInput()
        {
            PlayerCommand command = new PlayerCommand(string.Empty);
            Assert.IsTrue(command.IsReturnKey);
        }

        [TestMethod]
        public void PlayerCommandBadInput()
        {
            PlayerCommand command = new PlayerCommand("a 5");
            Assert.IsTrue(command.IsBadInput);
        }
    }
}
