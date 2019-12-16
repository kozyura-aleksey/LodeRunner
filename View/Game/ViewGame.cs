using Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Game
{
    /// <summary>
    /// Класс - отображение игры
    /// </summary>
    public class ViewGame : View
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        private Model.ModelGame _modelGame;

        /// <summary>
        /// Представление уровня игры
        /// </summary>
        public MapLevel _mapLevel;

        /// <summary>
        /// Представление объекта
        /// </summary>
        private Model.Game.Objects.GameObject _gameObject;

        /// <summary>
        /// Делагат на движение
        /// </summary>
        public delegate void moveObjects();

        /// <summary>
        /// Событие на движение
        /// </summary>
        public event moveObjects Move;


        public void onMove()
        {
            if (Move != null)
            {
                Move.Invoke();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parModelGame"></param>
        public ViewGame(Model.ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _mapLevel = new MapLevel();
            _mapLevel.draw += DrawGame;       
            _mapLevel = new MapLevel();
        }

        /// <summary>
        /// Прорисовка уровня
        /// </summary>
        /// <param name="parObjects"></param>
        public static void DrawGame()
        {
            Form parForm = View.ViewForm;
            List<Model.Game.Objects.GameObject> parObjects = MapLevel.LoadMapLevel();
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
        /// Прорисовка уровня
        /// </summary>
        /// <param name="parObjects"></param>
        public static void reDrawGame(float pardXPlus)
        {
            Form parForm = View.ViewForm;
            List<Model.Game.Objects.GameObject> parObjects = MapLevel.LoadMapLevel();
            Graphics graphics = parForm.CreateGraphics();
            Rectangle clientRectangle = parForm.ClientRectangle;
            BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(graphics, clientRectangle);
            bufferedGraphics.Graphics.Clear(Color.Black);

            foreach (Model.Game.Objects.GameObject objects in parObjects)
            {
                Image image = null;
                PictureBox pictureBox = new PictureBox();
                if (objects != null)
                {
                    if (objects.NameObject() == "Brick")
                    {
                        image = Properties.Resources.brick1;
                        //pictureBox.Image = image;
                        //pictureBox.Location = new Point(50, 0);
                        //parForm.Controls.Add(pictureBox);
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
                        bufferedGraphics.Graphics.DrawImage(image, pardXPlus, objects.Y);                      
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
        /// Перерисовка
        /// </summary>
        public static void reDrawRight()
        {            
            reDrawGame(MapLevel.moveRightRunner());
        }

        /// <summary>
        /// Перерисовка
        /// </summary>
        public static void reDrawLeft()
        {           
            //reDrawGame(MapLevel.moveLeftRunner());
        }                        
    }
}
