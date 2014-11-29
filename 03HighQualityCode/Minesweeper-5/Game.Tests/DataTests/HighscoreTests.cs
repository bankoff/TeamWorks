namespace Game.Tests.HighscoreTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;
    using Minesweeper.Data;

    [TestClass]
    public class HighscoreTests
    {
        private Highscore highscore;

        [TestInitialize]
        public void InitializeHighScore()
        {
            this.highscore = new Highscore();
            Player firstPlayer = new Player("Gosho", 3);
            Player secondPlayer = new Player("Ivan", 4);
            Player thirdPlayer = new Player("Tony", 5);
            Player fourthPlayer = new Player("Sasho", 6);
            Player fifthPlayer = new Player("Mery", 7);
            Player sixthPlayer = new Player("Petq", 8);

            this.highscore.AddTopPlayer(firstPlayer);
            this.highscore.AddTopPlayer(secondPlayer);
            this.highscore.AddTopPlayer(thirdPlayer);
            this.highscore.AddTopPlayer(fourthPlayer);
            this.highscore.AddTopPlayer(fifthPlayer);
            this.highscore.AddTopPlayer(sixthPlayer);
        }

        [TestMethod]
        public void HighscoreCount()
        {
            Assert.AreEqual(this.highscore.TopPlayers.Count, Highscore.MaxTopPlayersCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HighscoreAddNull()
        {
            this.highscore.AddTopPlayer(null);
        }

        [TestMethod]
        public void HighscoreIsHighScoreFalse()
        {
            Player notTopPlayer = new Player("Kalin", 1);
            Assert.IsFalse(this.highscore.IsHighScore(notTopPlayer.Score));
        }

        [TestMethod]
        public void HighscoreIsHighScoreTrue()
        {
            Player topPlayer = new Player("Kalina", 10);
            Assert.IsTrue(this.highscore.IsHighScore(topPlayer.Score));
        }

        [TestMethod]
        public void HighscoreSortingGetBestPlayer()
        {
            Player bestPlayer = new Player("Misho", 20);
            this.highscore.AddTopPlayer(bestPlayer);

            Assert.AreEqual(this.highscore.TopPlayers[0], bestPlayer);            
        }

        [TestMethod]
        public void HighscoreSorting()
        {
            var sortedHighScore = new Highscore();
            var fourth = new Player("Pesho", 5);
            var first = new Player("Gosho", 1);            
            var third = new Player("Misho", 4);            
            var second = new Player("Tisho", 3);
            sortedHighScore.AddTopPlayer(first);
            sortedHighScore.AddTopPlayer(second);
            sortedHighScore.AddTopPlayer(third);
            sortedHighScore.AddTopPlayer(fourth);

            var expected = new Player[] { fourth, third, second, first };
            var actual = sortedHighScore.TopPlayers.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
