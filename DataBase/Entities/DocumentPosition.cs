using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class DocumentPosition
    {
        public Guid Id { get; set; }
        public Os Os { get; set; }
        public Document Document { get; set; }
    }
}
