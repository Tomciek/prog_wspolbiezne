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
    }
}
