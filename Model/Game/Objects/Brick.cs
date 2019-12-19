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
        public Brick(int parX, int parY) : base(parX, parY)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string NameObject()
        {
            return "Brick";
        }

        public override string ToString()
        {
            return " Brick: " + base.ToString();
        }
    }
}
