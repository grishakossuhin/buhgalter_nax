using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class OsGroup
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Срок полезного использования в месяцах
        /// </summary>
        public int UsefullDate { get; set; }
    }
}
