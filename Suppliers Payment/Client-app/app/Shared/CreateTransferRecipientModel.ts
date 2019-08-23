export class CreateTransferRecipientModel {
    Status: boolean;
    Message: string;
    Data: RecipientData;
}

export class RecipientData {
    Account_Number: string;
    Account_Name: string;
    Bank_Name: string;
}