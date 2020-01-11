using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public Menu _menu = null;

        /// <summary>
        /// 
        /// </summary>
        public ModelMenu()
        {
            _menu = new Menu();
        }

        /// <summary>
        /// Получить меню
        /// </summary>
        /// <returns>Меню</returns>
        public Menu GetMenu()
        {
            return _menu;
        }

    }
}
