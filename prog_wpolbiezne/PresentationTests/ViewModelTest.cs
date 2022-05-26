using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class ViewModelTest
    {
        ViewFull ViewModel = new ViewFull();

        [TestMethod]
        public void constructorTest()
        {
            Assert.AreEqual(480, ViewModel.WindowHeight);
            Assert.AreEqual(800, ViewModel.WindowWidth);
        }

        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(ViewModel.Circles.Count, 0);
        }
        [TestMethod]
        public void HeightTest()
        {
            Assert.AreEqual(ViewModel.WindowHeight, 480);
        }
        [TestMethod]
        public void WidthTest()
        {
            Assert.AreEqual(ViewModel.WindowWidth, 800);
        }
    }
}
