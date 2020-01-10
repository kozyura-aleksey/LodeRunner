using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект враг
    /// </summary>
    public class Enemy : GameObject
    {
        /// <summary>
        /// Конструктор объекта враг
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public Enemy(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Враг: " + base.ToString();
        }
    }
}
