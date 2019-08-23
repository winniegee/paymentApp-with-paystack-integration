using System;

namespace Domain.Entities
{
    public class Suppliers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string RecipientCode { get; set; }
    }
}
