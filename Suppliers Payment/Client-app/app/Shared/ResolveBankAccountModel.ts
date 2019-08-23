export class ResolveBankAccountModel {
    Status: boolean;
    Message: string;
    Data: AccountData;
}

export class AccountData {
   Account_Number: string;
   Account_Name: string;
   Bank_Name: string;
}