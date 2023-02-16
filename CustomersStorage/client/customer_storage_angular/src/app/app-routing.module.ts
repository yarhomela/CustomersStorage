import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerOverviewComponent } from './components/customer/customer-overview/customer-overview.component';
import { CustomerPageComponent } from './components/customer/customer-page/customer-page.component';

const routes: Routes = [
  { path: 'customer/overview', component: CustomerOverviewComponent },
  { path: 'customer/page', component: CustomerPageComponent },
  { path: 'customer/page/:id', component: CustomerPageComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
