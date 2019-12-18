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
        /// 
        /// </summary>
        /// <param name="parModelGame"></param>
        public ViewGame(Model.ModelGame parModelGame)
        {
            _modelGame = parModelGame;
            _modelGame.CreateMapLevel += CreateMap;
            _modelGame.Draw += DrawGame;            
            _modelGame.Move += ReDrawGame;         
            _mapLevel = new MapLevel();
        }

        /// <summary>
        /// Создание уровня
        /// </summary>
        public void CreateMap()
        {
            _mapLevel = new MapLevel();
        }

        /// <summary>
        /// Прорисовка уровня
        /// </summary>
        /// <param name="parObjects"></param>
        public void DrawGame()
        {
            _mapLevel.Draw(View.ViewForm);
        }

        /// <summary>
        /// Перерисовка уровня
        /// </summary>
        /// <param name="parObjects"></param>
        public void ReDrawGame()
        {
            if (_modelGame._mapLevel != null)
            {
                _modelGame._mapLevel.Draw(View.ViewForm);
            }
        }

        /// <summary>
        /// Передвижение вправо
        /// </summary>
        public void MoveRightRunner()
        {
            _modelGame._mapLevel.MoveRightRunner();
            ReDrawGame();
        }

        /// <summary>
        /// Передвижение влево
        /// </summary>
        public void MoveLeftRunner()
        {
            _modelGame._mapLevel.MoveLeftRunner();
            ReDrawGame();
        }

        /// <summary>
        /// Передвижение вверх
        /// </summary>
        public void MoveUpRunner()
        {
            _modelGame._mapLevel.MoveUpRunner();
            ReDrawGame();
        }

        /// <summary>
        /// Передвижение вниз
        /// </summary>
        public void MoveDownRunner()
        {
            _modelGame._mapLevel.MoveDownRunner();
            ReDrawGame();
        }


        }
}
