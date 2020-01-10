using Model.Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
        /// Шаг игры
        /// </summary>
        private const int STEP = 16;

        /// <summary>
        /// Массив локаторов
        /// </summary>
        private static String[,] num;

        /// <summary>
        /// Массив линий
        /// </summary>
        private static string[] lines;

        /// <summary>
        /// Выход из игры
        /// </summary>
        private bool moveToFinalStairs = false;

        /// <summary>
        /// Свойство для переменной выхода из игры
        /// </summary>
        public bool MoveToFinalStairs { get => moveToFinalStairs; set => moveToFinalStairs = value; }

        /// <summary>
        /// Список объектов соответственно массиву локаторов
        /// </summary>
        private static List<GameObject> objects;

        /// <summary>
        /// Свойство для списка объектов
        /// </summary>
        public static List<GameObject> Objects { get => objects; set => objects = value; }

        /// <summary>
        /// Создать поле игры
        /// </summary>
        public MapLevel()
        {
            string str = Properties.Resources.file;
            lines = str.Split(new Char[] { '\n' });

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
                    objects.Add(GameObject.CreateObject(num[i, j], STEP * i, STEP * j));
                }
            }
        }

        /// <summary>
        /// Поиск номера персонажа
        /// </summary>
        /// <returns></returns>
        public int SearchNumberOfMan()
        {
            int number = 0;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.GetType() == typeof(Man))
                    {
                        number = objects.IndexOf(parOb);                      
                    }
                }
            }
            return number;
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
                    if (parOb.GetType() == typeof(Man))
                    {
                        if ((objects[SearchNumberOfMan()].X < ((num.GetLength(0) * STEP) - STEP) && CheckSutuationRightLeft()))
                        {
                            objects[SearchNumberOfMan()].X += STEP;
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
                    if (parOb.GetType() == typeof(Man))
                    {
                        if ((objects[SearchNumberOfMan()].X > 0) && CheckSutuationRightLeft())
                        {
                            objects[SearchNumberOfMan()].X -= STEP;
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
            if (objects[SearchNumberOfMan()].Y > 0)
            {
                if ((CheckSutuationUpSubStairs()) || (CheckSutuationUp()))
                {
                    objects[SearchNumberOfMan()].Y -= STEP;
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
                    if (parOb.GetType() == typeof(Man))
                    {
                        if ((objects[SearchNumberOfMan()].Y <= ((num.GetLength(1) * STEP) - STEP)) && (CheckSutuationDown()))
                        {
                            objects[SearchNumberOfMan()].Y += STEP;
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
                    if (parOb.GetType() == typeof(Stairs))
                    {
                        if ((objects[SearchNumberOfMan()].Y == parOb.Y) && (objects[SearchNumberOfMan()].X == parOb.X))
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
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckSutuationUpSubStairs()
        {
            bool loc = true;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.GetType() == typeof(SubStairs))
                    {
                        if ((objects[SearchNumberOfMan()].Y == 80) && (objects[SearchNumberOfMan()].X == 368))
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
                    if (parOb.GetType() == typeof(Stairs))
                    {
                        if (((objects[SearchNumberOfMan()].Y == parOb.Y) || (objects[SearchNumberOfMan()].Y == (parOb.Y - STEP))) && (objects[SearchNumberOfMan()].X == parOb.X))
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
                    if ((parOb.GetType() == typeof(Brick)) && (parOb.GetType() == typeof(Rope)))
                    {
                        if (objects[SearchNumberOfMan()].X <= parOb.X)
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
        /// Подсчет мин расстояния между строками
        /// </summary>
        public int CountMaxLodes()
        {
            int countLebgth = 0;
            List<int> spisok = new List<int>();
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.GetType() == typeof(Brick))
                    {
                        if (objects[SearchNumberOfMan()].X == parOb.X)
                        {                        
                            spisok.Add((objects[SearchNumberOfMan()].Y) - parOb.Y);
                            spisok.Sort();
                            countLebgth = spisok.Min();
                        }
                    }
                }
            }
            return countLebgth;
        }

        /// <summary>
        /// Y минимальной строки
        /// </summary>
        private int YY = 0;

        /// <summary>
        /// Гравитация
        /// </summary>
        /// <returns></returns>
        public void Gravitation()
        {
            int max = 0;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if ((parOb.GetType() == typeof(Brick)) || (parOb.GetType() == typeof(Stairs)))
                    {
                        if (objects[SearchNumberOfMan()].X == parOb.X)
                        {
                            if (max > ((objects[SearchNumberOfMan()].Y) - parOb.Y))
                            {
                                max = ((objects[SearchNumberOfMan()].Y) - parOb.Y);
                                YY = parOb.Y;
                                break;
                            }
                        }

                        if (((objects[SearchNumberOfMan()].Y + STEP) == parOb.Y) && (objects[SearchNumberOfMan()].X == parOb.X))
                        {
                            break;
                        }
                        
                    }

                    if (parOb.GetType() == typeof(Rope))
                    {
                        if (((objects[SearchNumberOfMan()].Y) == parOb.Y) && (objects[SearchNumberOfMan()].X == parOb.X))
                        {
                            break;
                        }
                        else
                        {
                            if ((objects[SearchNumberOfMan()].Y == parOb.Y) && (objects[SearchNumberOfMan()].X == parOb.X))
                            {
                                if (max > ((objects[SearchNumberOfMan()].Y) - parOb.Y))
                                {
                                    max = ((objects[SearchNumberOfMan()].Y) - parOb.Y);
                                    YY = parOb.Y;
                                }
                            }
                        }
                        
                    }
                }
            }
            objects[SearchNumberOfMan()].Y = YY - STEP;
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
                    if (num[i,j] == "6")
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
        private int count = 0;

        /// <summary>
        /// Номер сундука
        /// </summary>
        private int index = 0;

        /// <summary>
        /// Собирание сундуков
        /// </summary>
        public void CollectLodes()
        {
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if ((parOb != null) && (objects != null))
                {
                    if (parOb.GetType() == typeof(Gold))
                    {                                              
                        if ((objects[SearchNumberOfMan()].X == parOb.X) && (objects[SearchNumberOfMan()].Y == parOb.Y))
                        {
                            count += 1;
                            index = objects.IndexOf(parOb);                         
                        }                       
                    }               
                }
            }
            objects[index] = null;
            if (count == CountLodes()) 
            {
                moveToFinalStairs = true;
                //objects[573] = new SubStairs(368, 80);
                //objects[574] = new SubStairs(368, 64);
                //objects[575] = new SubStairs(368, 48);
                //objects[576] = new SubStairs(368, 32);
                //objects[577] = new SubStairs(368, 16);
                //objects[578] = new SubStairs(368, 0);
            }
        }
    }
}
