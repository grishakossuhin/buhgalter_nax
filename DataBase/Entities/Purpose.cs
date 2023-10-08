using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Purpose
    {
        public Guid Id { get; set; }
        public Employee Employee { get; set; }
        public Post PostId { get; set; }
        public Departament Departament { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
