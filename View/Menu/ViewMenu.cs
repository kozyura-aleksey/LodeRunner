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
    public class ViewMenu : View
    {
        /// <summary>
        /// 
        /// </summary>
        private Model.Menu.ModelMenu _modelGame;

        /// <summary>
        /// Представление меню
        /// </summary>
        public Model.Menu.Menu Menu { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ViewMenu(Model.Menu.ModelMenu parModel)
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
            _bufer.Graphics.DrawString("Game rules:", new Font("Calibri", 18), new SolidBrush(Color.White), 10, View.viewform.ClientRectangle.Height - 470);
            _bufer.Graphics.DrawLine(new Pen(new SolidBrush(Color.White)), 0, 70, View.viewform.ClientRectangle.Height, 70);
            _bufer.Graphics.DrawString("Collect all the gold on the map by moving the keys: 'up', ", new Font("Calibri", 15), new SolidBrush(Color.White), 10, View.viewform.ClientRectangle.Height - 440);
            _bufer.Graphics.DrawString("'down', 'right', 'left'.", new Font("Calibri", 15), new SolidBrush(Color.White), 10, View.viewform.ClientRectangle.Height - 410);
            _bufer.Graphics.DrawString("You can also move along the ropes", new Font("Calibri", 15), new SolidBrush(Color.White), 10, View.viewform.ClientRectangle.Height - 380);
            _bufer.Graphics.DrawString("Press Enter to Start Game", new Font("Calibri", 18), new SolidBrush(Color.White), 10, View.viewform.ClientRectangle.Height - 300);
            _bufer.Graphics.DrawString("Press Esc to Exit", new Font("Calibri", 18), new SolidBrush(Color.White), 10, View.viewform.ClientRectangle.Height - 270);
        }

        /// <summary>
        /// Отрисовка названия и линии подчёркивания
        /// </summary>
        private void DrawTitle()
        {
            _bufer.Graphics.DrawString("LodeRunner", new Font("Calibri", 20), new SolidBrush(Color.White) , 170 , View.viewform.ClientRectangle.Height - 500);
            _bufer.Graphics.DrawLine(new Pen(new SolidBrush(Color.White)), 0, 40, View.viewform.ClientRectangle.Height, 40);
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
            //DrawRecords();
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
