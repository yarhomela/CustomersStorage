import { Component, OnInit } from '@angular/core';
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
  activePage: number = 1;
  requestModel: GetCustomersByFilterRequestModel = new GetCustomersByFilterRequestModel();

  constructor(private customerService : CustomerService){}

  ngOnInit() {
    this.getByFilter();
    for(let i=2; i < 7; i++){
      this.pages.push(i);
    }
  }

  getByFilter(){
    this.customerService.getListByFilter(this.requestModel).subscribe(list => this.customers = list);
  }

  onChangePage(event : any, page : number) {
    this.activePage = page;
    // var target = event.target || event.srcElement || event.currentTarget;
    // var idAttr = target.attributes.id;
    // var value = idAttr.nodeValue;
    //alert('Open ' + item);
  }

}
