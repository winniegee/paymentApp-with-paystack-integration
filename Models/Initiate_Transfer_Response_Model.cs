using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Initiate_Transfer_Response_Model
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public ResponnseData Data { get; set; }
    }

    public class ResponnseData
    {
        [JsonProperty("integration")]
        public int Integration { get; set; }
        [JsonProperty("doamin")]
        public string Domain { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("recipient")]
        public int Recipient { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("transfer_code")]
        public string Transfer_code { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }

    }
}

