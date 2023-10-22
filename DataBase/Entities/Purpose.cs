using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Purpose
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employee Employee { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public Post Post { get; set; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public Departament Departament { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime BeginDate { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
