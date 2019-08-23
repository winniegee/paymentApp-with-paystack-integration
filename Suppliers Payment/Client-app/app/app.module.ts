import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CreateTransferRecipientComponent } from './create-transfer-recipient/create-transfer-recipient.component';
import { PaystackServices } from 'Client-app/app/Shared/PaystackServices';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { VerifyAccountNumberComponent } from './verify-account-number/verify-account-number.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { ListSuppliersComponent } from './list-suppliers/list-suppliers.component';
import { InitiateTransferComponent } from './initiate-transfer/initiate-transfer.component';
import { FinalizeTransferComponent } from './finalize-transfer/finalize-transfer.component';

@NgModule({
    declarations: [
        AppComponent,
        CreateTransferRecipientComponent,
        VerifyAccountNumberComponent,
        ListSuppliersComponent,
        InitiateTransferComponent,
        FinalizeTransferComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule.forRoot([
            { path: 'pay', component: VerifyAccountNumberComponent },
            { path: 'createRecipient', component: CreateTransferRecipientComponent },
            { path: 'initiatetransfer/:recipientCode', component: InitiateTransferComponent },
            { path: 'listSuppliers', component: ListSuppliersComponent },
            { path: 'finalizeTransfer', component: FinalizeTransferComponent },
            { path: '', redirectTo: 'pay', pathMatch: 'full' }
            
        ]),
        BrowserModule,
        HttpClientModule,
        NgxPaginationModule
       
    ],
  
  providers: [PaystackServices ],
  bootstrap: [AppComponent],
})
export class AppModule { }
