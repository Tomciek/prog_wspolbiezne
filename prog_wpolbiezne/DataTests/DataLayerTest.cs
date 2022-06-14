using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace DataTest
{
    [TestClass]
    public class DataTest
    {
        private DataAbstractAPI TestingAPI = DataAbstractAPI.Create();

        [TestMethod]
        public void CircleCreationTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 1000, 1000);
            Assert.AreEqual(TestingAPI.GetCircles().Count, 10);
        }

        [TestMethod]
        public void GetWidthTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 500, 1000);
            Assert.AreEqual(TestingAPI.GetPoolWidth(), 500);
        }

        [TestMethod]
        public void GetHeightTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 500, 1000);
            Assert.AreEqual(TestingAPI.GetPoolHeight(), 1000);
        }

        [TestMethod]
        public void CirclePosTest()
        {
            AbstractCircle c = AbstractCircle.CreateCircle(new Vector2(10, 15));
            Assert.AreEqual(c.Position.X, 10);
            Assert.AreEqual(c.Position.Y, 15);
        }

    }
}
