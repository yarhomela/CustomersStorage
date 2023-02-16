import { Component, OnInit } from '@angular/core';
import { CryptoJsHelper } from 'src/app/cross-cutting/crypto-js-helper';
import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { GetCustomersByFilterRequestModel } from 'src/app/models/customer/get-customer-by-filter-request-model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-overview',
  templateUrl: './customer-overview.component.html',
  styleUrls: ['./customer-overview.component.scss'],
  providers: [CustomerService]
})

export class CustomerOverviewComponent implements OnInit {
  customers : CustomerViewModel[] = [];
  pages: Array<number> = [];
  pagesCount : number = 1;
  activePage : number = 1;
  requestModel: GetCustomersByFilterRequestModel = new GetCustomersByFilterRequestModel();

  constructor(private customerService : CustomerService, private cryptoHelper : CryptoJsHelper){}

  ngOnInit() {
    this.getByFilter();
    for(let i=2; i <= this.pagesCount; i++){
      this.pages.push(i);
    }
  }

  getByFilter(){
    this.customerService.getListByFilter(this.requestModel).subscribe((response : any) => {
      this.customers = response.customers; 
      this.pagesCount = response.pagesCount;
      this.setOnLocalStorage('customerList',response.customers);
    });
  }

  setOnLocalStorage(itemName : string, item : any){
    let json = JSON.stringify(item);
    let cryptoJson = this.cryptoHelper.encrypt(json);
    localStorage.setItem(itemName, cryptoJson);
  }

  getFromLocalStorage(itemName : string) : any{
    let cryptoJson = localStorage.getItem(itemName)!;
    let json = this.cryptoHelper.decrypt(cryptoJson);
    return JSON.parse(json);
  }

  onChangePage(page : number) {
    this.requestModel.page = page;
    this.getByFilter();
  }

}
