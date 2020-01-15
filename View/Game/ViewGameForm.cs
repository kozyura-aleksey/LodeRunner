using Model.Game;
using Model.Game.Objects;
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
    public class ViewGameForm : FormView
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
        /// Таймер для перерисовки
        /// </summary>
        private Timer timer = new Timer() { Enabled = true, Interval = 40 };

        /// <summary>
        /// Конструктор отображение игры
        /// </summary>
        /// <param name="parModelGame"></param>
        public ViewGameForm(Model.ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _modelGame.CreateMapLevel += CreateMap;
            _modelGame.Draw += DrawGame;
            _modelGame.Move += DrawGame;
            _mapLevel = new MapLevel();
        }

        /// <summary>
        /// Перерисовка по таймеру
        /// </summary>
        public void ReDrawWithTimer()
        {
            timer.Start();
            timer.Tick += ReDrawGame;
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
            BufferedGraphics _bufer = BufferedGraphicsManager.Current.Allocate(viewform.CreateGraphics(), viewform.ClientRectangle);
            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects.ToArray())
            {
                Image image = null;
                if (obj != null)
                {
                    if (obj.GetType() == typeof(Brick))
                    {
                        image = Properties.Resources.brick1;
                        _bufer.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.GetType() == typeof(Concrete))
                    {
                        image = Properties.Resources.brick2;
                        _bufer.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.GetType() == typeof(Enemy))
                    {
                        image = Properties.Resources.enemy0;
                        _bufer.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.GetType() == typeof(Gold))
                    {
                        image = Properties.Resources.lode;
                        _bufer.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.GetType() == typeof(Rope))
                    {
                        image = Properties.Resources.rope;
                        _bufer.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.GetType() == typeof(Stairs))
                    {
                        image = Properties.Resources.stair;
                        _bufer.Graphics.DrawImage(image, obj.X, obj.Y);
                    }

                    if (obj.GetType() == typeof(SubStairs))
                    {
                        image = Properties.Resources.stair;
                        _bufer.Graphics.DrawImage(image, obj.X, obj.Y);
                    }
                }
                else
                {
                    image = Properties.Resources._null;
                    _bufer.Graphics.DrawImage(image, 0, 0);
                }
            }
            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects.ToArray())
            {
                Image image = null;
                if (obj != null)
                {
                    if (obj.GetType() == typeof(Man))
                    {
                        Bitmap imageMan;
                        imageMan = Properties.Resources.runner0;
                        imageMan.MakeTransparent();
                        _bufer.Graphics.DrawImage(imageMan, obj.X, obj.Y);
                    }
                }
                else
                {
                    image = Properties.Resources._null;
                    _bufer.Graphics.DrawImage(image, 0, 0);
                }
            }
            _bufer.Render();          
            _bufer.Graphics.Dispose();
            _bufer.Dispose();
        }

        /// <summary>
        /// Нарисовать представление игры
        /// </summary>
        public void Draw()
        {
            DrawGame();
        }

        /// <summary>
        /// Очистить представление игры
        /// </summary>
        public void Clear()
        {
            _bufer.Graphics.Clear(viewform.BackColor);
            _bufer.Render();
        }

        /// <summary>
        /// Останавливаем перерисовку
        /// </summary>
        public void ReDrawStop()
        {
            timer.Stop();
            timer.Tick -= ReDrawGame;                  
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
