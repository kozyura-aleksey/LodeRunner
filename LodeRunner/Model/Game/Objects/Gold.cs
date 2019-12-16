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
        public Gold(float parX, float parY) : base(parX, parY)
        {
        }

        public override string NameObject()
        {
            return "Gold";
        }

        public override string ToString()
        {
            return " Золото: " + base.ToString();
        }
    }
}
