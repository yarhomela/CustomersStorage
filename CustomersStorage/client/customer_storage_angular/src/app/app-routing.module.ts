import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerOverviewComponent } from './components/customer/customer-overview/customer-overview.component';
import { CustomerPageComponent } from './components/customer/customer-page/customer-page.component';

const routes: Routes = [
  { path: 'overview', component: CustomerOverviewComponent },
  { path: 'page', component: CustomerPageComponent },
  { path: 'page/:id', component: CustomerPageComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
