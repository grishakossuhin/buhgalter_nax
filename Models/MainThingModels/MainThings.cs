using System;
using System.Collections.Generic;

namespace BuhUchetApi.Models.MainThingModels
{
    public class MainThings
    {
        /// <summary>
        /// ИД
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Серийный номер
        /// </summary>
        public string Serialnumber { get; set; }
        /// <summary>
        /// Группа
        /// </summary>
        public MtGroup Group { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public MtName Name { get; set; }
        /// <summary>
        /// МОЛ
        /// </summary>
        public MtMol Mol { get; set; }
        /// <summary>
        /// Документ
        /// </summary>
        public MtDocument Document { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public MtValueState State { get; set; }
        public List<MtValueParametr> Parametrs { get; set; }
        /// <summary>
        /// Амортизация
        /// </summary>
        public MtAmortization Amortization { get; set; }
    }

    public class MtGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UsefullDate { get; set; }
    }

    public class MtName
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class MtMol
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public MtEmployee Employee { get; set; }
    }

    public class MtEmployee
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Thirdname { get; set; }
        public MtPurpose Purpose { get; set; }
    }

    public class MtPurpose
    {
        public Guid Id { get; set; }
        public MtPost Post { get; set; }
        public MtDepartament Departament { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class MtPost
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class MtDepartament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class MtDocument
    {
        public Guid Id { get; set; }
        public MtEmployee Sender { get; set; }
        public MtEmployee Recepiant { get; set; }
    }

    public class MtAmortization
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Сумма начислений за месяц
        /// </summary>
        public double SummMonth { get; set; }
    }

    public class MtValueState
    {
        public Guid Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public MtState Name { get; set; }
    }

    public class MtState
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class MtValueParametr
    {
        public Guid Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public MtParametr Name { get; set; }
        public double Value { get; set; }
    }

    public class MtParametr
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
