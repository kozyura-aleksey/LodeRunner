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
        /// Создать поле игры
        /// </summary>
        public MapLevel()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Aleksey\source\repos\LodeRunner\levels\level1.txt");
            String[,] num = new String[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    num[i, j] = Convert.ToString(temp[j]);
                }
            }

            List<Model.Game.Objects.GameObject> objects = new List<Model.Game.Objects.GameObject>();

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

        private static string[] lines = File.ReadAllLines(@"C:\Users\Aleksey\source\repos\LodeRunner\levels\level1.txt");
        private static String[,] num = new String[lines.Length, lines[0].Split(' ').Length];
        private static List<Model.Game.Objects.GameObject> objects = new List<Model.Game.Objects.GameObject>();

        /// <summary>
        /// Загрузка уровня 
        /// </summary>
        public static List<Model.Game.Objects.GameObject> LoadMapLevel()
        {      
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    num[i, j] = Convert.ToString(temp[j]);
                }
            }
            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    objects.Add(GameObject.CreateObject(num[i, j], 16 * i, 16 * j));
                }
            }
            return objects;
        }

        /// <summary>
        /// Отрисовка уровня
        /// </summary>
        /// <param name="parForm"></param>
        public void draw(Form parForm)
        {
            //Form parForm = View.Game.ViewForm;
            List<Model.Game.Objects.GameObject> parObjects = LoadMapLevel();
            Graphics graphics = parForm.CreateGraphics();
            Rectangle clientRectangle = parForm.ClientRectangle;
            BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(graphics, clientRectangle);
            bufferedGraphics.Graphics.Clear(Color.Black);

            foreach (Model.Game.Objects.GameObject objects in parObjects)
            {
                Image image = null;
                if (objects != null)
                {
                    if (objects.NameObject() == "Brick")
                    {
                        image = Properties.Resources.brick1;
                        bufferedGraphics.Graphics.DrawImage(image, objects.X, objects.Y);
                    }

                    if (objects.NameObject() == "Concrete")
                    {
                        image = Properties.Resources.brick2;
                        bufferedGraphics.Graphics.DrawImage(image, objects.X, objects.Y);
                    }

                    if (objects.NameObject() == "Enemy")
                    {
                        image = Properties.Resources.enemy0;
                        bufferedGraphics.Graphics.DrawImage(image, objects.X, objects.Y);
                    }

                    if (objects.NameObject() == "Gold")
                    {
                        image = Properties.Resources.lode;
                        bufferedGraphics.Graphics.DrawImage(image, objects.X, objects.Y);
                    }

                    if (objects.NameObject() == "Man")
                    {
                        image = Properties.Resources.runner0;
                        bufferedGraphics.Graphics.DrawImage(image, objects.X, objects.Y);
                    }

                    if (objects.NameObject() == "Rope")
                    {
                        image = Properties.Resources.rope;
                        bufferedGraphics.Graphics.DrawImage(image, objects.X, objects.Y);
                    }

                    if (objects.NameObject() == "Stairs")
                    {
                        image = Properties.Resources.stair;
                        bufferedGraphics.Graphics.DrawImage(image, objects.X, objects.Y);
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
        /// Движение вправо
        /// </summary>
        public void moveRightRunner()
        {
            List<Model.Game.Objects.GameObject> parObjects = LoadMapLevel();
            float dX = 0;
            foreach (Model.Game.Objects.GameObject aaa in parObjects)
            {
                if (aaa != null)
                {                   
                    if (aaa.NameObject() == "Man")
                    {                      
                        aaa.X += aaa.moveRightObject();
                        dX = aaa.X;
                    }                   
                }
            }
        }

        /// <summary>
        /// Движение влево
        /// </summary>
        public void moveLeftRunner()
        {
            List<Model.Game.Objects.GameObject> parObjects = LoadMapLevel();
            float dX = 0;
            foreach (Model.Game.Objects.GameObject aaa in parObjects)
            {
                if (aaa != null)
                {
                    if (aaa.NameObject() == "Man")
                    {
                        aaa.X -= aaa.moveRightObject();
                        dX = aaa.X;
                    }
                }
            }
        }
    }
}
