using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class PoolViewModelTest
    {
        ViewFull poolViewModel = new ViewFull();

        [TestMethod]
        public void constructorTest()
        {
            Assert.AreEqual(640, poolViewModel.WindowHeight);
            Assert.AreEqual(1230, poolViewModel.WindowWidth);
        }
    }
}
