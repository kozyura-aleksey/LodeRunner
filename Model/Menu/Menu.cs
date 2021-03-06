﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// Класс - меню игры
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Набор пунктов меню
        /// </summary>
        private MenuItems[] _menuItems;

        /// <summary>
        /// Создать меню
        /// </summary>
        public Menu()
        {
            _menuItems[0] = new MenuItems("Run Game");
            _menuItems[1] = new MenuItems("Records");
            _menuItems[2] = new MenuItems("Exit");
        }

        /// <summary>
        /// Вернуть пункты меню
        /// </summary>
        /// <returns></returns>
        public MenuItems[] getMenuItems()
        {
            return _menuItems;
        }

    }
}
