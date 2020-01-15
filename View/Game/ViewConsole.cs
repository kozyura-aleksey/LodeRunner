using CLIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game
{
    /// <summary>
    /// Абстрактный класс - view
    /// </summary>
    public class ViewConsole
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
            _kernelGraphics.Clear();
            Field = new StringBuilder[1];
            _kernelGraphics.Printstrings(Field);
        }

        /// <summary>
        /// Рендер графики
        /// </summary>
        public void Render()
        {
            _kernelGraphics.Clear();
            _kernelGraphics.Printstrings(Field);
            _kernelGraphics.Flush();
        }
    }
}
