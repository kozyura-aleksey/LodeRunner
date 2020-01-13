using Controller.Game;
using Controller.Menu;
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

        private Model.ModelGame _gameModel = new Model.ModelGame();

        /// <summary>
        /// Контроллер меню
        /// </summary>
        private MenuController _menu;

        /// <summary>
        /// Контроллер игры
        /// </summary>
        private GameController _game;

        /// <summary>
        /// Создать главный контроллер
        /// </summary>
        public MainController()
        {
            Controller.CreateForm();
            View.View.SetFormParameters(Controller.FormMain);
            Controller.FormMain.Shown += StartApplication;      
            _menu = new MenuController();
            _menu.StartEvent += StartGame;
            GameController._endGameMethod = RecordsEnter;
            _game = new GameController();
            _recordName = new RecordController();
            _recordName.EndEvent += OpenMenu;
        }

        /// <summary>
        /// Открыть меню игры
        /// </summary>            
        private void StartApplication(object sender, System.EventArgs e)
        {
            _menu.Init();
        }

        /// <summary>
        /// Метод старта игры
        /// </summary>
        private void StartGame()
        {
            _menu.DeInit();
            _game.Init();
        }

        /// <summary>
        /// Инициализация контроллера
        /// </summary>
        public void Init()
        {
            View.View.Init();
        }

        /// <summary>
        /// Добавление нового рекорда
        /// </summary>
        private void RecordsEnter()
        {
            _game.DeInit();
            _recordName.Init();
        }

        /// <summary>
        /// Открыть главное меню
        /// </summary>
        private void OpenMenu()
        {
            _recordName.DeInit();
            _menu.Init();
        }
    }
}
