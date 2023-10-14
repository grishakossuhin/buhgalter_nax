using System;
using System.Collections.Generic;

namespace BuhUchetApi.DataBase.Entities
{
    public class Os
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public OsName OsName { get; set; }
        public Mol Mol { get; set; }
        public OsGroup OsGroup { get; set; }
        public ValueOsState ValueOsState { get; set; }
        public List<ValueOsParametr> ValueOsParametrs { get; set; }
    }
}
