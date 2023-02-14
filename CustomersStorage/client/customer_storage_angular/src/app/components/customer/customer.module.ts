import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerOverviewComponent } from './customer-overview/customer-overview.component';
import { CustomerViewModel } from 'src/app/models/customer/customer-view-model';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [CustomerOverviewComponent],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class CustomerModule { }
