using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Audit
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
        /// Действие
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Объект действия
        /// </summary>
        public string Object { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public string UserId { get; set; }
    }
}
