using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// Класс - модель меню
    /// </summary>
    public class ModelMenu
    {
        /// <summary>
        /// Экземпляр меню
        /// </summary>
        public Menu _menu = null;

        /// <summary>
        /// Создать модель меню
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
