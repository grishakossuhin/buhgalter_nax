using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static BuhUchetApi.Models.Enums;

namespace BuhUchetApi.Models.MainThingModels
{
    public class CreationOsDto
    {
        /// <summary>
        /// Серийный номер
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата принятия к учету
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Дата изготовления / постройки
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Первоначальная стоимость
        /// </summary>
        public int StartPrice { get; set; }
        /// <summary>
        /// Набор расширяемых параметров
        /// </summary>
        public List<Parametr> Parametrs { get; set; }
        /// <summary>
        /// МОЛ
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Срок полезного использования в годах
        /// </summary>
        public int UsefullMonths { get; set; }

        /// <summary>
        /// Група ОС
        /// </summary>
        public Groups Group { get; set; }

        public Guid MolId { get; set; }
    }
}
