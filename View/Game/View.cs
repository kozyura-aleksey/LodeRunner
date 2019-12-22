using Model;
using Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameObject = Model.Game.Objects.GameObject;

namespace View
{
    /// <summary>
    /// Абстрактный класс - отображение
    /// </summary>
    public abstract class View
    {
             
        /// <summary>
        /// Инициализация консоли
        /// </summary>
        public static void InitConsole()
        {
            /*for (int i = 0; i < MapLevel.num.GetLength(1); i++)
            {
                for (int j = 0; j < MapLevel.num.GetLength(0); j++)
                {
                    Console.Write(MapLevel.num[j, i]);
                }
                Console.WriteLine();
            }
            //Console.ReadKey();

            for (int i = 0; i < MapLevel.consoleObjects.GetLength(1); i++)
            {
                for (int j = 0; j < MapLevel.consoleObjects.GetLength(0); j++)
                {
                    Console.Write(MapLevel.consoleObjects[j, i]);
                }
                Console.WriteLine();
            }*/
            Console.ReadKey();
        }                           
    }
}
