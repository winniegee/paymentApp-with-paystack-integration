using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructuree.Data.ViewModels
{
   public class SuppliersVM
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string RecipientCode { get; set; }
        public SuppliersVM()
        {

        }
       
        public Suppliers Create()
        {
            return new Suppliers()
            {
                Name = Name,
                AccountNumber = AccountNumber,
                BankName = BankName,
                AccountName = AccountName,
                RecipientCode = RecipientCode
            };
        }
    }
}
