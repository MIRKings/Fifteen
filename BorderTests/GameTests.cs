using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Border.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GameTest()
        {

        }

        [TestMethod()]
        public void StartTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.AreEqual(1,  game.GetDijitAt(0, 0));
            Assert.AreEqual(2,  game.GetDijitAt(1, 0));
            Assert.AreEqual(3,  game.GetDijitAt(2, 0));
            Assert.AreEqual(4,  game.GetDijitAt(3, 0));
            Assert.AreEqual(5,  game.GetDijitAt(0, 1));
            Assert.AreEqual(6,  game.GetDijitAt(1, 1));
            Assert.AreEqual(7,  game.GetDijitAt(2, 1));
            Assert.AreEqual(8,  game.GetDijitAt(3, 1));
            Assert.AreEqual(9,  game.GetDijitAt(0, 2));
            Assert.AreEqual(10, game.GetDijitAt(1, 2));
            Assert.AreEqual(11, game.GetDijitAt(2, 2));
            Assert.AreEqual(12, game.GetDijitAt(3, 2));
            Assert.AreEqual(13, game.GetDijitAt(0, 3));
            Assert.AreEqual(14, game.GetDijitAt(1, 3));
            Assert.AreEqual(15, game.GetDijitAt(2, 3));
            Assert.AreEqual(0,  game.GetDijitAt(3, 3));
        }
        
        [TestMethod()]
        public void PressAtTest()
        {

            Game game = new Game(4);
            game.Start();
            game.PressAt(2, 3);
            Assert.AreEqual(0, game.GetDijitAt(2, 3));
            Assert.AreEqual(15, game.GetDijitAt(3,3));
            game.PressAt(2, 2);
            Assert.AreEqual(0, game.GetDijitAt(2, 2));
            Assert.AreEqual(11, game.GetDijitAt(2, 3));

        }

        [TestMethod()]
        public void GetDijitAtTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.AreEqual(0, game.GetDijitAt(-5, -34));
            Assert.AreEqual(0, game.GetDijitAt(15, 6));

        }

        [TestMethod()]
        public void SolvedTest()
        {
            Game game = new Game(4);
            game.Start();
            Assert.IsTrue(game.Solved());
            game.PressAt(2, 3);
            Assert.IsFalse(game.Solved());
            game.PressAt(3, 3);
            Assert.IsTrue(game.Solved());
        }
    }
}