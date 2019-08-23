import { Component, OnInit } from '@angular/core';
import { PaystackServices } from "../Shared/PaystackServices";
import { Router,ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-transfer-recipient',
  templateUrl: './create-transfer-recipient.component.html',
  styleUrls: ['./create-transfer-recipient.component.css']
})
export class CreateTransferRecipientComponent implements OnInit {

    constructor(private paystack: PaystackServices, private route:ActivatedRoute, private router:Router) { }

    ngOnInit() {
        this.model.account_number = localStorage.getItem('acctNo');
        this.model.bank_code = localStorage.getItem('bankCode');
    }
    public errorMsg: "";
  public model = {
      name: "",
      account_number: "",
        bank_code: ""
    }
  public supplyModel = {
      Name: "",
      AccountNumber:"",
      AccountName:"",
      BankName:"",
      RecipientCode:""
  }
  public onCreate() {

      var modell = {'name': this.model.name, 'bank_code': this.model.bank_code, 'account_number': this.model.account_number}
   
      console.log("parsed json " + modell)
      console.log("parsed json2 " + JSON.stringify(this.model))
      this.paystack.createrecipient(JSON.stringify(this.model)).subscribe(success => {
          if (success) {
              this.supplyModel.AccountNumber = success["data"]["details"]["account_number"];
              this.supplyModel.BankName = success["data"]["details"]["bank_name"];
              this.supplyModel.AccountName = success["data"]["details"]["account_name"];
              this.supplyModel.RecipientCode = success["data"]["recipient_code"];
              this.supplyModel.Name = success["data"]["name"];
              this.paystack.SaveRecipient(this.supplyModel).subscribe(success => {
                  if (success) {
                      this.router.navigate(["/initiatetransfer", this.supplyModel.RecipientCode]);
                  }

              }, err => this.errorMsg = success["message"]
              );
          }
          this.errorMsg= success["message"]
      });
  }
}
