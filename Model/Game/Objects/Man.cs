using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект персонаж
    /// </summary>
    public class Man : GameObject
    {
        /// <summary>
        /// Конструктор объекта персонаж
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public Man(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Персонаж: " + base.ToString();
        }
    }
}
