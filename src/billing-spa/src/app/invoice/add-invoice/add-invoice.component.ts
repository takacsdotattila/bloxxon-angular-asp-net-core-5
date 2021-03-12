import { Component, EventEmitter, OnInit, Output } from '@angular/core';

import { Customer } from 'src/app/core/models/customer';
import { InvoiceCreate } from 'src/app/core/models/invoiceCreate';
import { InvoiceWithCustomer } from 'src/app/core/models/invoiceListItem';
import { DataService } from 'src/app/core/services/data.service';

@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrls: ['./add-invoice.component.scss']
})
export class AddInvoiceComponent implements OnInit {
  @Output() addInvoice = new EventEmitter<InvoiceWithCustomer>();
  invoice: InvoiceCreate = {
    customerid: "select customer from list >>>",
    amount: 0,
    deadline: new Date()
  };

  customers!: Customer[];

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.getCustomers()
      .subscribe(x => this.customers = x)
  }
  createNewInvoice(){
    console.log(this.invoice);
    this.dataService.createNewInvoice(this.invoice)
    .subscribe(x => {
      alert("Invoice created!");
      this.addInvoice.emit(x);
    });
  }

}
