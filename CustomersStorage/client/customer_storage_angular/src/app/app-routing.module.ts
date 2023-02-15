import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerOverviewComponent } from './components/customer/customer-overview/customer-overview.component';

const routes: Routes = [
  { path: 'customer/overview', component: CustomerOverviewComponent },
  //{ path: '**', redirectTo: 'customer/overview', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
