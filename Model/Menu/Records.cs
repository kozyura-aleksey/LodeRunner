using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class Records
    {
        /// <summary>
        /// Список имен игроков
        /// </summary>
        public static List<string> RecordNames { get; private set; }
        /// <summary>
        /// Список очков игроков
        /// </summary>
        private static List<int> _recordMoney;
        /// <summary>
        /// Словарь соответствия очков игрокам
        /// </summary>
        public static Dictionary<string, int> RecordsDict { get; private set; }
        /// <summary>
        /// Максимальное количество записей в таблице рекордов
        /// </summary>
        public static int MaxCountRecords { get; } = 8;
        /// <summary>
        /// Вводимое имя игрока
        /// </summary>
        public static string EnterNameString { get; set; } = "";
        /// <summary>
        /// Максимальная длина имени
        /// </summary>
        private int MaxLetterCount { get; } = 10;
        /// <summary>
        /// Обработчик изменения имени
        /// </summary>
        public delegate void dChangeNameHandler();
        /// <summary>
        /// Событие на изменение имени
        /// </summary>
        public event dChangeNameHandler ChangeNameEvent;

        /// <summary>
        /// Создать меню рекордов
        /// </summary>
        public Records()
        {
            RecordNames = new List<string>();
            _recordMoney = new List<int>();
            RecordsDict = new Dictionary<string, int>();
            ReadFileToRecords();
        }

        /// <summary>
        /// Добавление рекорда в реестр, если элементов больше 10, последнийрезультат удаляется
        /// </summary>
        /// <param name="parName">Имя игрока</param>
        /// <param name="parMoney">Количество очков</param>
        /// <returns>Получилось ли добавить</returns>
        public static bool AddRecord()
        {
            return true;
        }

        /// <summary>
        /// Добавление строки к строке имени игрока
        /// </summary>
        /// <param name="parString">Добавляемая строка</param>
        public void AddStringToName(string parString)
        {
            bool isEmpty = parString == "";
            bool lessMax = EnterNameString.Length + parString.Length < MaxLetterCount;
            if (!isEmpty && lessMax)
            {
                EnterNameString += parString;
                OnChangeName();
            }
        }

        /// <summary>
        /// Удаление последнего символа строки
        /// </summary>                                         
        public void DeleteChar(string parString)
        {
            if (EnterNameString.Length != 0)
            {
                EnterNameString = EnterNameString.Remove(EnterNameString.Length - 1, 1);
                OnChangeName();
            }
        }

        /// <summary>
        /// Запустить событие на изменение имени
        /// </summary>
        private void OnChangeName()
        {
            if (ChangeNameEvent != null)
            {
                ChangeNameEvent.Invoke();
            }
        }

        /// <summary>
        /// Чтение рекордов из файла
        /// </summary>
        public static void ReadFileToRecords()
        {


        }

        /// <summary>
        /// Запись рекордов в файл
        /// </summary>
        public static void WriteFileFromRecords()
        {

        }
    }

}
