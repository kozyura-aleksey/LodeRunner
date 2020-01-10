using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект золото
    /// </summary>
    public class Gold : GameObject
    {
        /// <summary>
        /// Конструктор объекта золото
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public Gold(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Золото: " + base.ToString();
        }
    }
}
