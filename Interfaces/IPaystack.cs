using Models;
using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPaystack
    {
        //Task<Transfer_Recipient_Model> Create_Transfer_Recipient(string name, string account_number, string bank_code, string type );
        Task<Transfer_Recipient_Model> Create_Transfer_Recipient(Transfer_Recipient_Request_Model recipient_Request_Model);
        //Task<Transfer_Recipient_Request_Model> Initiate_Transfer(string name);
        Task<Initiate_Transfer_Response_Model> Initiate_Transfer(Initiate_Transfer_Request_Model  initiate_transfer_Model);
        Task<Resolve_accountNumber_response_model> resolve_AccountNumber(string account_number, string bank_code);
        Task<Bank_List_Response_Model> ListBanks();
        Task<FinalizeTransferModel> Finalize_Transfer(string transfer_code, string otp);
        Task<ListSuppliersModel> List_Suppliers();
        void Get_Event(string[] body);
    }
}
