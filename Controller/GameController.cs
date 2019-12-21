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
        public Model.ModelGame _gameModel;

        /// <summary>
        /// Представление игры 
        /// </summary>
        public View.Game.ViewGame _viewGame;

        /// <summary>
        /// 
        /// </summary>
        public Model.Game.MapLevel _mapLevel;

        /// <summary>
        /// Обработчик нажатия на кнопку
        /// </summary>
        private delegate void dKeyHandler();

        /// <summary>
        /// Словарь действий при нажатии кнопки
        /// </summary>
        private Dictionary<Keys, dKeyHandler> _keysDict;

        public GameController()
        {
            _gameModel = new Model.ModelGame();
            _viewGame = new View.Game.ViewGame(_gameModel);
            _gameModel.Move += DefineInteraction;

        }

        /// <summary>
        /// Определить обработку нажатия клавиш
        /// </summary>
        public void DefineInteraction()
        {
            _keysDict = new Dictionary<Keys, dKeyHandler>();
            //_keysDict.Add(Keys.Right, _gameModel._mapLevel.MoveRightRunner);
            _keysDict.Add(Keys.Up, _gameModel._mapLevel.MoveUpRunner);
            _keysDict.Add(Keys.Down, _gameModel._mapLevel.MoveDownRunner);
            _keysDict.Add(Keys.Left, _gameModel._mapLevel.MoveLeftRunner);
        }

        /// <summary> 
        /// 
        /// </summary>
        public override void DeInit()
        {
            FormMain.KeyDown -= KeyDown;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Init()
        {
            FormMain.KeyDown += KeyDown;
            _viewGame.DrawGame();
            _gameModel.Start();
        }

        /// <summary>
        /// Обработка события нажатия кнопки
        /// </summary>       
        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (_keysDict != null)
            {
                if (_keysDict.ContainsKey(e.KeyData))
                {
                    _keysDict[e.KeyData]();
                }
            }
        }
    }
}
