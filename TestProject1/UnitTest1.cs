using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMultiplication()
        {
            int y = Wspó³bie¿ne.Program.multiplication(2, 3);
            Assert.AreEqual(6, y);
        }
    }
}