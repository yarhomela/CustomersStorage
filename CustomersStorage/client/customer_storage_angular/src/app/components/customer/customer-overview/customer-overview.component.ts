import { Component, Inject, OnInit } from '@angular/core';
import { LocalStorageHelper } from 'src/app/cross-cutting/local-storage-helper';
import { ICustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { IGetCustomersByFilterRequestModel } from 'src/app/models/customer/get-customer-by-filter-request-model';
import { CustomerService } from 'src/app/services/customer.service';
import { Router } from '@angular/router';
import { DOCUMENT } from '@angular/common';
import { ICustomerSampleViewModel } from 'src/app/models/customer/customer-sample-view-model';
import { customersListName, customersRequestModel } from 'src/app/models/constants';

@Component({
  selector: 'app-customer-overview',
  templateUrl: './customer-overview.component.html',
  styleUrls: ['./customer-overview.component.scss'],
  providers: [CustomerService]
})

export class CustomerOverviewComponent implements OnInit {
  customers: ICustomerViewModel[] = [];
  pagesCount: number = 0;
  requestModel: IGetCustomersByFilterRequestModel;

  constructor(private customerService: CustomerService,
    private localStorageHelper: LocalStorageHelper,
    private router: Router,
    @Inject(DOCUMENT) private document: Document) {
      this.requestModel = customersRequestModel;
     }

  ngOnInit() {
    this.getByFilter();
  }

  getByFilter(): void {
    this.customerService.getListByFilter(this.requestModel).subscribe((customersViewModel: ICustomerSampleViewModel) => {
      this.customers = customersViewModel.customers;
      this.pagesCount = customersViewModel.pagesCount;
      this.localStorageHelper.setOnLocalStorage(customersListName, customersViewModel.customers);
    });
  }

  removeCustomer(customerId: number): void {
    this.customerService.remove(customerId).subscribe(
      res => {
        let elementId = "table-row-" + customerId;
        document.getElementById(elementId)?.remove();
        this.getByFilter();
      });
  }

  onPageNext(): void {
    let isLastPage = this.requestModel.page == this.pagesCount;
    if(!isLastPage){
      ++this.requestModel.page
      this.getByFilter();
    }
  }

  onPageBack(): void {
    let isFirstPage = this.requestModel.page == 1;
    if(!isFirstPage){
      --this.requestModel.page;
      this.getByFilter();
    }
  }

  onChangeSorting(sortingBy: number): void{
    this.requestModel.byAscending = !this.requestModel.byAscending;
    this.requestModel.sortingBy = sortingBy;
    this.getByFilter();
  }

  redirect(customerId: number) {
    this.router.navigate(['/page/' + customerId]);
  }
}
