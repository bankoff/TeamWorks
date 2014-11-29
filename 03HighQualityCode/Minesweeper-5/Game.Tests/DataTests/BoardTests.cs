namespace Game.Tests
{
    using System;
    using Game.Tests.DataTests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;
    using Minesweeper.Data;
    using Minesweeper.Enums;

    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBoardWithInvalidMinesShouldThrowException()
        {
            var board = new Board(10, 10, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBoardWithInvalidRowsShouldThrowException()
        {
            var board = new Board(-1, 5, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBoardWithInvalidColumnsShouldThrowException()
        {
            var board = new Board(5, -1, 10);
        }

        [TestMethod]
        public void TestRowsAndColsWhenCreateBoard()
        {
            var board = new Board(10, 9, 10);
            var rows = board.FieldsMatrix.GetLength(0);
            var cols = board.FieldsMatrix.GetLength(1);
            Assert.AreEqual(rows, 10);
            Assert.AreEqual(cols, 9);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexerOutOfRange()
        {
            var board = new Board(5, 5, 10);
            var field = board.FieldsMatrix[-1, 0];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexerOutOfRange2()
        {
            var board = new Board(5, 5, 10);
            var field = board.FieldsMatrix[0, -1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexerOutOfRange3()
        {
            var board = new Board(5, 5, 10);
            var field = board.FieldsMatrix[-2, -1];
        }

        [TestMethod]
        public void TestFieldMatrixInitialization()
        {
            var board = new Board(5, 5, 10);
            var fieldMatrix = board.FieldsMatrix;
            bool check = AreAllFieldsClosed(fieldMatrix);
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void TestMineSetter()
        {
            var board = new Board(5, 5, 10);
            var fieldMatrix = board.FieldsMatrix;
            var bombSetter = new MineSetter(new RandomGenerator());
            board.Accept(bombSetter);
            bool allFieldsAreClosed = AreAllFieldsClosed(fieldMatrix);
            Assert.IsFalse(allFieldsAreClosed);
        }

        [TestMethod]
        public void SettingBombOnSpecificRowAndColTest()
        {
            var board = new Board(4, 4, 1);
            var bombSetter = new MineSetter(new RandomGeneratorForTesting(1));
            board.Accept(bombSetter);
            var fieldMatrix = board.FieldsMatrix;
            var fieldWithBomb = board.FieldsMatrix[1, 1];
            Assert.AreEqual(fieldWithBomb, new Field(0, FieldStatus.IsAMine));
        }

        private static bool AreAllFieldsClosed(Field[,] fieldMatrix)
        {
            Field checker = new Field(0, FieldStatus.Closed);

            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    if (!fieldMatrix[row, col].Equals(checker))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}