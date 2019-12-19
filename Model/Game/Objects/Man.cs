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
        public Man(int parX, int parY) : base(parX, parY)
        {
        }

        public override string NameObject()
        {
            return "Man";
        }

        public override string ToString()
        {
            return " Персонаж: " + base.ToString();
        }
    }
}
