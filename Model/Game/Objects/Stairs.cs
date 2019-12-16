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
    public class Stairs : GameObject
    {
        public Stairs(float parX, float parY) : base(parX, parY)
        {
        }

        public override string NameObject()
        {
            return "Stairs";
        }

        public override string ToString()
        {
            return " Лестница: " + base.ToString();
        }
    }
}
