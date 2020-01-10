using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект веревка
    /// </summary>
    public class Rope : GameObject
    {
        /// <summary>
        /// Конструктор объекта веревка
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public Rope(int parX, int parY) : base(parX, parY)
        {
        }


        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Веревка: " + base.ToString();
        }
    }
}
