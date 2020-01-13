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
        /// Представление уровня игры
        /// </summary>
        private MapLevel _mapLevel;

        /// <summary>
        /// Таймер для перерисовки
        /// </summary>
        private System.Timers.Timer timer = new System.Timers.Timer(100);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parModelGame"></param>
        public ViewGameConsole(Model.ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _modelGame.CreateMapLevel += CreateMap;
            _modelGame.Draw += DrawConsole;
            _modelGame.Move += DrawConsole;
            _mapLevel = new MapLevel();       
        }

        /// <summary>
        /// Создание уровня
        /// </summary>
        public void CreateMap()
        {
            _mapLevel = new MapLevel();
        }
        
        /// <summary>
        /// Перерисовка в консоли
        /// </summary>
        public void ReDrawInConsole()
        {
            timer.Start();
            timer.Elapsed += ReDrawGame;
        }

        /// <summary>
        /// Отрисовка в консоли
        /// </summary>
        public void DrawConsole()
        {          
            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects.ToArray())
            {
                if (obj != null)
                {
                    if (obj.GetType() == typeof(Brick))
                    {
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "#", ConsoleColor.Red);
                    }

                    if (obj.GetType() == typeof(Concrete))
                    {
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "#", ConsoleColor.Red);
                    }

                    if (obj.GetType() == typeof(Enemy))
                    {
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "O");
                    }

                    if (obj.GetType() == typeof(Gold))
                    {
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "$", ConsoleColor.DarkYellow);
                    }

                    if (obj.GetType() == typeof(Rope))
                    {
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "-", ConsoleColor.Gray);
                    }

                    if (obj.GetType() == typeof(Stairs))
                    {
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "|", ConsoleColor.Gray);
                    }
                }        
            }
            foreach (Model.Game.Objects.GameObject obj in MapLevel.Objects.ToArray())
            {
                if (obj != null)
                {
                    if (obj.GetType() == typeof(Man))
                    {
                        _kernelGraphics.PrintString((short)obj.X, (short)obj.Y, "K");
                    }
                }
            }
            _kernelGraphics.Flush();
        }

        /// <summary>
        /// Переририсовка игры
        /// </summary>
        public void ReDrawGame(object sender, EventArgs e)
        {
            if (_modelGame.MapLevel != null)
            {
                DrawConsole();
            }
        }
    }
}
