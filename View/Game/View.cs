using Model;
using Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Game;
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
        private static Form ViewForm { get; set; }

        /// <summary>
        /// Свойство для формы игры
        /// </summary>
        public static Form viewform { get => ViewForm; set => ViewForm = value; }

        /// <summary>
        /// Поле для рисования
        /// </summary>
        public static Graphics Canvas;

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public static void Init()
        {
            Application.Run(ViewForm);                   
        }
       
        /// <summary>
        /// Настройка параметров формы для работы
        /// </summary>
        private static void FormDecorator()
        {
            ViewForm.Width = 540;
            ViewForm.Height = 550;
            ViewForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            ViewForm.BackColor = Color.Black;
        }


        public BufferedGraphics _bufer = BufferedGraphicsManager.Current.Allocate(viewform.CreateGraphics(), viewform.ClientRectangle);

        /// <summary>
        /// Установить настройки для формы
        /// </summary>
        /// <param name="parForm">Форма</param>
        public static void SetFormParameters(Form parForm)
        {
            ViewForm = parForm;
            FormDecorator();
        }

        /// <summary>
        /// Рендер графики
        /// </summary>
        public void Render()
        {
            _bufer.Render();
        }
    }
}
