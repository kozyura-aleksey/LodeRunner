using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект бетон
    /// </summary>
    public class Concrete : GameObject
    {
        /// <summary>
        /// Конструктор объекта бетон
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public Concrete(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Concrete: " + base.ToString();
        }       
    }
}
