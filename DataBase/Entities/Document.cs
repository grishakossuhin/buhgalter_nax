using System;

namespace BuhUchetApi.DataBase.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Recipient { get; set; }
        public string Sender { get; set; }
    }
}
