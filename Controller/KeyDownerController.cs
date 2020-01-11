using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Контроллер нажатия кнопок
    /// </summary>
    public class KeyDownerController
    {
        /// <summary>
        /// Поле слушателя нажатия кнопки
        /// </summary>
        public static KeyDowner KeyDowner;
        /// <summary>
        /// Поток на нажатие кнопки
        /// </summary>
        public Thread _threadKeyDowner;

        /// <summary>
        /// Создать контроллер обработчик нажатий кнопок
        /// </summary>
        public KeyDownerController()
        {
            InitKeyDowner();
            KeyDownerStart();
        }
        /// <summary>
        /// Инициализация потока нажатия кнопки
        /// </summary>
        public void InitKeyDowner()
        {
            KeyDowner = new KeyDowner();
            _threadKeyDowner = new Thread(new ThreadStart(KeyDowner.KeyDowneer));
            _threadKeyDowner.Priority = ThreadPriority.Highest;
        }

        /// <summary>
        /// Запуск потока нажатия кнопки
        /// </summary>
        public void KeyDownerStart()
        {
            _threadKeyDowner.Start();
        }

    }
}
