using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Transfer_Recipient_Request_Model
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "Nuban";

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("account_number")]
        public string Account_Number { get; set; }

        [JsonProperty("bank_code")]
        public string Bank_Code { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("authorization_code")]
        public string Authorization_Code { get; set; }
    }
}
