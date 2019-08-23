using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Initiate_Transfer_Request_Model
    {

        //amount to be transferred in kobo
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        //code for transfer recipient
        [JsonProperty("recipient")]
        public string Recipient { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; } = "balance";

    }

}
