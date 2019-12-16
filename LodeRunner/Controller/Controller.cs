using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    /// <summary>
    /// Класс - контроллер
    /// </summary>
    public abstract class Controller
    {
        /// <summary>
        /// Форма приложения
        /// </summary>
        public static Form FormMain { get; private set; }

        /// <summary>
        /// Создать форму для приложения
        /// </summary>
        public static void CreateForm()
        {
            if (FormMain == null)
            {
                FormMain = new Form();
            }
            //FormMain.KeyPreview = true;
        }

        /// <summary>
        /// Инициализировать контроллер
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Деинициализировать контроллер
        /// </summary>
        public abstract void DeInit();
    }
}
