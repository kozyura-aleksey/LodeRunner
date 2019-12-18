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
        public MapLevel _mapLevel;

        /// <summary>
        /// Делегат на создание уровня
        /// </summary>
        public delegate void createMap();

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
        public event moveObjects Draw;

        /// <summary>
        /// Событие на создание уровня
        /// </summary>
        public event createMap CreateMapLevel;

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
            _gameThread.Name = "LodeRunner";
            _gameThread.Start();
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame()
        {
            if (_mapLevel != null)
            {
                OnCreateMapLevel();
                OnDraw();
                OnMove();
            }        
        }

        /// <summary>
        /// Запуск события на отрисовку
        /// </summary>
        public void OnDraw()
        {
            if (Draw != null)
            {
                Draw.Invoke();
            }
        }
        /// <summary>
        /// Запуск события на движение
        /// </summary>
        public void OnMove()
        {
            if (Move != null)
            {
                Move.Invoke();
            }
        }   
        
        /// <summary>
        /// Запуск события на создание уровня
        /// </summary>
        public void OnCreateMapLevel()
        {
            if (CreateMapLevel != null)
            {
                CreateMapLevel.Invoke();
            }
        }
    }
}
