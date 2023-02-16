import { Component, Inject, OnInit } from '@angular/core';
import { LocalStorageHelper } from 'src/app/cross-cutting/local-storage-helper';
import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { GetCustomersByFilterRequestModel } from 'src/app/models/customer/get-customer-by-filter-request-model';
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
  pages: Array<number> = [];
  pagesCount: number = 1;
  activePage: number = 1;
  requestModel: GetCustomersByFilterRequestModel = new GetCustomersByFilterRequestModel();

  constructor(private customerService: CustomerService,
    private localStorageHelper: LocalStorageHelper,
    private router: Router,
    @Inject(DOCUMENT) private document: Document) { }

  ngOnInit() {
    //let storedData = this.localStorageHelper.getFromLocalStorage(this.customerListName);
    //let isNeedRefresh = storedData == null;
    this.getByFilter();
    for (let i = 2; i <= this.pagesCount; i++) {
      this.pages.push(i);
    }

  }

  getByFilter() {
    this.customerService.getListByFilter(this.requestModel).subscribe((response: any) => {
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

  onChangePage(page: number) {
    this.requestModel.page = page;
    this.getByFilter();
  }

  redirect(customerId: any) {
    this.router.navigate(['/page/' + customerId]);
  }
}
