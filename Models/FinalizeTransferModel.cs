 using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FinalizeTransferModel
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public inalizeTransferData Data { get; set; }
    }
    public class inalizeTransferData
    {
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("source_details")]
        public object Source_details { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("failures")]
        public object failures { get; set; }
        [JsonProperty("transfer_code")]
        public string Transfer_code { get; set; }
        [JsonProperty("transfer_code")]
        public object titan_code { get; set; }
        [JsonProperty("transferred_at")]
        public object Transferred_at { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("integration")]
        public int Integration { get; set; }
        [JsonProperty("recipient")]
        public int Recipient { get; set; }
    }
}
