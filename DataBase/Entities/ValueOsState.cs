using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class ValueOsState
    {
        public Guid Id { get; set; }
        public string OsId { get; set; }
        public string OsStateId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
