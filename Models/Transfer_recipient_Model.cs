using Newtonsoft.Json;
using System;

namespace Models
{
    public class Transfer_Recipient_Model
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class Details { 
        [JsonProperty("bank_name")]
        public string Bank_Name { get; set; }
        [JsonProperty("bank_code")]
        public string Bank_Code { get; set; }
        [JsonProperty("account_name")]
        public string Account_Name { get; set; }
        [JsonProperty("account_number")]
        public string Account_Number { get; set; }
    }
    public class Data
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("integration")]
        public int Integration { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("details")]
        public Details Details { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("recipient_code")]
        public string Recipient_code { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

}
