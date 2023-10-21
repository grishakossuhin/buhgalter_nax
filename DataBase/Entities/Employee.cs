using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Thirdname { get; set; }
        public Mol Mol { get; set; }
    }
}
