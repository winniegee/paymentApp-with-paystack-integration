import { Component, OnInit } from '@angular/core';
import { PaystackServices } from 'Client-app/app/Shared/PaystackServices';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-suppliers',
  templateUrl: './list-suppliers.component.html',
  styleUrls: ['./list-suppliers.component.css']
})
export class ListSuppliersComponent implements OnInit {

    constructor(private paystack: PaystackServices, private router: Router) { }

    ngOnInit() {
        this.paystack.ListSuppliers().subscribe(success => {
          if (success) {
              this.suppliers = this.paystack.suppliers;
            }
          this.msg = this.errorMsg = success["message"];
          
        },
            err => this.errorMsg = this.msg);
  }
    public suppliers = [];
    public errorMsg: "";
    public msg: "";
  public pay(code) {
          this.router.navigate(['/initiatetransfer', code]);
  }

}
