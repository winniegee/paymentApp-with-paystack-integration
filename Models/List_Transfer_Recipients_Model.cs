using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class List_Transfer_Recipients_Model
    {
        //how many records to retrieve per page
        [JsonProperty("perPage")]
        public int PerPage { get; set; }

        //exactly what page to retrieve
        [JsonProperty("page")]
        public int Page { get; set; }
    }
}
