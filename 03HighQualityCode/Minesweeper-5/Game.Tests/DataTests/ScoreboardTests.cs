namespace Game.Tests.DataTests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;
    using Minesweeper.Data;
    using Minesweeper.Interfaces;

    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        public void TestScoreboardSaveAndLoad()
        {
            bool testWork;
            List<IPlayer> playersLoad = Scoreboard.Load();
            if (playersLoad == null || playersLoad.Count == 0)
            {
                playersLoad.Add(new Player("Nikolay", 10));
                Scoreboard.Save(playersLoad);
                List<IPlayer> playersExpected = Scoreboard.Load();
                List<IPlayer> playersNull = new List<IPlayer>();
                Scoreboard.Save(playersNull);
                testWork = this.CompareResult(playersLoad, playersExpected);

                Assert.IsTrue(testWork);
            }
            else
            {
                Scoreboard.Save(playersLoad);
                List<IPlayer> playersExpected = Scoreboard.Load();
                testWork = this.CompareResult(playersLoad, playersExpected);
                Assert.IsTrue(testWork);
            }
        }

        private bool CompareResult(List<IPlayer> playersLoad, List<IPlayer> playersExpected)
        {
            if (playersLoad.Count != playersExpected.Count)
            {
                return false;
            }

            for (int i = 0; i < playersLoad.Count; i++)
            {
                if (playersLoad[i].Name != playersExpected[i].Name || playersLoad[i].Score != playersExpected[i].Score)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
