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
        /// Делагат на движение
        /// </summary>
        public delegate void moveObjects();

        /// <summary>
        /// Событие на движение
        /// </summary>
        public event moveObjects Move;

        /// <summary>
        /// 
        /// </summary>
        public void onMove()
        {
            if (Move != null)
            {
                Move.Invoke();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parModelGame"></param>
        public ViewGame(Model.ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _modelGame.draw += DrawGame;
            _modelGame.Move += reDrawGame;         
            _mapLevel = new MapLevel();
        }

        /// <summary>
        /// Прорисовка уровня
        /// </summary>
        /// <param name="parObjects"></param>
        public void DrawGame()
        {
            _mapLevel.draw(View.ViewForm);
        }

        /// <summary>
        /// Перерисовка уровня
        /// </summary>
        /// <param name="parObjects"></param>
        public void reDrawGame()
        {
            if (_mapLevel != null)
            {
                _mapLevel.draw(View.ViewForm);
            }
        }
       
    }
}
