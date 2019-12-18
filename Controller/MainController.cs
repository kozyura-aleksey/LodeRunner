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

        /// <summary>
        /// Контроллер меню
        /// </summary>
        private MenuController _menu;

        /// <summary>
        /// Контроллер игры
        /// </summary>
        private GameController _game = new GameController();

        /// <summary>
        /// Уровень игры
        /// </summary>
        public MapLevel _mapLevel;


        /// <summary>
        /// Создать главный контроллер
        /// </summary>
        public MainController()
        {
            Controller.CreateForm();
            View.View.SetFormParameters(Controller.FormMain);
            Controller.FormMain.Shown += StartApplication;


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
        /// Инициализация консольного варианта
        /// </summary>
        public void InitConsole()
        {
            View.View.InitConsole();
        }

        /// <summary>
        /// Открыть меню игры
        /// </summary>            
        private void StartApplication(object sender, System.EventArgs e)
        {
            //_menu.Init();     
            _game.Init();
        }
    }
}
