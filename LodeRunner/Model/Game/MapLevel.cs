using Model.Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model.Game
{
    /// <summary>
    /// Класс - уровень карты
    /// </summary>
    public class MapLevel
    {

        /// <summary>
        /// Экземпляр уровня
        /// </summary>
        private static MapLevel mapLevel = null;

        /// <summary>
        /// Делегат на отрисовку
        /// </summary>
        public delegate void DrawwGame();

        /// <summary>
        /// Событие на отрисовку
        /// </summary>
        public event DrawwGame draw;

        /// <summary>
        /// Событие на передвижение игрока
        /// </summary>
        public event DrawwGame move;

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
        /// Создать поле игры
        /// </summary>
        public MapLevel()
        {
            //ViewGame.DrawGame();
        }

        /// <summary>
        /// Запуск события на движение
        /// </summary>
        public void onMove()
        {
            if (move != null)
            {
                move.Invoke();
            }
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
        /// Поток игры
        /// </summary>
        public Thread _gameThread;

        /// <summary>
        /// 
        /// </summary>
        public void StartGame()
        {
            OnDraw();
            onMove();
        }

        /// <summary>
        /// Получить экземпляр уровня
        /// </summary>
        /// <returns></returns>
        public static MapLevel GetMapLevel()
        {
            if (mapLevel == null)
            {
                mapLevel = new MapLevel();
            }
            return mapLevel;
        }
        

        /// <summary>
        /// Загрузка уровня 
        /// </summary>
        public static List<Model.Game.Objects.GameObject> LoadMapLevel()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Aleksey\source\repos\LodeRunner\levels\level1.txt");
            String[,] num = new String[lines.Length, lines[0].Split(' ').Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                {
                    num[i, j] = Convert.ToString(temp[j]);
                }
            }

            List<Model.Game.Objects.GameObject> objects = new List<Model.Game.Objects.GameObject>();

            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    objects.Add(GameObject.CreateObject(num[i, j], 16 * i, 16 * j));
                }
            }
            return objects;
        }

        /// <summary>
        /// Движение вправо
        /// </summary>
        public static float moveRightRunner()
        {
            List<Model.Game.Objects.GameObject> parObjects = MapLevel.LoadMapLevel();
            float dX = 0;
            foreach (Model.Game.Objects.GameObject aaa in parObjects)
            {
                if (aaa != null)
                {                   
                    if (aaa.NameObject() == "Man")
                    {                      
                        aaa.X += aaa.moveRightObject();
                        dX = aaa.X;
                    }                   
                }
            }
            return dX;
        }

        /// <summary>
        /// Движение вправо
        /// </summary>
        public static float moveLeftRunner()
        {
            List<Model.Game.Objects.GameObject> parObjects = MapLevel.LoadMapLevel();
            float dX = 0;
            foreach (Model.Game.Objects.GameObject aaa in parObjects)
            {
                if (aaa != null)
                {
                    if (aaa.NameObject() == "Man")
                    {
                        aaa.X -= aaa.moveRightObject();
                        dX = aaa.X;
                    }
                }
            }
            return dX;
        }
    }
}
