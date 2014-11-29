namespace Game.Tests.DataTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void CreateGameInstance()
        {
            var game = Minesweeper.Game.Instance;
            Assert.IsInstanceOfType(game, Minesweeper.Game.Instance.GetType());
        }
    }
}
