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
        public View.Game.ViewGameConsole _viewGame;

        /// <summary>
        /// 
        /// </summary>
        public Model.Game.MapLevel _mapLevel;

       
        public GameController()
        {
            _gameModel = new Model.ModelGame();
            _viewGame = new View.Game.ViewGameConsole(_gameModel);
            //_gameModel.Move += 

        }

        /// <summary>
        /// Определить обработку нажатия клавиш
        /// </summary>
        public void DefineInteraction()
        {
            
        }

        /// <summary> 
        /// 
        /// </summary>
        public override void DeInit()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Init()
        {
            _viewGame.DrawConsole();
            _gameModel.Start();
        }
    }
}
