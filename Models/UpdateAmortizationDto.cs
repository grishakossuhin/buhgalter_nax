using System;

namespace BuhUchetApi.Models
{
    public class UpdateAmortizationDto
    {
        /// <summary>
        /// ID амортизации
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Конечная дата
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Остаточная стоимость
        /// </summary>
        public double OstatochnStoim { get; set; }
        /// <summary>
        /// Начисленный износ
        /// </summary>
        public double NachslIznos { get; set; }
        /// <summary>
        /// Амортизация в месяц
        /// </summary>
        public double AmortMonth { get; set; }
    }
}
