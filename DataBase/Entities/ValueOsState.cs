using System;
using System.Runtime.Serialization;
using static BuhUchetApi.Models.Enums;

namespace BuhUchetApi.DataBase.Entities
{
    public class ValueOsState
    {
        public Guid Id { get; set; }
        public Os Os { get; set; }
        public OsState OsState { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public States States { get; set; }
    }
}
