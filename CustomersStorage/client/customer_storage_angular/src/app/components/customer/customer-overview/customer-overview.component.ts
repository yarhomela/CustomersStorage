import { Component, Inject, OnInit } from '@angular/core';
import { LocalStorageHelper } from 'src/app/cross-cutting/local-storage-helper';
import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { IGetCustomersByFilterRequestModel } from 'src/app/models/customer/get-customer-by-filter-request-model';
import { CustomerService } from 'src/app/services/customer.service';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-customer-overview',
  templateUrl: './customer-overview.component.html',
  styleUrls: ['./customer-overview.component.scss'],
  providers: [CustomerService]
})

export class CustomerOverviewComponent implements OnInit {
  private customerListName: string = 'customerList';
  customers: CustomerViewModel[] = [];
  pagesCount: number = 1;
  requestModel: any = requestModel;

  constructor(private customerService: CustomerService,
    private localStorageHelper: LocalStorageHelper,
    private router: Router,
    @Inject(DOCUMENT) private document: Document) { }

  ngOnInit() {
    //let storedData = this.localStorageHelper.getFromLocalStorage(this.customerListName);
    //let isNeedRefresh = storedData == null;
    this.getByFilter();

  }

  getByFilter() {
    this.customerService.getListByFilter(requestModel).subscribe((response: any) => {
      this.customers = response.customers;
      this.pagesCount = response.pagesCount;
      this.localStorageHelper.setOnLocalStorage(this.customerListName, response.customers);
    });
  }

  removeCustomer(customerId: any) {
    this.customerService.remove(customerId).subscribe(
      res => {
        let elementId = "table-row-" + customerId;
        document.getElementById(elementId)?.remove();
        this.getByFilter();
      });
  }

  onPageNext(): void {
    let isLastPage = requestModel.page == this.pagesCount;
    if(!isLastPage){
      ++requestModel.page
      this.getByFilter();
    }
  }

  onPageBack(): void {
    let isFirstPage = requestModel.page == 1;
    if(!isFirstPage){
      --requestModel.page;
      this.getByFilter();
    }
  }

  onChangeSorting(sortingBy: number): void{
    requestModel.byAscending = !requestModel.byAscending;
    requestModel.sortingBy = sortingBy;
    this.getByFilter();
  }

  redirect(customerId: any) {
    this.router.navigate(['/page/' + customerId]);
  }
}

const requestModel = {
  searchWord: '',
  sortingBy: 2,
  byAscending: true,
  page: 1,
  pageSize: 10,
} as IGetCustomersByFilterRequestModel
