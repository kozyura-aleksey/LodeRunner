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
    public class MainControllerConsole
    {
        /// <summary>
        /// Контроллер рекордов
        /// </summary>
        private RecordControllerConsole _recordName;

        /// <summary>
        /// Контроллер меню
        /// </summary>
        private MenuController _menu;

        /// <summary>
        /// Контроллер игры
        /// </summary>
        private GameController _game;

        /// <summary>
        /// Контроллер нажатия кнопки
        /// </summary>
        private KeyDownerController _downerController;

        /// <summary>
        /// Создать главный контроллер
        /// </summary>
        public MainControllerConsole()
        {
            _downerController = new KeyDownerController(); 
            _menu = new MenuController();
            _menu.StartEvent += StartGame;
            GameController._endGameMethod += RecordsEnter;
            _game = new GameController();
            _recordName = new RecordControllerConsole();
            _recordName.EndEvent += OpenMenu;       
        }

        /// <summary>
        /// Старт игры
        /// </summary>
        private void StartGame()
        {
            _menu.DeInit();
            _game.Init();
        }

        /// <summary>
        /// Открыть главное меню
        /// </summary>
        private void OpenMenu()
        {
            _recordName.DeInit();
            _menu.Init();
        }

        /// <summary>
        /// Инициализация консольного варианта
        /// </summary>
        public void InitConsole()
        {
            _menu.Init();
        }

        /// <summary>
        /// Открыть меню игры
        /// </summary>            
        private void StartApplication()
        {    
            _game.Init();
        }

        /// <summary>
        /// Добавление нового рекорда
        /// </summary>
        private void RecordsEnter()
        {
            _game.DeInit();
            _recordName.Init();
        }
    }
}
