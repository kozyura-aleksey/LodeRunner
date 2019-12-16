using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект веревка
    /// </summary>
    public class Rope : GameObject
    {
        public Rope(float parX, float parY) : base(parX, parY)
        {
        }

        public override string NameObject()
        {
            return "Rope";
        }

        public override string ToString()
        {
            return " Веревка: " + base.ToString();
        }
    }
}
