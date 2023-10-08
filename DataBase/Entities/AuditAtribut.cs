using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class AuditAtribut
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Измененный атрибут
        /// </summary>
        public string Atribut { get; set; }
        /// <summary>
        /// Новое значение
        /// </summary>
        public string NewValue { get; set; }
        /// <summary>
        /// Старое значение
        /// </summary>
        public string OldValue { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public string UserId { get; set; }
    }
}
