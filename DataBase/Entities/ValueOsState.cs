using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class ValueOsState
    {
        public Guid Id { get; set; }
        public Os Os { get; set; }
        public OsState OsState { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
