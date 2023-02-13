import { Component } from '@angular/core';
import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';

@Component({
  selector: 'app-customer-overview',
  templateUrl: './customer-overview.component.html',
  styleUrls: ['./customer-overview.component.scss'],
})

export class CustomerOverviewComponent  {
  customers : CustomerViewModel[] = [];

  ngOnInit() {
    this.onGet();
  }

  onGet(){
    // to do
    this.customers = [
      new  CustomerViewModel(1, "name", "companyName", "+380661020300", "generated@email.som"),
      new  CustomerViewModel(2, "Jane", "Wander", "+380661020300", "jane@email.som"),
      new  CustomerViewModel(3, "Veleor", "FT", "+380661020300", "veleor@email.som"),
      new  CustomerViewModel(4, "Nick", "Furry", "+380661020300", "nickd@email.som"),
      new  CustomerViewModel(5, "Jeckie", "ChanProd", "+380661020300", "jeckie@email.som"),
      new  CustomerViewModel(6, "Sir", "Lanselot", "+380661020300", "sir@email.som")
    ]
  }

}
