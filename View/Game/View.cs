using Model;
using Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameObject = Model.Game.Objects.GameObject;

namespace View
{
    /// <summary>
    /// Абстрактный класс - отображение
    /// </summary>
    public abstract class View
    {
        /// <summary>
        /// Форма для отображения элементов
        /// </summary>
        public static Form ViewForm { get; set; }

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public static void Init()
        {
            Application.Run(ViewForm);
        }

        /// <summary>
        /// Инициализация консоли
        /// </summary>
        public static void InitConsole()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Контекст буферизации
        /// </summary>
        private static BufferedGraphicsContext _context;

        /// <summary>
        /// Буфер
        /// </summary>
        protected static BufferedGraphics _graphics;

        /// <summary>
        /// Настройка параметров формы для работы
        /// </summary>
        private static void FormDecorator()
        {
            ViewForm.Width = 540;
            ViewForm.Height = 410;
            ViewForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            ViewForm.BackColor = Color.Black;
        }

        /// <summary>
        /// Установить настройки для формы
        /// </summary>
        /// <param name="parForm">Форма</param>
        public static void SetFormParameters(Form parForm)
        {
            ViewForm = parForm;
            FormDecorator();
            _context = BufferedGraphicsManager.Current;
            _graphics = _context.Allocate(ViewForm.CreateGraphics(), ViewForm.ClientRectangle);
        }
    }
}
