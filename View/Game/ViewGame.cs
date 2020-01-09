using Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

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
        private MapLevel _mapLevel;

        /// <summary>
        /// 
        /// </summary>
        private Form parForm;

        /// <summary>
        /// 
        /// </summary>
        private Graphics graphics;

        /// <summary>
        /// 
        /// </summary>
        private Rectangle clientRectangle;

        /// <summary>
        /// 
        /// </summary>
        private BufferedGraphics bufferedGraphics;

        /// <summary>
        /// Таймер для перерисовки
        /// </summary>
        private Timer timer = new Timer() { Enabled = true, Interval = 40 };       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parModelGame"></param>
        public ViewGame(Model.ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _modelGame.CreateMapLevel += CreateMap;
            _modelGame.Draw += DrawGame;
            timer.Start();
            timer.Tick += ReDrawGame;
            //_modelGame.Move += DrawGame;           
        }

        /// <summary>
        /// Создание уровня
        /// </summary>
        public void CreateMap()
        {
            _mapLevel = new MapLevel();
        }

        /// <summary>
        /// Отрисовка уровня
        /// </summary>
        /// <param name="parForm"></param>
        public void DrawGame()
        {
            parForm = View.viewform;
            graphics = parForm.CreateGraphics();
            clientRectangle = parForm.ClientRectangle;
            bufferedGraphics = BufferedGraphicsManager.Current.Allocate(graphics, clientRectangle);
            bufferedGraphics.Graphics.Clear(Color.Black);
            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects)
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

                    if (obj.NameObject() == "SubStairs")
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
            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects)
            {
                Image image = null;
                if (obj != null)
                {
                    if (obj.NameObject() == "Man")
                    {
                        Bitmap imageMan;
                        imageMan = Properties.Resources.runner0;
                        imageMan.MakeTransparent();
                        bufferedGraphics.Graphics.DrawImage(imageMan, obj.X, obj.Y);
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
        /// Перерисовка уровня
        /// </summary>
        /// <param name="parObjects"></param>
        public void ReDrawGame(object sender, EventArgs e)
        {
            if (_modelGame.MapLevel != null)
            {
                DrawGame();
            }
        }
    }
}
