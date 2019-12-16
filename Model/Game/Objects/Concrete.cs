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
        public Concrete(float parX, float parY) : base(parX, parY)
        {
        }

        public override string NameObject()
        {
            return "Concrete";
        }

        public override string ToString()
        {
            return " Concrete: " + base.ToString();
        }       
    }
}
