import { Component, OnInit } from '@angular/core';
import { PaystackServices } from "../Shared/PaystackServices";
import { Router } from '@angular/router';
@Component({
  selector: 'app-finalize-transfer',
  templateUrl: './finalize-transfer.component.html',
  styleUrls: ['./finalize-transfer.component.css']
})
export class FinalizeTransferComponent implements OnInit {

  constructor(private paystack:PaystackServices, private router:Router) { }

  ngOnInit() {
  }
  public otpinput: "";
  public errorMsg: "";
     transfercode = localStorage.getItem("transfer_code");
     public submit() {
         this.paystack.FinalizeTransfer(this.transfercode, this.otpinput).subscribe(success => {
             if (success) {
                 localStorage.removeItem("acctNo");
                 localStorage.removeItem("bankCode");
                 localStorage.removeItem("transfer_code")
                 alert("Transfer successful");
                 this.router.navigate[('/pay')]
             }
         })
  }

}
