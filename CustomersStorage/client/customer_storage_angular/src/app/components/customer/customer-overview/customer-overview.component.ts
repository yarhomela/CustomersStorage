import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { DOCUMENT } from '@angular/common';
import { LocalStorageHelper } from 'src/app/cross-cutting/local-storage-helper';
import { CustomerService } from 'src/app/services/customer.service';

import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { CustomersSampleRequestModel } from 'src/app/models/customer/customers-sample-request-model';
import { CustomersSampleResponseModel } from 'src/app/models/customer/customers-sample-response-model';

import { customersListName, customersRequestModel } from 'src/app/models/constants';

@Component({
  selector: 'app-customer-overview',
  templateUrl: './customer-overview.component.html',
  styleUrls: ['./customer-overview.component.scss'],
  providers: [CustomerService]
})

export class CustomerOverviewComponent implements OnInit {
  customers: CustomerViewModel[] = [];
  pagesCount: number = 0;
  requestModel: CustomersSampleRequestModel;

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
    this.customerService.getListByFilter(this.requestModel).subscribe((customersViewModel: CustomersSampleResponseModel) => {
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
    if (!isLastPage) {
      ++this.requestModel.page
      this.getByFilter();
    }
  }

  onPageBack(): void {
    let isFirstPage = this.requestModel.page == 1;
    if (!isFirstPage) {
      --this.requestModel.page;
      this.getByFilter();
    }
  }

  onChangeSorting(sortingBy: number): void {
    this.requestModel.byAscending = !this.requestModel.byAscending;
    this.requestModel.sortingBy = sortingBy;
    this.getByFilter();
  }

  redirect(customerId: number) {
    this.router.navigate(['/page/' + customerId]);
  }
}
