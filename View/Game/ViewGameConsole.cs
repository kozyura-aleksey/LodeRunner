using CLIViews;
using Model.Game;
using Model.Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game
{
    /// <summary>
    /// Класс - отображение игры
    /// </summary>
    public class ViewGameConsole : View
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        private Model.ModelGame _modelGame;

        /// <summary>
        /// Быстрая буферизация
        /// </summary>
        private KernelGraphics _kernelGraphics = KernelGraphics.Instance;

        /// <summary>
        /// Представление уровня игры
        /// </summary>
        private MapLevel _mapLevel;

        /// <summary>
        /// Таймер для перерисовки
        /// </summary>
        private System.Timers.Timer timer = new System.Timers.Timer(600);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parModelGame"></param>
        public ViewGameConsole(Model.ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _modelGame.CreateMapLevel += CreateMap;
            _modelGame.Draw += DrawConsole;
            _mapLevel = new MapLevel();
            timer.Start();
            timer.Elapsed += ReDrawGame;            
        }

        /// <summary>
        /// Создание уровня
        /// </summary>
        public void CreateMap()
        {
            _mapLevel = new MapLevel();
        }

        /// <summary>
        /// Отрисовка в консоли
        /// </summary>
        public void DrawConsole()
        {
            //int x = 0;
            //int y = 0;
            //Console.BufferHeight = 410;
            //Console.BufferWidth = 540;
            //Console.SetWindowSize(70, 30);

            //StringBuilder a = new StringBuilder(32);

            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects.ToArray())
            {
                if (obj != null)
                {
                    if (obj.GetType() == typeof(Brick))
                    {
                        //System.Console.SetCursorPosition(obj.X, obj.Y);
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "#");
                    }

                    if (obj.GetType() == typeof(Concrete))
                    {
                        //System.Console.SetCursorPosition(obj.X, obj.Y);
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "#");
                        //a.Append("#");
                    }

                    if (obj.GetType() == typeof(Enemy))
                    {
                        //System.Console.SetCursorPosition(obj.X, obj.Y);
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "O");
                        //a.Append("O");
                    }

                    if (obj.GetType() == typeof(Gold))
                    {
                        //System.Console.SetCursorPosition(obj.X, obj.Y);
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "$");
                        //a.Append("$");
                    }

                    if (obj.GetType() == typeof(Rope))
                    {
                        //System.Console.SetCursorPosition(obj.X, obj.Y);
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "-");
                        //a.Append("-");
                    }

                    if (obj.GetType() == typeof(Stairs))
                    {
                        //System.Console.SetCursorPosition(obj.X, obj.Y);
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "|");
                        //a.Append("||");
                    }
                }

                foreach (Model.Game.Objects.GameObject obj1 in MapLevel.Objects.ToArray())
                {
                    if (obj1 != null)
                    {
                        if (obj1.GetType() == typeof(Man))
                        {
                            //x = obj1.X;
                            //y = obj1.Y;
                            _kernelGraphics.PrintString((short)obj1.X, (short)obj1.Y, "K");
                        }
                    }
                }
                //System.Console.SetCursorPosition(x, y);
                //Console.CursorVisible = false;
                //Console.Write(a);
            }
            _kernelGraphics.Flush();
        }

        /// <summary>
        /// Переририсовка игры
        /// </summary>
        public void ReDrawGame(object sender, EventArgs e)
        {
            System.Console.Clear();
            if (_modelGame._mapLevel != null)
            {
                DrawConsole();
            }
        }
    }
}
