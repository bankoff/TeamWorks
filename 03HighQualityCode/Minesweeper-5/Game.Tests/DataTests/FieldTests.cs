namespace Game.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Data;
    using Minesweeper.Enums;

    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidValueShouldThrowException()
        {
            var field = new Field(0, FieldStatus.Opened);
            field.Value = -1;
        }

        [TestMethod]
        public void CheckEqualsWhenCompareWithNoField()
        {
            var field = new Field(0, FieldStatus.Opened);
            var other = "fake";

            bool areEqual = field.Equals(other);
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void CheckEqualsWhenCompareEqualField()
        {
            var field = new Field(0, FieldStatus.Opened);
            var other = new Field(0, FieldStatus.Opened);

            bool areEqual = field.Equals(other);
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void CheckEqualsWhenCompareNonEqualField()
        {
            var field = new Field(0, FieldStatus.Opened);
            var other = new Field(0, FieldStatus.Closed);

            bool areEqual = field.Equals(other);
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void CheckEqualsWhenCompareNonEqualField2()
        {
            var field = new Field(0, FieldStatus.Opened);
            var other = new Field(1, FieldStatus.Opened);

            bool areEqual = field.Equals(other);
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void CheckCloneFieldsMethod()
        {
            var field = new Field(0, FieldStatus.Opened);
            var other = field.Clone();

            bool areEqual = field.Equals(other);
            Assert.IsTrue(areEqual);
        }
    }
}