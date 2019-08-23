using HelperClass;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Suppliers_Payment_web.Controllers
{
    public class PaystackControllers : Controller
    {
        public IPaystack paystack;
        public PaystackControllers(IPaystack paystack)
        {
            this.paystack = paystack;
        }
        [HttpPost]
        [Route("api/paystack/createtransferrecipient")]
        public async Task<ActionResult> Create_Transfer_Recipient([FromBody]Transfer_Recipient_Request_Model model)
        {
            if (ModelState.IsValid)
            {
                var transferRecipient = await paystack.Create_Transfer_Recipient(model);
                return Ok(transferRecipient);
            }

            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("api/paystack/getBanks")]
        public async Task<ActionResult> GetBanks()

        {
            var resolve = await paystack.ListBanks();
            return Ok(resolve);
        }

        [HttpGet]
        [Route("api/paystack/resolveAccountNumber")]
        public async Task<ActionResult> Resolve_AccountNumber(string account_number, string bank_code)
        {
            if (ModelState.IsValid)
            {
                var resolve = await paystack.resolve_AccountNumber(account_number, bank_code);
                return Ok(resolve);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("api/paystack/initiateTransfer")]
        public async Task<ActionResult> InitiateTransfer([FromBody]Initiate_Transfer_Request_Model model)
        {
            if (ModelState.IsValid)
            {
                var response = await paystack.Initiate_Transfer(model);
                return Ok(response);
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("api/paystack/listSuppliers")]
        public async Task<ActionResult> ListSuppliers()
        {
                var response = await paystack.List_Suppliers();
            return Ok(response);
        }
        [HttpPost]
        [Route("api/paystack/finalizeTransfer")]
        public async Task<ActionResult> FinalizeTransfer([FromBody]Transferparams transferparams)
        {
               var response = await paystack.Finalize_Transfer(transferparams.transfercode, transferparams.otp);
                return Ok(response);
         
        }
        [HttpPost]
        [Route("api/paystack/event")]
        public void Get_Event(string[] body)
        {
            this.paystack.Get_Event(body);
        }

    }
    public class Transferparams{
        public string transfercode { get; set; }
        public string otp { get; set; }
}
}
