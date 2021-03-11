import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { CustomerRoutingModule } from './customer-routing.module';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';


@NgModule({
  declarations: [ListComponent, DetailsComponent, AddCustomerComponent ],  
  imports: [
    CommonModule,
    FormsModule,
    CustomerRoutingModule
  ]
})

export class CustomerModule { }
