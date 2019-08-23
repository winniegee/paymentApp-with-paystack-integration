import { Component, OnInit } from '@angular/core';
import { PaystackServices } from 'Client-app/app/Shared/PaystackServices';
import { Router } from '@angular/router';


@Component({
  selector: 'app-verify-account-number',
  templateUrl: './verify-account-number.component.html',
  styleUrls: ['./verify-account-number.component.css']
})
export class VerifyAccountNumberComponent implements OnInit {

    constructor(private paystack: PaystackServices, private router: Router) {
        this.config = {
            itemsPerPage: 4,
            currentPage: 1,
            totalItems: this.banks.length
        }
    }
    ngOnInit() {
        this.paystack.getBanks().subscribe(success => {
            if (success) {
                this.banks = this.paystack.banks["data"];
                console.log("banks in ts" + this.banks);
            }
        });
    }

    public banks = [];
  public model = {
      account_number: "",
      bank_code: ""
    }
  config: any;
  pageChanged(event) {
      this.config.currentPage = event;
  }
  public errorMsg: "";
  public onCreate() {

      var modell = {'bank_code': this.model.bank_code, 'account_number': this.model.account_number }
      this.paystack.ResolveAccountNumber(this.model.account_number, this.model.bank_code).subscribe(success => {
          if (success) {
              localStorage.setItem('acctNo', this.model.account_number);
              localStorage.setItem('bankCode', this.model.bank_code);
              var account_number = success["data"]["account_number"];
              var account_name = success["data"]["account_name"];
              alert("Verified successfully!! Details are " + JSON.stringify(account_number) + "," + JSON.stringify(account_name))
              setTimeout(() => {
                  this.router.navigate(["/createRecipient"]);
              },(4000));
          
          }
          this.errorMsg = success["message"];
          
      });
  }

}
