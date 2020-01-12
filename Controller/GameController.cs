using Model.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Game;

namespace Controller.Game
{
    /// <summary>
    /// Класс - контроллер игры
    /// </summary>
    public class GameController : Controller
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        private Model.ModelGame _gameModel;

        /// <summary>
        /// Представление игры 
        /// </summary>
        private View.Game.ViewGameConsole _viewGame;

        /// <summary>
        /// Метод для завершения игры
        /// </summary>
        public static Model.ModelGame.dMoveObjects _endGameMethod;

        /// <summary>
        /// Обработчик нажатия на кнопку
        /// </summary>
        private delegate void dKeyHandler();

        /// <summary>
        /// Словарь действий при нажатии кнопки
        /// </summary>
        private Dictionary<ConsoleKey, dKeyHandler> _keysDict;


        /// <summary>
        /// Конструктор игрового контроллера
        /// </summary>
        public GameController()
        {
            _gameModel = new Model.ModelGame();
            _viewGame = new View.Game.ViewGameConsole(_gameModel);
            _gameModel.Move += DefineInteraction;
            _gameModel.EndGameEvent += _endGameMethod;
        }

        /// <summary>
        /// Определить обработку нажатия клавиш
        /// </summary>
        protected void DefineInteraction()
        {
            _keysDict = new Dictionary<ConsoleKey, dKeyHandler>();
            _keysDict.Add(ConsoleKey.LeftArrow, _gameModel.MapLevel.MoveLeftRunner);
            _keysDict.Add(ConsoleKey.RightArrow, _gameModel.MapLevel.MoveRightRunner);
            _keysDict.Add(ConsoleKey.DownArrow, _gameModel.MapLevel.MoveDownRunner);
            _keysDict.Add(ConsoleKey.UpArrow, _gameModel.MapLevel.MoveUpRunner);
        }

        /// <summary>
        /// Инициализировать контроллер
        /// </summary>
        public override void Init()
        {
            KeyDownerController.KeyDowner.KeyDown += KeyDown;          
            _viewGame.DrawConsole();
            _viewGame.ReDrawInConsole();
            _gameModel.Start();            
        }

        /// <summary> 
        /// Деинициализировать контроллер
        /// </summary>
        public override void DeInit()
        {
            KeyDownerController.KeyDowner.KeyDown -= KeyDown;
            _viewGame.Hide();
        }


        /// <summary>
        /// Обработка события нажатия кнопки
        /// </summary>       
        protected void KeyDown(ConsoleKey parKey)
        {
            lock (_gameModel)
            {
                if (_keysDict != null)
                {
                    if (_keysDict.ContainsKey(parKey))
                    {
                        _keysDict[parKey]();
                    }
                }
            }
        }

        /// <summary>
        /// Событие на нажатие кнопки мыши
        /// </summary>                
        private void GameItemChoice(ConsoleKey key)
        {
            if (key == ConsoleKey.RightWindows)
            {
                _gameModel.MapLevel.MoveRightRunner();
            }
            if (key == ConsoleKey.LeftArrow)
            {
                _gameModel.MapLevel.MoveLeftRunner();
            }
            if (key == ConsoleKey.UpArrow)
            {
                _gameModel.MapLevel.MoveUpRunner();
            }
            if (key == ConsoleKey.DownArrow)
            {
                _gameModel.MapLevel.MoveDownRunner();
            }
        }
    }
}
