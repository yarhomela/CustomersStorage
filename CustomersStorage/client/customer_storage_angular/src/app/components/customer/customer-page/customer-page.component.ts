import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LocalStorageHelper } from 'src/app/cross-cutting/local-storage-helper';
import { CreateCustomerViewModel } from 'src/app/models/customer/create-customer-view-model';
import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { UpdateCustomerViewModel } from 'src/app/models/customer/update-customer-view-model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-page',
  templateUrl: './customer-page.component.html',
  styleUrls: ['./customer-page.component.scss'],
  providers: [CustomerService]
})

export class CustomerPageComponent implements OnInit {
    customer: CustomerViewModel;
    customerId: number = 0;

    // const user: User = {
    //     name: string;
    // }
    // const user = {
    //     name: string;
    //     password: string;
    // } as CustomerViewModel

    constructor(private customerService : CustomerService, 
        private route: ActivatedRoute,
        private localStorageHelper : LocalStorageHelper,
        private router: Router){
        this.customer = new CustomerViewModel();
        let routeSub = this.route.params.subscribe(params => {
            this.customerId = params['id'];
          });
        routeSub.unsubscribe();
        if(this.customerId > 0){
            let customerList = localStorageHelper.getFromLocalStorage('customerList') as CustomerViewModel[];
            let customer = customerList.find(f => f.customerId == this.customerId);
            this.customer = customer!;
        }
        
    }

    ngOnInit() {

    }

    addCustomer(){
        this.customerService.add(this.customer);
    }

    getCustomer(){
        this.customerService.getById(this.customerId).subscribe(customer => this.customer = customer);
    }

    editCustomer(){
        let editModel = new UpdateCustomerViewModel();
        editModel.customerId = this.customerId;
        editModel.name = this.customer.name;
        editModel.companyName = this.customer.companyName;
        editModel.phone = this.customer.phone;
        editModel.email = this.customer.email;
        this.customerService.edit(editModel).subscribe();
    }

    removeCustomer(customerId: any) {
        this.customerService.remove(customerId).subscribe(
          res => {
            debugger
            this.router.navigate(['../overview']);
        });
      }

      redirect() {
        this.router.navigate(['../overview']);
      }
}