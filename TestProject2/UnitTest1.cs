using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMultiplication2()
        {
            int y = mnozenie.Program.multiplication(2, 3);
            Assert.AreNotEqual(4, y);

        }
    }
}