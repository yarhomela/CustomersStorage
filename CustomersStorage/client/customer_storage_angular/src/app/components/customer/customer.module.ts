import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerOverviewComponent } from './customer-overview/customer-overview.component';
import { FormsModule } from '@angular/forms';
import { CustomerPageComponent } from './customer-page/customer-page.component';

@NgModule({
  declarations: [CustomerOverviewComponent,CustomerPageComponent],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class CustomerModule { }
