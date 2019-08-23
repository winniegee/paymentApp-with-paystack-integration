using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Resolve_accountNumber_response_model
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public AccountData Data { get; set; }
    }
    public class AccountData
    {
        [JsonProperty("account_number")]
        public string Account_Number { get; set; }
        [JsonProperty("account_name")]
        public string Account_Name { get; set; }
    }
}
