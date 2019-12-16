using Model.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс - модель игры
    /// </summary>
    public class ModelGame
    {
        /// <summary>
        /// Уровень игры
        /// </summary>
        public MapLevel _mapLevel { get; set; }

        /// <summary>
        /// Делагат на движение
        /// </summary>
        public delegate void moveObjects();

        /// <summary>
        /// Событие на движение
        /// </summary>
        public event moveObjects Move;

        /// <summary>
        /// Событие на движение
        /// </summary>
        public event moveObjects draw;

        /// <summary>
        /// Игрок
        /// </summary>
        public Model.Game.Objects.Man objectMan;

        /// <summary>
        /// Поток игры
        /// </summary>
        public Thread _gameThread;

        /// <summary>
        /// Создать модель игры
        /// </summary>
        public ModelGame()
        {
            _mapLevel = MapLevel.GetMapLevel();
        }

        /// <summary>
        /// Запустить игру в игровом потоке
        /// </summary>
        public void Start()
        {
            _gameThread = new Thread(StartGame);
            _gameThread.Name = "Game";
            _gameThread.Start();
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame()
        {
            OnDraw();
            onMove();
        }

        /// <summary>
        /// Запуск события на отрисовку
        /// </summary>
        public void OnDraw()
        {
            if (draw != null)
            {
                draw.Invoke();
            }
        }
        /// <summary>
        /// Запуск собьытия на движение
        /// </summary>
        public void onMove()
        {
            if (Move != null)
            {
                Move.Invoke();
            }
        }               
    }
}
