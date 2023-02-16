import { Component, OnInit } from '@angular/core';
import { LocalStorageHelper } from 'src/app/cross-cutting/local-storage-helper';
import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { GetCustomersByFilterRequestModel } from 'src/app/models/customer/get-customer-by-filter-request-model';
import { CustomerService } from 'src/app/services/customer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-overview',
  templateUrl: './customer-overview.component.html',
  styleUrls: ['./customer-overview.component.scss'],
  providers: [CustomerService]
})

export class CustomerOverviewComponent implements OnInit {
  private customerListName : string = 'customerList';
  customers : CustomerViewModel[] = [];
  pages: Array<number> = [];
  pagesCount : number = 1;
  activePage : number = 1;
  requestModel: GetCustomersByFilterRequestModel = new GetCustomersByFilterRequestModel();

  constructor(private customerService : CustomerService, private localStorageHelper : LocalStorageHelper, private router : Router){}

  ngOnInit() {
    let storedData = this.localStorageHelper.getFromLocalStorage(this.customerListName);
    let isNeedRefresh = storedData == null;

    if(!isNeedRefresh){
      this.customers = storedData;
    }
    if(isNeedRefresh){
      this.getByFilter();
      for(let i=2; i <= this.pagesCount; i++){
        this.pages.push(i);
      }

    }
  }

  getByFilter(){
    this.customerService.getListByFilter(this.requestModel).subscribe((response : any) => {
      this.customers = response.customers; 
      this.pagesCount = response.pagesCount;
      this.localStorageHelper.setOnLocalStorage(this.customerListName, response.customers);
    });
  }

  onChangePage(page : number) {
    this.requestModel.page = page;
    this.getByFilter();
  }

  redirect(customerId : any) {
    this.router.navigate(['/page/' + customerId]);
  }
}
