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


        private static string[] lines;
        public static String[,] num;

        /// <summary>
        /// Лист объектов соответственно массиву локаторов
        /// </summary>
        private static List<Model.Game.Objects.GameObject> objects;

        /// <summary>
        /// Лист объектов соответственно массиву локаторов для консоли
        /// </summary>
        public static String[,] consoleObjects;

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
                    objects.Add(GameObject.CreateObject(num[i, j], 2*i, 2*j));
                }
            }

            consoleObjects = new String[num.GetLength(0),num.GetLength(1)];

            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    consoleObjects[i, j] = GameObject.CreateConsoleObjects(num[i, j]);
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
        /// Отрисовка в консоли
        /// </summary>
        public static void DrawConsole()
        {
            int x = 0;
            int y = 0;
            Console.BufferHeight = 410;
            Console.BufferWidth = 540;
            Console.SetWindowSize(70, 30);
            foreach (Model.Game.Objects.GameObject obj in objects)
            {
                if (obj != null)
                {
                    if (obj.NameObject() == "Brick")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("#");
                    }

                    if (obj.NameObject() == "Concrete")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("#");
                    }

                    if (obj.NameObject() == "Enemy")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("O");
                    }

                    if (obj.NameObject() == "Gold")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("$");
                    }

                    if (obj.NameObject() == "Man")
                    {
                        x = obj.X;
                        y = obj.Y;
                        System.Console.SetCursorPosition(x, y);
                        Console.WriteLine("K");
                    }

                    if (obj.NameObject() == "Rope")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("-");
                    }

                    if (obj.NameObject() == "Stairs")
                    {
                        System.Console.SetCursorPosition(obj.X, obj.Y);
                        Console.WriteLine("||");
                    }
                }
                else
                {
                    System.Console.SetCursorPosition(0, 0);
                    Console.Write(" ");
                }
            }
            System.Console.SetCursorPosition(x, y);
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.RightArrow)
                {
                    MoveRightRunner();
                    break;
                }
            }

        }

        /// <summary>
        /// Отрисовка уровня
        /// </summary>
        /// <param name="parForm"></param>
        public void Draw(Form parForm)
        {
            Graphics graphics = parForm.CreateGraphics();
            Rectangle clientRectangle = parForm.ClientRectangle;
            BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(graphics, clientRectangle);
            bufferedGraphics.Graphics.Clear(Color.Black);
            foreach (Model.Game.Objects.GameObject obj in objects)
            {
                Image image = null;
                if (obj != null)
                {
                    if (obj.NameObject() == "Brick")
                    {
                        image = Properties.Resources.brick1;
                        bufferedGraphics.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.NameObject() == "Concrete")
                    {
                        image = Properties.Resources.brick2;
                        bufferedGraphics.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.NameObject() == "Enemy")
                    {
                        image = Properties.Resources.enemy0;
                        bufferedGraphics.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.NameObject() == "Gold")
                    {
                        image = Properties.Resources.lode;
                        bufferedGraphics.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.NameObject() == "Man")
                    {
                        image = Properties.Resources.runner0;
                        bufferedGraphics.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.NameObject() == "Rope")
                    {
                        image = Properties.Resources.rope;
                        bufferedGraphics.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.NameObject() == "Stairs")
                    {
                        image = Properties.Resources.stair;
                        bufferedGraphics.Graphics.DrawImage(image, obj.X, obj.Y);
                    }
                }
                else
                {
                    image = Properties.Resources._null;
                    bufferedGraphics.Graphics.DrawImage(image, 0, 0);
                }
            }
            bufferedGraphics.Render();
            graphics.Dispose();
            bufferedGraphics.Dispose();
        }


        /// <summary>
        /// Движение персонажа вправо
        /// </summary>
        public static void MoveRightRunner()
        {
            foreach (Model.Game.Objects.GameObject aaa in objects)
            {
                if (aaa != null)
                {
                    if (aaa.NameObject() == "Man")
                    {
                        //aaa.X += aaa.moveRightObject();
                        objects[20].X -= 2;
                    }
                }
            }
        }

        /// <summary>
        /// Движение персонажа влево
        /// </summary>
        public void MoveLeftRunner()
        {
            foreach (Model.Game.Objects.GameObject aaa in objects)
            {
                if (aaa != null)
                {
                    if (aaa.NameObject() == "Man")
                    {
                        //aaa.X -= aaa.moveLeftObject();
                        objects[20].X += aaa.moveLeftObject();
                    }
                }
            }
        }

        /// <summary>
        /// Движение персонажа вверх
        /// </summary>
        public void MoveUpRunner()
        {
            foreach (Model.Game.Objects.GameObject aaa in objects)
            {
                if (aaa != null)
                {
                    if (aaa.NameObject() == "Man")
                    {
                        //aaa.Y -= aaa.moveUpObject();
                        objects[20].X -= aaa.moveUpObject();
                    }
                }
            }
        }

        /// <summary>
        /// Движение персонажа вниз
        /// </summary>
        public void MoveDownRunner()
        {
            foreach (Model.Game.Objects.GameObject aaa in objects)
            {
                if (aaa != null)
                {
                    if (aaa.NameObject() == "Man")
                    {
                        //aaa.Y -= aaa.moveDownObject();
                        objects[20].X -= aaa.moveDownObject();
                    }
                }               
            }
        }
    }
}
