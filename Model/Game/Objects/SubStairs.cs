using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект лестница
    /// </summary>
    public class SubStairs : GameObject
    {
        /// <summary>
        /// Конструктор объекта лестница
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public SubStairs(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Лестница: " + base.ToString();
        }
    }
}
