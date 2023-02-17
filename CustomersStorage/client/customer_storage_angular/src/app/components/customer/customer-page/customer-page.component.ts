import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LocalStorageHelper } from 'src/app/cross-cutting/local-storage-helper';
import { customerModel, customersListName } from 'src/app/models/constants';

import { ICustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { IUpdateCustomerViewModel } from 'src/app/models/customer/update-customer-view-model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-page',
  templateUrl: './customer-page.component.html',
  styleUrls: ['./customer-page.component.scss'],
  providers: [CustomerService]
})

export class CustomerPageComponent implements OnInit {
  customerModel: ICustomerViewModel;
  isOpenForUpdate: boolean = false;
  allNames: string[] = [];

  constructor(private customerService: CustomerService,
    private route: ActivatedRoute,
    private localStorageHelper: LocalStorageHelper,
    private router: Router) {
    this.customerModel = customerModel;
  }

  ngOnInit() {
    this.getCustomerId();
    this.isOpenForUpdate = this.customerModel.customerId > 0;

    if (this.isOpenForUpdate) {
      let customerList = this.localStorageHelper.getFromLocalStorage(customersListName) as ICustomerViewModel[];
      let customer = customerList.find(f => f.customerId == this.customerModel.customerId);
      this.customerModel = customer!;
    }
    if (!this.isOpenForUpdate) {
      this.customerService.getAllNames().subscribe((response: any) => {
        this.allNames = response;
      });
    }
  }

  getCustomerId(): void {
    let routeSub = this.route.params.subscribe(params => {
      this.customerModel.customerId = params['id'];
    });
    routeSub.unsubscribe();
  }

  addCustomer(): void {
    this.customerService.add(this.customerModel).subscribe(
      res => {
        this.router.navigate(['../overview']);
      });
  }

  editCustomer(): void {
    let updateModel = {
      customerId: this.customerModel.customerId,
      name: this.customerModel.name,
      companyName: this.customerModel.companyName,
      phone: this.customerModel.phone,
      email: this.customerModel.email
    } as IUpdateCustomerViewModel;

    this.customerService.edit(updateModel).subscribe(
      res => {
        this.router.navigate(['../overview']);
      });
  }

  removeCustomer(customerId: number): void {
    this.customerService.remove(customerId).subscribe(
      res => {
        this.router.navigate(['../overview']);
      });
  }

  redirect(): void {
    this.router.navigate(['../overview']);
  }
}