using Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Text;
using System.Threading.Tasks;
using HelperClass;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Providers
{
    public class Paystack : IPaystack
    {
        private readonly IOptions<Appsettings> settings;
        private readonly HttpClient _client;
        public Paystack(IOptions<Appsettings> settings)
        {
            this.settings = settings;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = false;
            _client = new HttpClient { BaseAddress = new Uri("https://api.paystack.co/") };
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.Value.secret_key.ToString());
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            

        }
        #region ListBanks
        public async Task<Bank_List_Response_Model> ListBanks()
        {

            var response = await this.GetEntities("https://api.paystack.co/bank");
            return JsonConvert.DeserializeObject<Bank_List_Response_Model>(response);
        }
        #endregion
        #region createTransferRecipient
        public async Task<Transfer_Recipient_Model> Create_Transfer_Recipient(Transfer_Recipient_Request_Model recipientRequestModel)
        {
            var content = await this.SendRequest(JsonConvert.SerializeObject(recipientRequestModel), Base_Settings.Base_URL + "transferrecipient");
            return JsonConvert.DeserializeObject<Transfer_Recipient_Model>(content);
        }
        #endregion
        #region resolveAccount
        public async Task<Resolve_accountNumber_response_model> resolve_AccountNumber(string account_number, string bank_code)
        {
           string paramms= string.Format("account_number={0}&bank_code={1}", System.Web.HttpUtility.UrlEncode($"{account_number}"), System.Web.HttpUtility.UrlEncode($"{bank_code}"));
            var content = await this.GetEntities(Base_Settings.Base_URL + $"bank/resolve?{paramms}");
            return JsonConvert.DeserializeObject<Resolve_accountNumber_response_model>(content);
        }
        #endregion

        #region Initiate_Transfer
        public async Task<Initiate_Transfer_Response_Model> Initiate_Transfer(Initiate_Transfer_Request_Model initiate_transfer_Model)
        {
            var content = await this.SendRequest(JsonConvert.SerializeObject(initiate_transfer_Model), Base_Settings.Base_URL + "transfer");
            return JsonConvert.DeserializeObject<Initiate_Transfer_Response_Model>(content);
        }
        #endregion
        #region  finalizeTransfer
        public async Task<FinalizeTransferModel> Finalize_Transfer(string transfer_code, string otp)
        {
            var values = new Dictionary<string, string>
        {
           { "transfer_code", transfer_code },
           { "otp", $"{otp}" }
        };
            var content = await this.SendRequest(JsonConvert.SerializeObject(values), Base_Settings.Base_URL + "finalize_transfer");
            return JsonConvert.DeserializeObject<FinalizeTransferModel>(content);
        }
        #endregion
        #region listSuppliers
        public async Task<ListSuppliersModel> List_Suppliers()
        {
            var content = await this.GetEntities(Base_Settings.Base_URL + "transfer");
            return JsonConvert.DeserializeObject<ListSuppliersModel>(content);
        }
        #endregion
        public void Get_Event(string[] body)
        {
            String key = this.settings.Value.secret_key.ToString();
            String jsonInput = "{\"paystack\":\"[client]\",\"body\":\"[body]\"}"; //the json input
            String inputString = Convert.ToString(new JValue(jsonInput));

            String result = "";
            byte[] secretkeyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
            using (var hmac = new HMACSHA512(secretkeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                result = BitConverter.ToString(hashValue).Replace("-", string.Empty); ;
            }

            String xpaystackSignature = this._client.DefaultRequestHeaders.GetValues("X-Paystack-Signature").ToString();

            if (result.ToLower().Equals(xpaystackSignature))
            {
             
                // you can trust the event, it came from paystack
                // respond with the http 200 response immediately before attempting to process the response
                //retrieve the request body, and deliver value to the customer
            }
            else
            {
                // this isn't from Paystack, ignore it
            }
        }
        #region sendRequest

        public async Task<string> SendRequest(string postData, string resourceUrl)
        {

            HttpResponseMessage httpResponse = await _client.PostAsync(resourceUrl, new StringContent(postData, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var stream = await httpResponse.Content.ReadAsStreamAsync();
            var streamReader = new StreamReader(stream);
            string responseString = "";
            responseString = streamReader.ReadToEnd();
            return await httpResponse.Content.ReadAsStringAsync();   
        }
        #endregion
        #region GetEntities
        public async Task<string> GetEntities(string resourceUrl)
        {
            var response =await _client.GetAsync(resourceUrl);
            var stream = await response.Content.ReadAsStreamAsync();
            var streamReader = new StreamReader(stream);
            string responseString = "";
            responseString = streamReader.ReadToEnd();
            return await response.Content.ReadAsStringAsync();
        }
        #endregion
    }
}