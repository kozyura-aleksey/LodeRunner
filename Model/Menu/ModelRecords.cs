using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    /// <summary>
    /// Класс - модель рекордов
    /// </summary>
    public class ModelRecords
    {
        /// <summary>
        /// Модель рекордов
        /// </summary>
        private Records _records;

        /// <summary>
        /// Создать модель рекордов
        /// </summary>
        public ModelRecords()
        {
            _records = new Records();
        }

        /// <summary>
        /// Получить рекорды
        /// </summary>
        /// <returns></returns>
        public Records gerRecords()
        {
            return _records;
        }
    }
}
