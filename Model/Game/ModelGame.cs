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
        /// Свойство для собирания золота
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
        /// Событие на создание уровня
        /// </summary>
        public event dMoveObjects CreateMapLevel;

        /// <summary>
        /// 
        /// </summary>
        public event dMoveObjects EndGameEvent;

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
        /// Запустить игру
        /// </summary>
        public void Start()
        {
            _gameThread = new Thread(new ThreadStart(StartGame));
            _gameThread.Name = "LodeRunner";
            _gameThread.Start();
            _gameThread.Priority = ThreadPriority.Normal;
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame()
        {
            if (_mapLevel != null)
            {
                while (MapLevel.isTrue())
                {
                    OnMove();
                }
                ResetGame();
                OnEndGameEvent();
            }
        }

        /// <summary>
        /// Пересоздать игру
        /// </summary>
        public void ResetGame()
        {
            MapLevel.GetMapLevel();
            MapLevel.Count = 0;
            MapLevel.MoveToFinalStairs = true;
            MapLevel.Index = 0;
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
