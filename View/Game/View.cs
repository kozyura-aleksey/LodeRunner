using CLIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game
{
    /// <summary>
    /// 
    /// </summary>
    public class View
    {
        /// <summary>
        /// Поле игры(символы)
        /// </summary>
        public StringBuilder[] Field { get; set; }

        /// <summary>
        /// Быстрая буферизация
        /// </summary>
        protected KernelGraphics _kernelGraphics = KernelGraphics.Instance;

        /// <summary>
        /// Скрыть представление
        /// </summary>
        public void Hide()
        {
            Field = new StringBuilder[1];
            Render();
        }

        /// <summary>
        /// Рендер графики
        /// </summary>
        public void Render()
        {
            _kernelGraphics.Printstrings(Field);
            //_kernelGraphics.Flush();
        }
    }
}
