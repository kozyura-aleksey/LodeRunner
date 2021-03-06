﻿using System;
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


        public RecordController()
        {
            _modelRecords = new Model.Menu.ModelRecords();
            _viewRecords = new View.Menu.ViewRecords();
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

        }
    }
}