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
    public class ViewRecordsForm : FormView
    {
        /// <summary>
        /// Модель рекордов
        /// </summary>
        private ModelRecords _model;

        public ViewRecordsForm(ModelRecords parModel)
        {
            _model = parModel;
            _model.gerRecords().ChangeNameEvent += Draw;
        }

        /// <summary>
        /// Нарисовать элемент ввода имени
        /// </summary>
        public void Draw()
        {
            _bufer.Graphics.Clear(Color.Black);
            _bufer.Graphics.DrawString("Enter name: ", new Font("Times New Roman", 20), new SolidBrush(Color.White), 110, 50);
            _bufer.Graphics.FillRectangle(new SolidBrush(Color.Black), FormView.viewform.ClientRectangle.Width / 2 - 300 / 2,
                FormView.viewform.ClientRectangle.Height / 4 - 50 / 2, 300, 50);
            _bufer.Graphics.DrawRectangle(new Pen(Color.White), FormView.viewform.ClientRectangle.Width / 2 - 300 / 2,
                FormView.viewform.ClientRectangle.Height / 4 - 50 / 2, 300, 50);
            _bufer.Graphics.DrawString(Records.EnterNameString, new Font("Times New Roman", 20), new SolidBrush(Color.White),
                FormView.viewform.ClientRectangle.Width / 2 - 200 / 2,
                FormView.viewform.ClientRectangle.Height / 4 - 50 / 2 + 10);
            Render();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Hide()
        {
            _bufer.Graphics.Clear(viewform.BackColor);
            Render();
        }
    }
}
