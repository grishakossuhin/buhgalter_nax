using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class ValueOsParametr
    {
        public Guid Id { get; set; }
        public OsParametr OsParametr { get; set; }
        public Os Os { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Value { get; set; }
    }
}
