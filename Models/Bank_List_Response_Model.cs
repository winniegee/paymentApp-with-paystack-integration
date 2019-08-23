using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Bank_List_Response_Model
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Bank_Model> data { get; set; }
    }
}
