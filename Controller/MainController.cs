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
            while (!Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        _game._gameModel._mapLevel.MoveRightRunner();
                        break;
                    case ConsoleKey.LeftArrow:
                        _game._gameModel._mapLevel.MoveLeftRunner();
                        break;
                    case ConsoleKey.DownArrow:
                        _game._gameModel._mapLevel.MoveDownRunner();
                        break;
                    case ConsoleKey.UpArrow:
                        _game._gameModel._mapLevel.MoveUpRunner();
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
