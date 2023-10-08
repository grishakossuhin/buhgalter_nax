using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Os
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public OsName OsName { get; set; }
        public Mol Mol { get; set; }
        public OsGroup OsGroup { get; set; }
    }
}
