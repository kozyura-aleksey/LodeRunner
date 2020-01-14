using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;

namespace View.Menu
{
    /// <summary>
    /// Класс - представление меню
    /// </summary>
    public class ViewMenu : View.Game.View
    {

        /// <summary>
        /// Модель меню
        /// </summary>
        private ModelMenu _modelMenu;

        /// <summary>
        /// Представление меню
        /// </summary>
        public Model.Menu.Menu menu;
  
        /// <summary>
        /// Создать представление меню
        /// </summary>
        /// <param name="parModel">Модель меню</param>
        public ViewMenu(ModelMenu parModel)
        {
            _modelMenu = parModel;
            menu = parModel.GetMenu();
            Field = new StringBuilder[Records.MaxCountRecords + 20];
        }

        /// <summary>
        /// Создать предствление названия игры
        /// </summary>
        private void DrawTitle()
        {
            Field[0] = new StringBuilder(string.Format("{0,10} {1,-10}", "", "LodeRunner"));
        }

        /// <summary>
        /// Создать представление выбора кнопки 
        /// </summary>
        /// <param name="parIndex">Индекс символа</param>
        private void DrawTextForButton(int parIndex)
        {
            Field[9] = new StringBuilder(string.Format("{0,10} {1,-10}", "", "Game rules:"));
            Field[10] = new StringBuilder(string.Format("{0,-30}", "Collect all the gold on the map  "));
            Field[11] = new StringBuilder(string.Format("{0,-20}", "by moving the keys: 'up', 'down',"));
            Field[12] = new StringBuilder(string.Format("{0,-20}", " 'right', 'left'."));
            Field[13] = new StringBuilder(string.Format("{0,-20}", "You can also move along the"));
            Field[14] = new StringBuilder(string.Format("{0,-20}", "ropes"));
            Field[15] = new StringBuilder(string.Format("{0,-20}", "                                  "));
            Field[16] = new StringBuilder(string.Format("{0,3} {1,-10}", "", "Press Enter to Start Game"));
            Field[17] = new StringBuilder(string.Format("{0,3} {1,-10}", "", "Press Esc to Exit"));
        }

        /// <summary>
        /// Создать представление меню
        /// </summary>
        private void DrawMenu()
        {
            DrawTitle();
            DrawRecords(1);
            DrawTextForButton(9);        
        }

        /// <summary>
        /// Нарисовать рекорды
        /// </summary>
        /// <param name="parIndex">Индекс символа</param>
        public void DrawRecords(int parIndex)
        {
            int count = Records.RecordNames.Count;
            for (int i = 0; i < Records.MaxCountRecords; i++)
            {
                if (i >= count)
                {
                    Field[parIndex + i] = new StringBuilder(string.Format("{0,12} {1,10}", "----", "----"));
                }
                else
                {
                    Field[parIndex + i] = new StringBuilder(string.Format("{0,12} {1,10}", Records.RecordNames[i], Records.RecordsDict[Records.RecordNames[i]]));
                }
            }
        }

        /// <summary>
        /// Нарисовать представление меню
        /// </summary>
        public void Draw()
        {
            Field = new StringBuilder[Records.MaxCountRecords + 20];
            DrawMenu();
            Render();
        }        
    }
}
