using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public Employee Recipient { get; set; }
        public Employee Sender { get; set; }
    }
}
