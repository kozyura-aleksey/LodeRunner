using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// Класс - элементы меню
    /// </summary>
    public class MenuItems
    {
        /// <summary>
        /// Наименование пункта меню
        /// </summary>
        public String Name;

        /// <summary>
        /// Конструктор создания пункта меню
        /// </summary>
        /// <param name="parName"></param>
        public MenuItems(String parName)
        {
            Name = parName;
        }
    }
}
