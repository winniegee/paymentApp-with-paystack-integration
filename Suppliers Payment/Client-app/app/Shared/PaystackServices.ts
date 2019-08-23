import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { CreateTransferRecipientModel } from "Client-app/app/Shared/CreateTransferRecipientModel";
import { ResolveBankAccountModel } from "Client-app/app/Shared/ResolveBankAccountModel";

@Injectable()
export class PaystackServices {
    constructor(private router: Router, private http: HttpClient) {

    }
    public banks = [];
    public suppliers = [];
    public getBanks() {
        console.log("in getbanks");
        let headers = new HttpHeaders({
            'Content-Type': 'application/json',
          
        })
        return this.http.get("http://localhost:5000/api/paystack/getBanks", { headers: headers }).pipe(
            map((data: any[]) => {
                this.banks = data;
                return true;
            }))
    }
   
    public createrecipient(model): Observable<any> {
        let headers = new HttpHeaders({
            'Content-Type': 'application/json',
        })
        return this.http.post("http://localhost:5000/api/paystack/createtransferrecipient", model, { headers: headers }).pipe(
            map((data: any) => {
                console.log("heree again " + JSON.stringify(data))
                return data;
            }));
    }

    public ResolveAccountNumber(account_number, bank_code): Observable<ResolveBankAccountModel> {
        return this.http.get("http://localhost:5000/api/paystack/resolveAccountNumber", { params: { account_number: account_number, bank_code: bank_code } }).pipe(
            map((data: any) => {
                return data;
            }))
    }
    public SaveRecipient(recipient): Observable<any> {
        let headers = new HttpHeaders({
            'Content-Type': 'application/json',
        })
        var recipientt = JSON.stringify(recipient);
        return this.http.post("http://localhost:5000/api/bakery/createSupplier", recipient, { headers: headers }).pipe(map((data: any) => {
            
            return true;
        }
      ))
    }
    public ListSuppliers() {
        return this.http.get("http://localhost:5000/api/bakery/listSuppliers").pipe(map((data: any[]) => {
            this.suppliers = data;
            return true;
        }))
    }
    public InitiateTransfer(model) {
        let headers = new HttpHeaders({
            'Content-Type': 'application/json'
        })
        var modell = JSON.stringify(model);
        return this.http.post("http://localhost:5000/api/paystack/initiateTransfer", model, { headers: headers }).pipe(map((data: any) => {
            console.log("data returned from suppliers contoller " + data);
            return data;
        }))
    }
    public FinalizeTransfer(transfercode, Otp):Observable<any> {
        let headers = new HttpHeaders({
            'Content-Type': 'application/json'
        })
        let data = {
            "transfercode": transfercode,
            "otp": Otp
        };
        let body = JSON.stringify(data);
        return this.http.post("http://localhost:5000/api/paystack/finalizeTransfer", data, {headers:headers}).pipe(map((data: any) => {
            alert("Trasfer Successful!")
            return data;
        }))
    }
    }
   