import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InvoiceRoutingModule } from './invoice-routing.module';
import { ListComponent } from './list/list.component';
import { AddInvoiceComponent } from './add-invoice/add-invoice.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ListComponent, AddInvoiceComponent],
  imports: [
    CommonModule,
    FormsModule,
    InvoiceRoutingModule
  ]
})
export class InvoiceModule { }
