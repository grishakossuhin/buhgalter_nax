using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Purpose
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; }
        public string PostId { get; set; }
        public string DepartamentId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
