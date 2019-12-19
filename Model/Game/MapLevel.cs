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
        private static string[] lines;

        /// <summary>
        /// Массив локаторов
        /// </summary>
        private static String[,] num;

        /// <summary>
        /// Лист объектов соответственно массиву локаторов
        /// </summary>
        private static List<Model.Game.Objects.GameObject> objects;

        /// <summary>
        /// Создать поле игры
        /// </summary>
        public MapLevel()
        {
            lines = File.ReadAllLines(@"C:\LodeRunner\levels\level4.txt");
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

            for (int j = 0; j < num.GetLength(1); j++)
            {
                for (int i = 0; i < num.GetLength(0); i++)
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
        public void MoveRightRunner()
        {
            foreach (Model.Game.Objects.GameObject parOb in objects)
            {
                if (parOb != null)
                {
                    if (parOb.NameObject() == "Man")
                    {
                        if ((objects[MAN_POS].X <= 480) & (objects[MAN_POS].X >= 0))
                        {
                            objects[MAN_POS].X += STEP;
                        }
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
                        if ((objects[MAN_POS].X <= 480) & (objects[MAN_POS].X >= 0))
                        {
                            objects[MAN_POS].X -= STEP;
                        }
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
                        if ((objects[MAN_POS].Y <= 320) & (objects[MAN_POS].Y >= 0))
                        { 
                            objects[MAN_POS].Y -= STEP;
                        }
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
                        if ((objects[MAN_POS].Y <= 320) & (objects[MAN_POS].Y >= 0))
                        { 
                            objects[MAN_POS].Y += STEP;
                        }
                    }
                }               
            }
        }
    }
}
