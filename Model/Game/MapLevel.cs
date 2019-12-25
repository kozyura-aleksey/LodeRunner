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
        /// 
        /// </summary>
        private static string[] lines;

        /// <summary>
        /// 
        /// </summary>
        public static String[,] num;

        /// <summary>
        /// Шаг игры
        /// </summary>
        public static int STEP = 1;

        /// <summary>
        /// Позиция игрока на карте
        /// </summary>
        public static int MAN_POS = 20;

        /// <summary>
        /// Лист объектов соответственно массиву локаторов
        /// </summary>
        public static List<Model.Game.Objects.GameObject> objects;
       

        /// <summary>
        /// Создать поле игры
        /// </summary>
        public MapLevel()
        {
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
                    objects.Add(GameObject.CreateObject(num[i, j],  i, j));
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
                        if ((objects[MAN_POS].X < ((num.GetLength(0) * STEP) - STEP) & CheckSutuationRightLeft()))
                        {
                            objects[MAN_POS].X += STEP;
                            System.Console.SetCursorPosition(parOb.X, parOb.Y);
                        }
                    }
                }
            }
            
            CollectLodes();
            Gravitation();
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
                        if ((objects[MAN_POS].X > 0) & CheckSutuationRightLeft())
                        {
                            objects[MAN_POS].X -= STEP;
                            System.Console.SetCursorPosition(parOb.X, parOb.Y);
                        }
                    }
                }
            }
            CollectLodes();
            Gravitation();
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
                        if ((objects[MAN_POS].Y > 0) & (CheckSutuationUp()))
                        {
                            objects[MAN_POS].Y -= STEP;
                        }
                    }
                }
            }
            CollectLodes();
            Gravitation();
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
                        if ((objects[MAN_POS].Y <= ((num.GetLength(1) * STEP) - STEP)) & (CheckSutuationDown()))
                        {
                            objects[MAN_POS].Y += STEP;
                        }
                    }
                }
            }
            CollectLodes();
            Gravitation();
        }

        /// <summary>
        /// Проверка ситуации вверх
        /// </summary>
        /// <returns></returns>
        public bool CheckSutuationUp()
        {
            bool loc = true;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.NameObject() == "Stairs")
                    {
                        if ((objects[MAN_POS].Y == parOb.Y) & (objects[MAN_POS].X == parOb.X))
                        {
                            loc = true;
                            break;
                        }
                        else
                        {
                            loc = false;
                        }
                    }
                }
            }
            return loc;
        }

        /// <summary>
        /// Проверка ситуации вниз
        /// </summary>
        /// <returns></returns>
        public bool CheckSutuationDown()
        {
            bool loc = true;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.NameObject() == "Stairs")
                    {
                        if (((objects[MAN_POS].Y == parOb.Y) || (objects[MAN_POS].Y == (parOb.Y - STEP))) & (objects[MAN_POS].X == parOb.X))
                        {
                            loc = true;
                            break;
                        }
                        else
                        {
                            loc = false;
                        }
                    }
                }
            }
            return loc;
        }


        /// <summary>
        /// Проверка ситуации вправо-влево
        /// </summary>
        /// <returns></returns>
        public bool CheckSutuationRightLeft()
        {
            bool loc = true;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.NameObject() == "Brick")
                    {
                        if (objects[MAN_POS].X <= parOb.X)
                        {
                            loc = true;
                            break;
                        }
                        else
                        {
                            loc = false;
                        }
                    }
                }
            }
            return loc;
        }

        /// <summary>
        /// Гравитация
        /// </summary>
        /// <returns></returns>
        public void Gravitation()
        {
            bool loc;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if ((parOb.NameObject() == "Brick") || (parOb.NameObject() == "Stairs"))
                    {
                        if (((objects[MAN_POS].Y + STEP) == parOb.Y) & (objects[MAN_POS].X == parOb.X))
                        {
                            loc = true;
                            break;
                        }
                        else
                        {
                            while ((objects[MAN_POS].Y < (parOb.Y)) & (objects[MAN_POS].X == parOb.X))
                            {
                                objects[MAN_POS].Y = (parOb.Y - STEP);
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Подсчет сундуков
        /// </summary>
        public int CountLodes()
        {
            int count = 0;
            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    if (num[i, j] == "6")
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// Количество сундуков
        /// </summary>
        int count = 0;

        /// <summary>
        /// Собирание сундуков
        /// </summary>
        public void CollectLodes()
        {
            foreach (Model.Game.Objects.GameObject parOb in objects.ToArray())
            {
                if ((parOb != null) & (objects != null))
                {
                    if (parOb.NameObject() == "Gold")
                    {
                        if ((objects[MAN_POS].X == parOb.X) & (objects[MAN_POS].Y == parOb.Y))
                        {
                            count += 1;
                            var index = objects.IndexOf(parOb);
                            objects[index] = null;
                            if (count == CountLodes())
                            {
                                objects[573] = new Stairs(368, 80);
                                objects[574] = new Stairs(368, 64);
                                objects[575] = new Stairs(368, 48);
                                objects[576] = new Stairs(368, 32);
                                objects[577] = new Stairs(368, 16);
                                objects[578] = new Stairs(368, 0);
                                break;
                            }
                        }
                    }
                }
            }
        }


    }
}
