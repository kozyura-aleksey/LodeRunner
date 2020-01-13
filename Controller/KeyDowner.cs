using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Нажатие на клавишу в консоли
    /// </summary>
    public class KeyDowner
    {
        /// <summary>
        /// Обработчик события нажатия на клавишу
        /// </summary>
        /// <param name="key">Ключ нажатой клавиши</param>
        public delegate void dKeyDowning(ConsoleKey key);

        /// <summary>
        /// Событие нажатие на клавишу
        /// </summary>
        public event dKeyDowning KeyDown;

        /// <summary>
        /// Слушать нажатие на клавишу
        /// </summary>
        public void KeyDowneer()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (KeyDown != null)
                {
                    KeyDown.Invoke(key);
                }
            }
        }
    }
}
