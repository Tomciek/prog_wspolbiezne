using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Logic;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestClass]
    public class LogicAbstractAPITest
    {
        LogicAbstractAPI logicApi = LogicAbstractAPI.Create(null);

        [TestMethod]
        public void CreateLayerTest()
        {
            Assert.AreEqual(logicApi.GetType(), LogicAbstractAPI.Create(_layer).GetType());
        }

        [TestMethod]
        public void CreateLayerNullTest()
        {
            Assert.AreEqual(logicApi.GetType(), LogicAbstractAPI.Create(null).GetType());
        }

        DataAbstractAPI _layer = DataAbstractAPI.Create();

        ObservableCollection<Circle> _newCircles = new();
        Circle circle1 = new(10, 2, 4);
        Circle circle2 = new(15, 6, 5);

        [TestMethod]
        public void CreateCirclesTest()
        {
            Assert.AreEqual(3, logicApi.CreateCircles(3, 100, 100).Count);
        }

        [TestMethod]
        public void UpdateCirclesTest()
        {
            _newCircles.Add(circle1);
            _newCircles.Add(circle2);
            Assert.AreEqual(2, logicApi.UpdatePositions(100, 100, _newCircles).Count);
        }
    }
}
