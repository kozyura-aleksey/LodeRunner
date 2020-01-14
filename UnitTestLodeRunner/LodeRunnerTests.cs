using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Game;

namespace UnitTestLodeRunner
{
    [TestClass]
    public class LodeRunnerTests
    {
        MapLevel _mapLevel = new MapLevel();

        [TestMethod]
        public void SearchNumberOfMan()
        {
            var actual = MapLevel.Objects[20].GetType();

            var expected = MapLevel.Objects[_mapLevel.SearchNumberOfMan()].GetType(); 

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CountLodesOnMap()
        {
            var countLodesActual = 6;

            var countLodesExpected = _mapLevel.CountLodes();

            Assert.AreEqual(countLodesActual, countLodesExpected);
        }

        [TestMethod]
        public void CheckX()
        {
            int xAct = 0;

            int xExp = MapLevel.Objects[20].X;

            Assert.AreEqual(xAct, xExp);
        }

        [TestMethod]
        public void CheckY()
        {
            int yAct = 16;

            int yExp = MapLevel.Objects[1].Y;

            Assert.AreEqual(yAct, yExp);
        }

        [TestMethod]
        public void CheckStep()
        {
            int y1 = MapLevel.Objects[20].Y;
            int y2 = MapLevel.Objects[21].Y;

            int yH = y2 - y1;

            int step = MapLevel.step;

            Assert.AreEqual(yH, step);

        }

    }
}
