using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.Objects
{
    /// <summary>
    /// Класс - объект враг
    /// </summary>
    public class Enemy : GameObject
    {
        public Enemy(int parX, int parY) : base(parX, parY)
        {
        }

        public override string NameObject()
        {
            return "Enemy";
        }

        public override string ToString()
        {
            return " Враг: " + base.ToString();
        }
    }
}
