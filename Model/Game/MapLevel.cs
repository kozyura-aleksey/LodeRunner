using Model.Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model.Game
{
    /// <summary>
    /// Класс - уровень карты
    /// </summary>
    public class MapLevel
    {

        /// <summary>
        /// Экземпляр уровня
        /// </summary>
        private static MapLevel mapLevel = null;

        /// <summary>
        /// Позиция персонажа в карте
        /// </summary>
        private static int MAN_POS = 20;

        /// <summary>
        /// Шаг игры
        /// </summary>
        private static int STEP = 16;

        /// <summary>
        /// Массив линий
        /// </summary>
        public static string[] lines;

        /// <summary>
        /// Массив локаторов
        /// </summary>
        public static String[,] num;

        /// <summary>
        /// Лист объектов соответственно массиву локаторов
        /// </summary>
        public static List<Model.Game.Objects.GameObject> objects;

        /// <summary>
        /// Создать поле игры
        /// </summary>
        public MapLevel()
        {
            //String file = Properties.Resources.level1;
            lines = File.ReadAllLines(@"C:\LodeRunner\levels\level1.txt");
            num = new String[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    num[i, j] = Convert.ToString(temp[j]);
                }
            }

            objects = new List<Model.Game.Objects.GameObject>();

            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    objects.Add(GameObject.CreateObject(num[i, j], 16 * i, 16 * j));
                }
            }
        }
        
        /// <summary>
        /// Получить экземпляр уровня
        /// </summary>
        /// <returns></returns>
        public static MapLevel GetMapLevel()
        {
            if (mapLevel == null)
            {
                mapLevel = new MapLevel();
            }
            return mapLevel;
        }



        /// <summary>
        /// Движение персонажа вправо
        /// </summary>
        public void MoveRightRunner()
        {
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.NameObject() == "Man")
                    {
                        objects[MAN_POS].X += STEP;
                    }
                }
            }
        }

        /// <summary>
        /// Движение персонажа влево
        /// </summary>
        public void MoveLeftRunner()
        {
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.NameObject() == "Man")
                    {
                       objects[MAN_POS].X -= STEP;
                    }
                }
            }
        }

        /// <summary>
        /// Движение персонажа вверх
        /// </summary>
        public void MoveUpRunner()
        {
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.NameObject() == "Man")
                    { 
                       objects[MAN_POS].Y -= STEP;
                    }
                }
            }
        }

        /// <summary>
        /// Движение персонажа вниз
        /// </summary>
        public void MoveDownRunner()
        {
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.NameObject() == "Man")
                    {
                       objects[MAN_POS].Y += STEP;
                    }
                }               
            }
        }
    }
}
