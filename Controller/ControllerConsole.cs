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
    public abstract class ControllerConsole
    {
       
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
