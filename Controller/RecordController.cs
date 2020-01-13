using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Класс - контроллер рекордов
    /// </summary>
    public class RecordController : Controller
    {
        /// <summary>
        /// Модель рекордов
        /// </summary>
        private Model.Menu.ModelRecords _modelRecords;

        /// <summary>
        /// Отображение рекордов
        /// </summary>
        private View.Menu.ViewRecords _viewRecords;

        /// <summary>
        /// Обработчик окончания ввода имени
        /// </summary>
        public delegate void dEndHandler();
        /// <summary>
        /// Событие окончания ввода
        /// </summary>
        public event dEndHandler EndEvent;

        /// <summary>
        /// Обработчик нажатия на кнопку
        /// </summary>
        private delegate void dEnterNameHandler(string parObject);

        /// <summary>
        /// Словарь действий при нажатии кнопки
        /// </summary>
        private Dictionary<ConsoleKey, dEnterNameHandler> _keysDict;

        /// <summary>
        /// 
        /// </summary>
        public RecordController()
        {
            _modelRecords = new Model.Menu.ModelRecords();
            _viewRecords = new View.Menu.ViewRecords(_modelRecords);
            _keysDict = new Dictionary<ConsoleKey, dEnterNameHandler>();
            SetKeys();
        }

        /// <summary>
        /// Установить действия для нажатия кнопок
        /// </summary>
        protected void SetKeys()
        {
            _keysDict.Add(ConsoleKey.Enter, DeinitAlphabetDown);
            ConsoleKey[] alphabet = (ConsoleKey[])Enum.GetValues(typeof(ConsoleKey));
            for (int i = 32; i < 58; i++)
            {
                _keysDict.Add(alphabet[i], _modelRecords.gerRecords().AddStringToName);
            }
            _keysDict.Add(ConsoleKey.Backspace, _modelRecords.gerRecords().DeleteChar);
        }

        /// <summary>
        /// Ввод имени и инициализация меню рекордов
        /// </summary>                         
        public void DeinitAlphabetDown(string parString)
        {
            if (Model.Menu.Records.AddRecord())
            {
                DeInit();
                Model.Menu.Records.EnterNameString = "";
                OnEnd();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DeInit()
        {
            KeyDownerController.KeyDowner.KeyDown -= EnterName;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Init()
        {
            KeyDownerController.KeyDowner.KeyDown += EnterName;
            _viewRecords.Draw();
        }


        /// <summary>
        /// Ввод имени
        /// </summary>              
        private void EnterName(ConsoleKey parKey)
        {
            lock (_modelRecords)
            {
                if (_keysDict != null)
                {
                    if (_keysDict.ContainsKey(parKey))
                    {
                        _keysDict[parKey](parKey.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Запуск события на окончание ввода
        /// </summary>
        private void OnEnd()
        {
            if (EndEvent != null)
            {
                EndEvent.Invoke();
            }
        }
    }
}