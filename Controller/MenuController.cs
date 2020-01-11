using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Model.Menu.ModelMenu _model;

        /// <summary>
        /// Отображение меню
        /// </summary>
        private View.Menu.ViewMenu _view;

        /// <summary>
        /// Обработчик события старта игры
        /// </summary>
        public delegate void dStartHandler();

        /// <summary>
        /// Событие старта игры
        /// </summary>
        public event dStartHandler StartEvent;

        public MenuController()
        {
            _model = new Model.Menu.ModelMenu();
            _view = new View.Menu.ViewMenu(_model);
            _model.GetMenu().getMenuItems()[0].EnterEvent += Start;
            _model.GetMenu().getMenuItems()[1].EnterEvent += Exit;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DeInit()
        {
            FormMain.KeyDown -= MenuItemChoice;
            _view.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Init()
        {
            FormMain.KeyDown += MenuItemChoice;
            _view.Draw();
        }

        /// <summary>
        /// Событие на нажатие кнопки мыши
        /// </summary>                
        private void MenuItemChoice(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                _model.GetMenu().getMenuItems()[0].Enter();
            }
            if (e.KeyData == Keys.Escape)
            {
                _model.GetMenu().getMenuItems()[1].Enter();
            }
        }

        /// <summary>
        /// Выход из игры
        /// </summary>
        private void Exit()
        {
            FormMain.Close();
        }

        /// <summary>
        /// Запуск игры
        /// </summary>
        private void Start()
        {
            if (StartEvent != null)
            {
                StartEvent.Invoke();
            }
        }
    }
}
