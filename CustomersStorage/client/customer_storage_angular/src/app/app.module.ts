import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerModule } from './components/customer/customer.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CustomerService } from './services/customer.service';
import { HttpClientModule }   from '@angular/common/http';
import { AppHeaderComponent } from './app-header/app-header.component';
import { FormsModule }   from '@angular/forms';
import { LocalStorageHelper } from './cross-cutting/local-storage-helper';

@NgModule({
  declarations: [
    AppComponent,
    AppHeaderComponent,
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CustomerModule,
    NgbModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [CustomerService, LocalStorageHelper],
  bootstrap: [AppComponent]
})
export class AppModule { }
