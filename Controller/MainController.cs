using Controller.Game;
using Controller.Menu;
using Model;
using Model.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Класс - главный контроллер
    /// </summary>
    public class MainController
    {
        /// <summary>
        /// Контроллер рекордов
        /// </summary>
        private RecordController _recordName;

        /// <summary>
        /// 
        /// </summary>
        public ModelGame modelGame = new ModelGame();

        /// <summary>
        /// Контроллер меню
        /// </summary>
        private MenuController _menu;

        /// <summary>
        /// 
        /// </summary>
        private GameController _game = new GameController();

        /// <summary>
        /// 
        /// </summary>
        public MapLevel _mapLevel;


        /// <summary>
        /// Создать главный контроллер
        /// </summary>
        public MainController()
        {     
            StartApplication();
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void StartGame()
        {
            _menu.DeInit();
            _game.Init();
        }

        /// <summary>
        /// Инициализация консольного варианта
        /// </summary>
        public void InitConsole()
        {
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        _game._gameModel._mapLevel.MoveRightRunner();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.LeftArrow:
                        modelGame._mapLevel.MoveLeftRunner();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.DownArrow:
                        modelGame._mapLevel.MoveDownRunner();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.UpArrow:
                        modelGame._mapLevel.MoveUpRunner();
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Открыть меню игры
        /// </summary>            
        private void StartApplication()
        {
            //_menu.Init();     
            _game.Init();
        }
    }
}
