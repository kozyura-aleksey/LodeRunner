using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;

namespace Controller.Menu
{
    /// <summary>
    /// Класс - котроллер меню
    /// </summary>
    public class MenuControllerConsole : ControllerConsole
    {
        /// <summary>
        /// Модель меню
        /// </summary>
        private ModelMenu _model;

        /// <summary>
        /// Представление меню
        /// </summary>
        private ViewMenuConsole _view;

        /// <summary>
        /// Обработчик события старта игры
        /// </summary>
        public delegate void dStartHandler();

        /// <summary>
        /// Событие старта игры
        /// </summary>
        public event dStartHandler StartEvent;

        /// <summary>
        /// Создать контроллер меню
        /// </summary>
        public MenuControllerConsole()
        {
            _model = new ModelMenu();
            _view = new ViewMenuConsole(_model);
            _model.GetMenu().getMenuItems()[0].EnterEvent += Start;
            _model.GetMenu().getMenuItems()[1].EnterEvent += Exit;
        }

        /// <summary>
        /// Инициализация контроллера
        /// </summary>
        public override void Init()
        {
            KeyDownerController.KeyDowner.KeyDown += MenuItemChoice;
            _view.Draw();
        }

        /// <summary>
        /// Деинициализация контроллера
        /// </summary>
        public override void DeInit()
        {
            KeyDownerController.KeyDowner.KeyDown -= MenuItemChoice;
            _view.Hide();
        }

        /// <summary>
        /// Событие на нажатие кнопки мыши
        /// </summary>                
        private void MenuItemChoice(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
            {
                _model.GetMenu().getMenuItems()[0].Enter();
            }
            if (key == ConsoleKey.Escape)
            {
                _model.GetMenu().getMenuItems()[1].Enter();
            }
        }

        /// <summary>
        /// Выход из игры
        /// </summary>
        private void Exit()
        {
            Environment.Exit(0);
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
