namespace Game.Tests.ReadWriteTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper.Data;
    using Minesweeper.ReadWrite;

    [TestClass]
    public class FileReadWriteTest
    {
        [TestMethod]
        [ExpectedException(typeof(FieldAccessException))]
        public void SerializeNotSerializablePlayer()
        {
            Player notSerializablePlayer = new Player("Koki", 4);

            FileReadWrite.Serialize(notSerializablePlayer, @"..\..\NotSerializablePlayer.bin");
        }

        [TestMethod]
        public void SerializeSerializablePlayer()
        {
            SerializablePlayer actualPlayer = new SerializablePlayer("Emil", 2);
            FileReadWrite.Serialize(actualPlayer, @"..\..\actualPlayer.bin");
            SerializablePlayer expectedPlayer = (SerializablePlayer)FileReadWrite.Deserialize(@"..\..\expectedPlayer.bin");

            Assert.AreEqual(expectedPlayer.Name, actualPlayer.Name);
            Assert.AreEqual(expectedPlayer.Score, actualPlayer.Score);
        }

        [TestMethod]
        [ExpectedException(typeof(FieldAccessException))]
        public void DeserializeNotSerializablePlayer()
        {
            FileReadWrite.Deserialize(@"..\..\NotSerializablePlayer.bin");
        }
    }
}
