using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class CircleTest
    {
        Circle circle = new Circle(12, 2, 4);

        [TestMethod]
        public void checkingAssingValueTest()
        {
            Assert.AreEqual(12, circle.GetX());
            Assert.AreEqual(2, circle.GetY());
            Assert.AreEqual(4, circle.GetR());
        }
    }
}
