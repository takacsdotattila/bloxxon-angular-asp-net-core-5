import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { CustomerRoutingModule } from './customer-routing.module';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';
import { AddEditDeleteComponent } from './add-edit-delete/add-edit-delete.component';


@NgModule({
  declarations: [ListComponent, DetailsComponent, AddEditDeleteComponent ],  
  imports: [
    CommonModule,
    FormsModule,
    CustomerRoutingModule
  ]
})

export class CustomerModule { }
