import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { LocalStorageHelper } from 'src/app/cross-cutting/local-storage-helper';
import { CustomerService } from 'src/app/services/customer.service';

import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { CustomerUpdateModel } from 'src/app/models/customer/customer-update-model';

import { customerModel, customersListName } from 'src/app/models/constants';

@Component({
  selector: 'app-customer-page',
  templateUrl: './customer-page.component.html',
  styleUrls: ['./customer-page.component.scss'],
  providers: [CustomerService]
})

export class CustomerPageComponent implements OnInit {
  customerModel: CustomerViewModel;
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
      let customerList = this.localStorageHelper.getFromLocalStorage(customersListName) as CustomerViewModel[];
      let customer = customerList.find(f => f.customerId == this.customerModel.customerId);
      this.customerModel = customer!;
    }

    this.getAllCustomerNames();
  }

  getCustomerId(): void {
    let routeSub = this.route.params.subscribe(params => {
      this.customerModel.customerId = params['id'];
    });
    routeSub.unsubscribe();
  }

  getAllCustomerNames(): void{
    this.customerService.getAllNames().subscribe(data => {
      this.allNames = data;
      debugger
      let index = this.allNames.indexOf(this.customerModel.name, 0);
      if (this.isOpenForUpdate && index > -1) {
        this.allNames.splice(index, 1);
      }});
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
    } as CustomerUpdateModel;

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