using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Os
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string OsNameId { get; set; }
        public string MolId { get; set; }
        public string OsGroupId { get; set; }
    }
}
