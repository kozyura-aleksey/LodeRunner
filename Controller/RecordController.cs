using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        /// Обработчик нажатия на кнопку
        /// </summary>
        private delegate void dEnterNameHandler(string parObject);

        /// <summary>
        /// Словарь действий при нажатии кнопки
        /// </summary>
        private Dictionary<Keys, dEnterNameHandler> _keysDict;

        /// <summary>
        /// Обработчик окончания ввода имени
        /// </summary>
        public delegate void dEndHandler();
        /// <summary>
        /// Событие окончания ввода
        /// </summary>
        public event dEndHandler EndEvent;

        public RecordController()
        {
            _modelRecords = new Model.Menu.ModelRecords();
            _viewRecords = new View.Menu.ViewRecords(_modelRecords);
            _keysDict = new Dictionary<Keys, dEnterNameHandler>();
            SetKeys();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DeInit()
        {
            FormMain.KeyDown -= EnterName;
            _viewRecords.Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Init()
        {
            FormMain.KeyDown += EnterName;
            _viewRecords.Draw();
        }

        /// <summary>
        /// Установить действия для нажатия кнопок
        /// </summary>
        protected void SetKeys()
        {
            _keysDict.Add(Keys.Enter, DeinitAlphabetDown);
            Keys[] alphabet = (Keys[])Enum.GetValues(typeof(Keys));
            for (int i = 60; i < 90; i++)
            {
                _keysDict.Add(alphabet[i], _modelRecords.gerRecords().AddStringToName);
            }
            _keysDict.Add(Keys.Back, _modelRecords.gerRecords().DeleteChar);
        }

        /// <summary>
        /// Ввод имени и инициализация меню рекордов
        /// </summary>                         
        public void DeinitAlphabetDown(string parString)
        {
            //if (Model.Menu.Records.AddRecord())
            //{
                DeInit();
                Model.Menu.Records.EnterNameString = "";
                OnEnd();
            //}
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

        /// <summary>
        /// Ввод имени
        /// </summary>              
        private void EnterName(object sender, KeyEventArgs e)
        {
            if (_keysDict != null)
            {
                if (_keysDict.ContainsKey(e.KeyData))
                {
                    _keysDict[e.KeyData](e.KeyData.ToString());
                }
            }
        }
    }
}