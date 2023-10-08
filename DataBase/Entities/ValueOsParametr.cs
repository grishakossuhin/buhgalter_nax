using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class ValueOsParametr
    {
        public Guid Id { get; set; }
        public string ParametrId { get; set; }
        public string OsStateId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
