using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект кирпич
    /// </summary>
    public class Brick : GameObject
    {
        /// <summary>
        /// Конструктор объекта кирпич
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public Brick(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Brick: " + base.ToString();
        }
    }
}
