import { Component, OnInit } from '@angular/core';
import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-overview',
  templateUrl: './customer-overview.component.html',
  styleUrls: ['./customer-overview.component.scss'],
  providers: [CustomerService]
})

export class CustomerOverviewComponent implements OnInit {
  customers : CustomerViewModel[] = [];

  constructor(private customerService : CustomerService){}

  ngOnInit() {
    this.customerService.getList().subscribe(list => this.customers = list)
      }

}
