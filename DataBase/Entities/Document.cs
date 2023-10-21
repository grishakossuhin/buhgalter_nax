using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Получатель
        /// </summary>
        public Employee Recipient { get; set; }
        /// <summary>
        /// Отправитель
        /// </summary>
        public Employee Sender { get; set; }
        /// <summary>
        /// ОС
        /// </summary>
        public Os Os { get; set; }
    }
}
