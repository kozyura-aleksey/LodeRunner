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
        /// Массив линий
        /// </summary>
        private static string[] lines;

        /// <summary>
        /// Массив локаторов
        /// </summary>
        private static String[,] num;

        /// <summary>
        /// Шаг игры
        /// </summary>
        private int _step;

        /// <summary>
        /// Выход по собиранию золота
        /// </summary>
        private static bool moveToFinalStairs = true;

        /// <summary>
        /// Свойство для собирания золота
        /// </summary>
        public static bool MoveToFinalStairs { get => moveToFinalStairs; set => moveToFinalStairs = value; }

        /// <summary>
        /// Шаг игры
        /// </summary>
        public int Step { get => _step; }

        /// <summary>
        /// Список объектов соответственно массиву локаторов
        /// </summary>
        private static List<Model.Game.Objects.GameObject> objects;

        /// <summary>
        /// Свойство для списка объектов
        /// </summary>
        public static List<GameObject> Objects { get => objects; set => objects = value; }

        /// <summary>
        /// Создать поле игры
        /// </summary>
        public MapLevel(int par_step)
        {
            _step = par_step;
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
                    objects.Add(GameObject.CreateObject(num[i, j],  i * Step, j * Step));
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
        public static MapLevel GetMapLevel(int parStep)
        {
            //if (mapLevel == null)
            //{
                mapLevel = new MapLevel(parStep);
            //}
            return mapLevel;
        }

        /// <summary>
        /// Движение персонажа вправо
        /// </summary>
        public void MoveRightRunner()
        {
            if ((objects[SearchNumberOfMan()].X < ((num.GetLength(0) * _step) - _step) && CheckSutuationRight()))
            {
                objects[SearchNumberOfMan()].X += _step;
            }
            CollectLodes();
            Gravitation();
        }

        /// <summary>
        /// Движение персонажа влево
        /// </summary>
        public void MoveLeftRunner()
        {
            if ((objects[SearchNumberOfMan()].X > 0) && CheckSutuationLeft())
            {
                objects[SearchNumberOfMan()].X -= _step;
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
                    objects[SearchNumberOfMan()].Y -= _step;
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
            if ((objects[SearchNumberOfMan()].Y <= ((num.GetLength(1) * _step) - _step)) && (CheckSutuationDown()))
            {
                objects[SearchNumberOfMan()].Y += _step;
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
                    if (parOb.GetType() == typeof(Stairs))
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
                        if (((objects[20].Y + _step == parOb.Y)) && (objects[20].X == parOb.X))
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
        /// Проверка ситуации вправо
        /// </summary>
        /// <returns></returns>
        public bool CheckSutuationRight()
        {
            bool loc = true;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.GetType() == typeof(Brick))
                    {
                        if (((objects[SearchNumberOfMan()].X + _step) == parOb.X) && (objects[SearchNumberOfMan()].Y == parOb.Y))
                        {
                            loc = false;
                            break;
                        }
                    }
                }
            }
            return loc;
        }

        /// <summary>
        /// Проверка ситуации влево
        /// </summary>
        /// <returns></returns>
        public bool CheckSutuationLeft()
        {
            bool loc = true;
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.GetType() == typeof(Brick))
                    {
                        if (((objects[SearchNumberOfMan()].X - _step) == parOb.X) && (objects[SearchNumberOfMan()].Y == parOb.Y))
                        {
                            loc = false;
                            break;
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
        /// 
        /// </summary>
        public void Landing()
        {
            objects[SearchNumberOfMan()].Y = YY - _step;
        }
        
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

                        if (((objects[SearchNumberOfMan()].Y + _step) == parOb.Y) && (objects[SearchNumberOfMan()].X == parOb.X))
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
            Landing();
        }

        /// <summary>
        /// Количество сундуков
        /// </summary>
        private static int count;

        /// <summary>
        /// свойство для количества сундуков
        /// </summary>
        public static int Count { get => count; set => count = value; }

        /// <summary>
        /// Подсчет сундуков
        /// </summary>
        public int CountLodes()
        {
            {
                foreach (Model.Game.Objects.GameObject parOb in objects)
                {
                    if (parOb != null)
                    {
                        if (parOb.GetType() == typeof(Gold))
                        {
                            count += 1;
                        }
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Номер сундука
        /// </summary>
        private static int index = 0;

        /// <summary>
        /// Свойство для собирания золота
        /// </summary>
        public static int Index { get => index; set => index = value; }

        /// <summary>
        /// Поле рекордов
        /// </summary>

        private static int record;

        /// <summary>
        /// Свойство для поля рекордов
        /// </summary>
        public static int Record { get => record; set => record = value; }
     

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
                            count = count + 1;
                            index = objects.IndexOf(parOb);
                        }
                    }
                }
            }
            objects[index] = null;
            if (count == 6)
            {
                moveToFinalStairs = false;
                //objects[573] = new Stairs(368, 80);
                //objects[574] = new Stairs(368, 64);
                //objects[575] = new Stairs(368, 48);
                //objects[576] = new Stairs(368, 32);
                //objects[577] = new Stairs(368, 16);
                //objects[578] = new Stairs(368, 0);
            }
            record = count;
        }

        /// <summary>
        /// Условие выхода из игры
        /// </summary>
        /// <returns></returns>
        public static bool isTrue()
        {
            return moveToFinalStairs;
        }
    }
}
