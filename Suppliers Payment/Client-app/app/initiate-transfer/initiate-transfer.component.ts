import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PaystackServices } from "../Shared/PaystackServices";
@Component({
  selector: 'app-initiate-transfer',
  templateUrl: './initiate-transfer.component.html',
  styleUrls: ['./initiate-transfer.component.css']
})
export class InitiateTransferComponent implements OnInit {

    constructor(private route: ActivatedRoute, private router: Router, private paystack: PaystackServices) { }

    ngOnInit() {
        console.log("code is " + this.route.snapshot.paramMap.get('recipientCode'));
        const code = this.route.snapshot.paramMap.get('recipientCode');
        this.model.Recipient = code;
    }
    public theAmount;
    public errorMsg: "";
    public msg: "";
    public model = {
        Amount: 0,
        Recipient: "",
         Reference: "",
         Reason:""
    }
    public onCreate() {
        this.model.Amount = this.theAmount * 100;
        this.paystack.InitiateTransfer(JSON.stringify(this.model)).subscribe(success => {
            if (success) {
                localStorage.setItem("transfer_code", (success["data"]["transfer_code"]))
                this.msg = success["message"];
                this.router.navigate(['/finalizeTransfer']);
            }
        }, err => this.errorMsg = this.msg)
     }

}
