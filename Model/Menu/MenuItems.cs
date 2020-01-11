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

        // <summary>
        /// Обработчик событий для класса MenuItem
        /// </summary>
        public delegate void dMenuItemHandler();
        /// <summary>
        /// Событие на выбор пункта меню
        /// </summary>
        public event dMenuItemHandler EnterEvent;


        /// <summary>
        /// Конструктор создания пункта меню
        /// </summary>
        /// <param name="parName"></param>
        public MenuItems(String parName)
        {
            Name = parName;
        }

        /// <summary>
        /// Выбрать пункт меню
        /// </summary>
        public void Enter()
        {
            OnEnter();
        }

        /// <summary>
        /// Запустить событие на выбор пункта меню
        /// </summary>
        private void OnEnter()
        {
            if (EnterEvent != null)
            {
                EnterEvent.Invoke();
            }
        }
    }
}
