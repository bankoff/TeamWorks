namespace Game.Tests
{
    using Game.Tests.DataTests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;
    using Minesweeper.Data;
    using Minesweeper.Enums;
    using Minesweeper.Logic;   

    [TestClass]
    public class BoardScannerTests
    {
        [TestMethod]
        public void ScanningForMinesTest()
        {
            var board = new Board(4, 4, 1);
            var boardScanner = new BoardScanner(board); 
            var bombSetter = new MineSetter(new RandomGeneratorForTesting(3));
            board.Accept(bombSetter);
            var fieldWithBomb = board.FieldsMatrix[3, 3];
            Assert.AreEqual(fieldWithBomb, new Field(0, FieldStatus.IsAMine));
            var adjacentField = board.FieldsMatrix[2, 3];
            int minesAround = boardScanner.ScanSurroundingFields(2, 3);
            Assert.AreEqual(1, minesAround);
        }

        [TestMethod]
        public void ScanningForMinesWhereNoMinesSetTest()
        {
            var board = new Board(4, 4, 1);
            var boardScanner = new BoardScanner(board);
            int expected = 0;
            int actual = boardScanner.ScanSurroundingFields(2, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScanningWhenTwoBombsAreAround()
        {
            var board = new Board(4, 4, 1);
            var boardScanner = new BoardScanner(board);
            var bombSetter = new MineSetter(new RandomGeneratorForTesting(3));
            var bombSetter2 = new MineSetter(new RandomGeneratorForTesting(2));
            board.Accept(bombSetter);
            board.Accept(bombSetter2);
            int expected = 2;
            int actual = boardScanner.ScanSurroundingFields(2, 3);
            Assert.AreEqual(expected, actual);
        }
    }
}