using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class DepreciationAct
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Сумма начислений за месяц
        /// </summary>
        public double SummMonth { get; set; }

        /// <summary>
        /// ОС
        /// </summary>
        public Os Os { get; set; }
    }
}
