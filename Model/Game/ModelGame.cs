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
        private MapLevel _mapLevel;

        /// <summary>
        /// Свойство для уровня игры
        /// </summary>
        public MapLevel MapLevel { get => _mapLevel; set => _mapLevel = value; }

        /// <summary>
        /// Делагат на движение
        /// </summary>
        public delegate void dMoveObjects();

        /// <summary>
        /// Событие на движение
        /// </summary>
        public event dMoveObjects Move;

        /// <summary>
        /// Событие на движение
        /// </summary>
        public event dMoveObjects Draw;

        /// <summary>
        /// Событие окончания игры
        /// </summary>
        public event dMoveObjects EndGameEvent;

        /// <summary>
        /// Событие на создание уровня
        /// </summary>
        public event dMoveObjects CreateMapLevel;

        /// <summary>
        /// Игровой поток
        /// </summary>
        private Thread _gameThread;

       
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
            _gameThread = new Thread(new ThreadStart(StartGame));
            _gameThread.Name = "Game";
            _gameThread.Start();
            _gameThread.Priority = ThreadPriority.Highest;
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame()
        {
            if (_mapLevel != null)
            {
                if (MapLevel.count < 6)
                {
                    OnMove();
                }
            }       
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartGame2()
        {
            OnEndGameEvent();
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

        /// <summary>
        /// 
        /// </summary>
        public void OnEndGameEvent()
        {
            if (EndGameEvent != null)
            {
                EndGameEvent.Invoke();
            }
        }
    }
}
