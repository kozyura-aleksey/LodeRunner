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
        public SubStairs(int parX, int parY) : base(parX, parY)
        {
        }

        public override string NameObject()
        {
            return "SubStairs";
        }

        public override string ToString()
        {
            return " Лестница: " + base.ToString();
        }
    }
}
