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
        /// Таймер для перерисовки
        /// </summary>
        public Timer timer = new Timer() { Enabled = true, Interval = 50 };


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parModelGame"></param>
        public ViewGame(Model.ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _modelGame.CreateMapLevel += CreateMap;
            _modelGame.Draw += DrawConsole;
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
        /// Отрисовка в консоли
        /// </summary>
        public void DrawConsole()
        {
            int x = 0;
            int y = 0;
            Console.BufferHeight = 410;
            Console.BufferWidth = 540;
            Console.SetWindowSize(70, 30);
            foreach (Model.Game.Objects.GameObject obj in MapLevel.objects)
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
                    
                    break;
                }
            }

        }

        /// <summary>
        /// Переририсовка игры
        /// </summary>
        public void ReDrawGame(object sender, EventArgs e)
        {
            if (_modelGame._mapLevel != null)
            {
                DrawConsole();
            }
        }        
    }
}
