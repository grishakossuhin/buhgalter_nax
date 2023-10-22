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
        public Guid NameId { get; set; }
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
        public double StartPrice { get; set; }
        /// <summary>
        /// Отправитель
        /// </summary>
        public Guid SenderId { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        public Guid RecepiantId { get; set; }

        /// <summary>
        /// Група ОС
        /// </summary>
        public Guid GroupId { get; set; }
        /// <summary>
        /// МОЛ
        /// </summary>
        public Guid MolId { get; set; }
        /// <summary>
        /// Документ
        /// </summary>
        public Guid DocumentId { get; set; }
    }
}
