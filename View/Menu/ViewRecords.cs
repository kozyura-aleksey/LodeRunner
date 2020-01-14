using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    /// <summary>
    /// Класс - отображение рекордов
    /// </summary>
    public class ViewRecords : View.Game.View
    {
        /// <summary>
        /// Модель рекордов
        /// </summary>
        private ModelRecords _model;

        /// <summary>
        /// Создать представление рекордов 
        /// </summary>
        public ViewRecords(ModelRecords parModel)
        {
            _model = parModel;
            _model.gerRecords().ChangeNameEvent += Draw;
            Field = new StringBuilder[1];
        }

        /// <summary>
        /// Нарисовать элемент ввода имени
        /// </summary>
        public void Draw()
        {
            Field[0] = new StringBuilder("Enter name: " + Records.EnterNameString);
            Render();
        }
    }
}
