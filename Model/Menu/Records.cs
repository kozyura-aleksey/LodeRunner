using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// Класс - рекорды
    /// </summary>
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
            bool exists = RecordsDict.ContainsKey(EnterNameString);
            bool emptyName = EnterNameString == "";
            bool pointLessZero = Model.Game.MapLevel.Record < 0;
            if (!exists && !pointLessZero && !emptyName)
            {
                int k = RecordsDict.Count;
                for (int i = 0; i < _recordMoney.Count; i++)
                {
                    if (Model.Game.MapLevel.Record > _recordMoney[i])
                    {
                        k = i;
                        break;
                    }
                }
                RecordNames.Insert(k, EnterNameString);
                _recordMoney.Insert(k, Model.Game.MapLevel.Record);
                RecordsDict.Add(EnterNameString, Model.Game.MapLevel.Record);
                if (RecordsDict.Count >= MaxCountRecords)
                {
                    RecordsDict.Remove(RecordNames[MaxCountRecords - 1]);
                    RecordNames.RemoveAt(MaxCountRecords - 1);
                    _recordMoney.RemoveAt(MaxCountRecords - 1);
                }
                WriteFileFromRecords();
                return true;
            }
            else
            {
                return false;
            }

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
            FileStream recordFile = new FileStream("..\\records.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(recordFile);
            List<string> lines = new List<string>();
            try
            {
                if (!(recordFile.Length == 0))
                {
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                    for (int i = 0; i < lines.Count; i++)
                    {
                        string name = "";
                        string money = "";
                        int j = 0;
                        while (lines[i][j] != '|' && j < lines[i].Length)
                        {
                            name += lines[i][j];
                            j++;
                        };
                        RecordNames.Add(name);
                        for (int k = j + 1; k < lines[i].Length; k++)
                        {
                            money += lines[i][k];
                        }
                        _recordMoney.Add(Convert.ToInt16(money));
                        RecordsDict.Add(RecordNames[i], Convert.ToInt16(money));
                    }
                }
            }
            finally
            {
                reader.Close();
                recordFile.Close();
            }
        }

        /// <summary>
        /// Запись рекордов в файл
        /// </summary>
        public static void WriteFileFromRecords()
        {
            FileStream recordFile = new FileStream("..\\records.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(recordFile);
            try
            {
                for (int i = 0; i < RecordsDict.Count; i++)
                {
                    writer.WriteLine(RecordNames[i] + '|' + RecordsDict[RecordNames[i]]);
                }
            }
            finally
            {
                writer.Close();
            }
        }
    }

}
