using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Game;

namespace UnitTestLodeRunner
{
    [TestClass]
    public class LodeRunnerTests
    {
        MapLevel _mapLevel = new MapLevel();

        /// <summary>
        /// Тест на номер персонажа
        /// </summary>
        [TestMethod]
        public void SearchNumberOfMan()
        {
            var actual = MapLevel.Objects[20].GetType();

            var expected = MapLevel.Objects[_mapLevel.SearchNumberOfMan()].GetType(); 

            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Тест на подсчет золота 
        /// </summary>
        [TestMethod]
        public void CountLodesOnMap()
        {
            var countLodesActual = 6;

            var countLodesExpected = _mapLevel.CountLodes();

            Assert.AreEqual(countLodesActual, countLodesExpected);
        }

        /// <summary>
        /// Тест на координату X
        /// </summary>
        [TestMethod]
        public void CheckX()
        {
            int xAct = 0;

            int xExp = MapLevel.Objects[20].X;

            Assert.AreEqual(xAct, xExp);
        }

        /// <summary>
        /// Тест на координату Y
        /// </summary>
        [TestMethod]
        public void CheckY()
        {
            int yAct = 16;

            int yExp = MapLevel.Objects[1].Y;

            Assert.AreEqual(yAct, yExp);
        }

        /// <summary>
        /// Тест на проверку шага игры
        /// </summary>
        [TestMethod]
        public void CheckStep()
        {
            int y1 = MapLevel.Objects[20].Y;
            int y2 = MapLevel.Objects[21].Y;

            int yH = y2 - y1;

            int step = MapLevel.step;

            Assert.AreEqual(yH, step);

        }

        /// <summary>
        /// Тест булевой переменной до выхода из игры
        /// </summary>
        [TestMethod]
        public void CheckMoveBeforeFinal()
        {
            var boolPer = MapLevel.MoveToFinalStairs;
            
            Assert.IsTrue(boolPer);
        }

        /// <summary>
        /// Тест булевой переменной после выхода из игры
        /// </summary>
        [TestMethod]
        public void CheckMoveAfterFinal()
        {
            _mapLevel.CollectLodes();
            MapLevel.Count = 0;
            MapLevel.isTrue();
            Assert.IsTrue(MapLevel.isTrue());
        }

        /// <summary>
        /// Тест на не null списка объектов
        /// </summary>
        [TestMethod]
        public void isNotNullObjects()
        {
            Assert.IsNotNull(MapLevel.Objects);
        }

        /// <summary>
        /// Тест на количество собранного золота до выхода из игры
        /// </summary>
        [TestMethod]
        public void countBeforeFinal()
        {
            int countActual = 0;
            int countExpected = MapLevel.Count;

            Assert.AreEqual(countActual, countExpected);
        }
    }
}