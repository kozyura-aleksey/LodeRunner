using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class NullObject : GameObject
    {
        /// <summary>
        /// Конструктор объекта персонаж
        /// </summary>
        /// <param name="parX"></param>
        /// <param name="parY"></param>
        public NullObject(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// Получение информации
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " Null Object: " + base.ToString();
        }
    }
}
