using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    /// <summary>
    /// Класс- контроллер меню
    /// </summary>
    public class MenuController : Controller
    {
        /// <summary>
        /// Модель меню
        /// </summary>
        private Model.Menu.Menu _model;

        /// <summary>
        /// Отображение меню
        /// </summary>
        private View.Menu.ViewMenu _view;


        public MenuController()
        {
            _model = new Model.Menu.Menu();
            _view = new View.Menu.ViewMenu();

        }

        /// <summary>
        /// 
        /// </summary>
        public override void DeInit()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void Init()
        {
            //FormMain.MouseClick
        }
    }
}
