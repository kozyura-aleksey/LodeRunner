using Model.Menu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    /// <summary>
    /// Класс - отображение рекордов
    /// </summary>
    public class ViewRecords : View
    {
        /// <summary>
        /// Модель рекордов
        /// </summary>
        private ModelRecords _model;

        public ViewRecords(ModelRecords parModel)
        {
            _model = parModel;
            _model.gerRecords().ChangeNameEvent += Draw;
        }

        /// <summary>
        /// Нарисовать элемент ввода имени
        /// </summary>
        public void Draw()
        {
            Canvas.Clear(Color.Black);
            Canvas.DrawString("Enter name: ", new Font("Calibri", 20), new SolidBrush(Color.White), 80, 80);
            Canvas.FillRectangle(new SolidBrush(Color.Black), View.viewform.ClientRectangle.Width / 2 - 200 / 2,
                View.viewform.ClientRectangle.Height / 4 - 50 / 2, 200, 50);
            Canvas.DrawRectangle(new Pen(Color.White), View.viewform.ClientRectangle.Width / 2 - 200 / 2,
                View.viewform.ClientRectangle.Height / 4 - 50 / 2, 200, 50);
            Canvas.DrawString(Records.EnterNameString, new Font("Calibri", 20), new SolidBrush(Color.White),
                View.viewform.ClientRectangle.Width / 2 - 200 / 2,
                View.viewform.ClientRectangle.Height / 4 - 50 / 2 + 10);
            Render();
        }
    }
}
