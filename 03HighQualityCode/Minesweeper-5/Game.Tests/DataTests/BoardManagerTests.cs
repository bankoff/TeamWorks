namespace Game.Tests
{
    using Game.Tests.DataTests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;
    using Minesweeper.Data;
    using Minesweeper.Enums;
    using Minesweeper.Logic;

    [TestClass]
    public class BoardManagerTests
    {
        [TestMethod]
        public void OpenFieldWithBombTest()
        {
            var board = new Board(4, 4, 1);
            var boardScanner = new BoardScanner(board);            
            var boardManager = new BoardManager(board, boardScanner);
            
            var bombSetter = new MineSetter(new RandomGeneratorForTesting(1));
            board.Accept(bombSetter);
            var openedField = boardManager.OpenField(1, 1);

            Assert.AreEqual(openedField, BoardStatus.SteppedOnAMine);
        }

        [TestMethod]
        public void OpenFieldSuccessfullyTest()
        {
            var board = new Board(4, 4, 1);
            var boardScanner = new BoardScanner(board);
            var boardManager = new BoardManager(board, boardScanner);

            var bombSetter = new MineSetter(new RandomGeneratorForTesting(2));
            board.Accept(bombSetter);
            var openedField = boardManager.OpenField(2, 1);

            Assert.AreEqual(openedField, BoardStatus.SuccessfullyOpened);
        }

        [TestMethod]
        public void OpenFieldWhichIsAlreadyOpened()
        {
            var board = new Board(4, 4, 1);
            var boardScanner = new BoardScanner(board);
            var boardManager = new BoardManager(board, boardScanner);

            var bombSetter = new MineSetter(new RandomGeneratorForTesting(2));
            board.Accept(bombSetter);
            var openedField = boardManager.OpenField(2, 1);
            var secondOpeningField = boardManager.OpenField(2, 1);

            Assert.AreEqual(secondOpeningField, BoardStatus.AlreadyOpened);
        }
    }
}