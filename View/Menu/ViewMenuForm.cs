using Model.Menu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;

namespace View.Menu
{
    /// <summary>
    /// Класс - отображение меню
    /// </summary>
    public class ViewMenuForm : FormView
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        private Model.Menu.ModelMenu _modelGame;

        /// <summary>
        /// Представление меню
        /// </summary>
        public Model.Menu.Menu Menu { get; private set; }

        /// <summary>
        /// Конструктор представления меню
        /// </summary>
        public ViewMenuForm(Model.Menu.ModelMenu parModel)
        {
            _modelGame = parModel;
            Menu = parModel.GetMenu();
        }

        /// <summary>
        /// Отрисовка пунков меню для выбора кнопок
        /// </summary>
        /// <param name="parItem"></param>
        private void DrawMenuItem(MenuItems parItem)
        {
            _bufer.Graphics.DrawString("Game rules:", new Font("Times New Roman", 18), new SolidBrush(Color.White), 10, FormView.viewform.ClientRectangle.Height - 470);
            _bufer.Graphics.DrawLine(new Pen(new SolidBrush(Color.White)), 0, 65, FormView.viewform.ClientRectangle.Height, 65);
            _bufer.Graphics.DrawString("Collect all the gold on the map by moving the keys: 'up', ", new Font("Times New Roman", 15), new SolidBrush(Color.White), 10, FormView.viewform.ClientRectangle.Height - 440);
            _bufer.Graphics.DrawString("'down', 'right', 'left'.", new Font("Times New Roman", 15), new SolidBrush(Color.White), 10, FormView.viewform.ClientRectangle.Height - 410);
            _bufer.Graphics.DrawString("You can also move along the ropes.", new Font("Times New Roman", 15), new SolidBrush(Color.White), 10, FormView.viewform.ClientRectangle.Height - 380);
            _bufer.Graphics.DrawString("Press Enter to Start Game", new Font("Times New Roman", 18), new SolidBrush(Color.White), 10, FormView.viewform.ClientRectangle.Height - 330);
            _bufer.Graphics.DrawString("Press Esc to Exit", new Font("Times New Roman", 18), new SolidBrush(Color.White), 10, FormView.viewform.ClientRectangle.Height - 300);
        }

        /// <summary>
        /// Отрисовка названия и линии подчёркивания
        /// </summary>
        private void DrawTitle()
        {
            _bufer.Graphics.DrawString("LodeRunner", new Font("Times New Roman", 20), new SolidBrush(Color.White) , 170 , FormView.viewform.ClientRectangle.Height - 500);
            _bufer.Graphics.DrawLine(new Pen(new SolidBrush(Color.White)), 0, 40, FormView.viewform.ClientRectangle.Height, 40);
        }

        /// <summary>
        /// Отрисовка меню
        /// </summary>
        private void DrawMenu()
        {
            DrawTitle();
            foreach (MenuItems item in Menu.getMenuItems())
            {
                DrawMenuItem(item);
            }
            DrawRecords();
        }

        /// <summary>
        /// Нарисовать рекорды
        /// </summary>
        public void DrawRecords()
        {
            int count = Records.RecordNames.Count;
            for (int i = 0; i < Records.MaxCountRecords; i++)
            {
                if (i >= count)
                {
                    _bufer.Graphics.DrawString("----", new Font("Times New Roman", 20), new SolidBrush(Color.White),
                    10, 270 + i * 40);
                    _bufer.Graphics.DrawString("----", new Font("Times New Roman", 20), new SolidBrush(Color.White),
                    viewform.ClientRectangle.Width - 60, 270 + i * 40);
                }
                else
                {
                    _bufer.Graphics.DrawString(Model.Menu.Records.RecordNames[i], new Font("Times New Roman", 20), new SolidBrush(Color.White),
                    10, 270 + i * 40);
                    _bufer.Graphics.DrawString(Model.Menu.Records.RecordsDict[Records.RecordNames[i]].ToString(),
                        new Font("Times New Roman", 20), new SolidBrush(Color.White),
                        viewform.ClientRectangle.Width - 60, 270 + i * 40);
                }
            }
        }


        /// <summary>
        /// Нарисовать представление меню
        /// </summary>
        public void Draw()
        {
            _bufer.Graphics.Clear(Color.Black);
            DrawMenu();
            _bufer.Render();
        }
        
        /// <summary>
        /// Скрыть представлен
        /// </summary>
        public void Hide()
        {
            _bufer.Graphics.Clear(viewform.BackColor);
            _bufer.Render();
        }
    }
}
